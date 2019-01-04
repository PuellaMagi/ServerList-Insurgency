using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace MagicGirl_ServerList
{
    public partial class MainForm : Form
    {
        private static Timer timer = new Timer();
        private static ushort time = 65535;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // list
            ServerList.BeginUpdate();
            foreach (Server.server_t srv in Server.servers)
            {
                ListViewItem item = new ListViewItem();
                item.Text = srv.type;
                item.Tag = srv.addr + ":" + srv.port;
                item.SubItems.Add(srv.addr + ":" + srv.port);
                item.SubItems.Add("unknow");
                item.SubItems.Add("-1");
                item.SubItems.Add("-1");
                item.SubItems.Add("-1");
                ServerList.Items.Add(item);
            }
            ServerList.EndUpdate();
            Application.DoEvents();

            timer.Tick += (obj, eArgs) =>
            {
                time--;

                if (time == 0)
                {
                    UpdateList();
                    time = 30;
                }
                else if (time < 30)
                {
                    Label_Info.Text = "将在 " + time + "秒 后刷新...";
                }
            };

            timer.Interval = 1000;
            timer.Start();

            new System.Threading.Thread(()=>
            {
                System.Threading.Thread.Sleep(1000);

                Invoke(new Action(() =>
                {
                    UpdateList();
                }));

                time = 30;
            }).Start();
        }

        private void UpdateList()
        {
            foreach (ListViewItem item in ServerList.Items)
            {
                UpdateServer(item);
                System.Threading.Thread.Sleep(233);
            }
        }

        private void UpdateServer(ListViewItem item)
        {
            Label_Info.Text = "正在从 " + item.SubItems[1].Text + " 读取数据...";
            Application.DoEvents();

            string[] data = item.Tag.ToString().Split(':');
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(data[0]), Convert.ToInt32(data[1]));
            A2S_CSM(ep, out string h, out string m, out ushort c, out ushort p, out ushort l);

            item.SubItems[1].Text = l == 65535 ? item.SubItems[1].Text + " [服务器异常]" : h;
            item.SubItems[2].Text = m;
            item.SubItems[3].Text = c.ToString();
            item.SubItems[4].Text = p.ToString();
            item.SubItems[5].Text = l == 65535 ? "Error" : l.ToString();
            Application.DoEvents();
        }

        private static readonly byte[] request_a2scsm = new byte[9] { 0xFF, 0xFF, 0xFF, 0xFF, 0x66, 0xFF, 0xFF, 0xFF, 0xFF };
        private void A2S_CSM(IPEndPoint ep, out string h, out string m, out ushort c, out ushort p, out ushort l)
        {
            l = 0;
            c = 0;
            p = 0;
            h = ep.ToString();
            m = "unknown";

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                try
                {
                    DateTime before = DateTime.Now;

                    byte[] response = new byte[384];

                    socket.SendTimeout = 100;
                    socket.ReceiveTimeout = 100;

                    socket.SendTo(request_a2scsm, ep);
                    socket.Receive(response, response.Length, SocketFlags.None);

                    string[] data = Encoding.UTF8.GetString(response).Trim().Split('\r');

                    if (data.Length != 4)
                    {
                        // exception
                        throw new Exception("Wrong data offset from EP: " + ep.ToString());
                    }

                    h = data[0];
                    m = data[1];
                    c = Convert.ToUInt16(data[2]);
                    p = Convert.ToUInt16(data[3]);

                    TimeSpan latency = DateTime.Now - before;
                    l = Convert.ToUInt16(latency.TotalMilliseconds);
                }
                catch (Exception e)
                {
                    l = 65535;
                    Console.WriteLine("{0} -> {1}", ep, e.Message);
                }
            }
        }

        private void List_Clicked(object sender, MouseEventArgs e)
        {
            int index = ServerList.SelectedIndices[0];

            string server = ServerList.Items[index].Tag.ToString();

            if (MessageBox.Show("主机: " + ServerList.Items[index].SubItems[1].Text + Environment.NewLine + "地址: " + server + Environment.NewLine + "人数: " + ServerList.Items[index].SubItems[3].Text + "/" + ServerList.Items[index].SubItems[4].Text,
                "要进入服务器?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) == DialogResult.OK)
            {
                Process.Start("steam://connect/" + server + "/from magicgirl");
            }
        }

        private void List_IndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Clipboard.SetText(ServerList.Items[e.ItemIndex].Tag.ToString());
        }
    }
}
