namespace MagicGirl_ServerList
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerList = new System.Windows.Forms.ListView();
            this.game = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.servername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.map = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cplayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label_Info = new System.Windows.Forms.Label();
            this.mplayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ServerList
            // 
            this.ServerList.AllowColumnReorder = true;
            this.ServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerList.BackColor = System.Drawing.Color.White;
            this.ServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.game,
            this.servername,
            this.map,
            this.cplayers,
            this.mplayers,
            this.ping});
            this.ServerList.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ServerList.FullRowSelect = true;
            this.ServerList.GridLines = true;
            this.ServerList.HideSelection = false;
            this.ServerList.Location = new System.Drawing.Point(20, 20);
            this.ServerList.MultiSelect = false;
            this.ServerList.Name = "ServerList";
            this.ServerList.Scrollable = false;
            this.ServerList.ShowGroups = false;
            this.ServerList.Size = new System.Drawing.Size(580, 236);
            this.ServerList.TabIndex = 1;
            this.ServerList.UseCompatibleStateImageBehavior = false;
            this.ServerList.View = System.Windows.Forms.View.Details;
            this.ServerList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.List_IndexChanged);
            this.ServerList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.List_Clicked);
            // 
            // game
            // 
            this.game.Text = "类型";
            this.game.Width = 66;
            // 
            // servername
            // 
            this.servername.Text = "服务器名称";
            this.servername.Width = 231;
            // 
            // map
            // 
            this.map.Text = "地图名";
            this.map.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.map.Width = 108;
            // 
            // cplayers
            // 
            this.cplayers.Text = "当前人数";
            this.cplayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ping
            // 
            this.ping.Text = "延迟";
            this.ping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ping.Width = 51;
            // 
            // Label_Info
            // 
            this.Label_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Info.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Info.Location = new System.Drawing.Point(20, 260);
            this.Label_Info.Name = "Label_Info";
            this.Label_Info.Size = new System.Drawing.Size(300, 20);
            this.Label_Info.TabIndex = 2;
            this.Label_Info.Text = "初始化.....";
            this.Label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mplayers
            // 
            this.mplayers.Text = "最大人数";
            this.mplayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.Label_Info);
            this.Controls.Add(this.ServerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔法少女 Insurgency 服务器列表";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ServerList;
        private System.Windows.Forms.ColumnHeader game;
        private System.Windows.Forms.ColumnHeader servername;
        private System.Windows.Forms.ColumnHeader map;
        private System.Windows.Forms.ColumnHeader cplayers;
        private System.Windows.Forms.ColumnHeader ping;
        private System.Windows.Forms.Label Label_Info;
        private System.Windows.Forms.ColumnHeader mplayers;
    }
}

