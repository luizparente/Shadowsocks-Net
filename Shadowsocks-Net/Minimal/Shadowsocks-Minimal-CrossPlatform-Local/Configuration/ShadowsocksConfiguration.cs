using System.Net;

namespace Shadowsocks_Minimal_Crossplatform_Local.Configuration
{
    public class ShadowsocksConfiguration
    {
        public IPAddress LocalServerIP { get; set; }
        public int LocalHttpPort { get; set; }
        public int LocalSocks5Port { get; set; }
        public IPAddress RemoteServerIP { get; set; }
        public int RemotePort { get; set; }
        public string RemotePassword { get; set; }
        public string Cypher { get; set; }

        public ShadowsocksConfiguration()
        { }

        public ShadowsocksConfiguration(IPAddress localServerIp, int localHttpPort, int localSocks5Port, IPAddress remoteServerIp, int remotePort, string remotePassword, string cypher)
        {
            LocalServerIP = localServerIp;
            LocalHttpPort = localHttpPort;
            LocalSocks5Port = localSocks5Port;
            RemoteServerIP = remoteServerIp;
            RemotePort = remotePort;
            RemotePassword = remotePassword;
            Cypher = cypher;
        }

        public ShadowsocksConfiguration(string localServerIp, int localHttpPort, int localSocks5Port, string remoteServerIp, int remotePort, string remotePassword, string cypher)
            : this(IPAddress.Parse(localServerIp), localHttpPort, localSocks5Port, IPAddress.Parse(remoteServerIp), remotePort, remotePassword, cypher)
        { }
    }
}
