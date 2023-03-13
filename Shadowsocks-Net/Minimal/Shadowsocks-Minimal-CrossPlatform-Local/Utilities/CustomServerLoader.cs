using Shadowsocks.Local;
using Shadowsocks_Minimal_Crossplatform_Local.Configuration;

namespace Shadowsocks_Minimal_Crossplatform_Local.Utilities
{
    public class CustomServerLoader : IServerLoader
    {
        protected Server _server;
        protected ShadowsocksConfiguration _configuration;

        public CustomServerLoader(ShadowsocksConfiguration config)
        {
            _configuration = config;
        }

        public Server Load()
        {
            var server = new Server()
            {
                Address = _configuration.RemoteServerIP.ToString(),
                Port = (ushort)_configuration.RemotePort,
                Password = _configuration.RemotePassword,
                Cipher = _configuration.Cypher
            };

            return server;
        }
    }
}
