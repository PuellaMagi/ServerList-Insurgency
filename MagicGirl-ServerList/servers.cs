using System.Collections.Generic;

namespace MagicGirl_ServerList
{
    class Server
    {
        public struct server_t
        {
            public string addr;
            public ushort port;
            public string type;

            public server_t(string i, ushort p, string t)
            {
                addr = i;
                port = p;
                type = t;
            }
        }

        public static List<server_t> servers = new List<server_t>();

        public static void Init()
        {
            // PVP #1
            servers.Add(new server_t("43.241.50.62", 27030, "PVP"));

            // PVP #4
            servers.Add(new server_t("43.241.50.62", 27034, "PVP"));

            // PVP #6
            servers.Add(new server_t("43.241.50.62", 27036, "PVP"));

            // PVP #7
            servers.Add(new server_t("43.241.50.62", 27037, "PVP"));

            // PVE #2
            servers.Add(new server_t("43.241.50.62", 27042, "PVE"));

            // PVE #3
            servers.Add(new server_t("43.241.50.62", 27043, "PVE"));

            // PVE #4
            servers.Add(new server_t("43.241.50.62", 27044, "PVE"));

            // PVE #5
            servers.Add(new server_t("43.241.50.62", 27045, "PVE"));
        }
    }
}
