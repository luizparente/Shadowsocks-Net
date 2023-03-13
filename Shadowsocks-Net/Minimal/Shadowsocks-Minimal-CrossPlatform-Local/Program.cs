/*
 * Modified from Shadowsocks-Net https://github.com/shadowsocks/Shadowsocks-Net
 */

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shadowsocks.Http;
using Shadowsocks.Local;
using Shadowsocks_Minimal_Crossplatform_Local.Utilities;

namespace Shadowsocks_Minimal_Crossplatform_Local
{
    class Program
    {
        static LocalServer localServer = null;
        static HttpProxyServer httpProxyServer = null;

        static async Task Main(string[] args)
        {
            InitServers(args);

            localServer.Start();
            httpProxyServer.Start();

            Console.WriteLine("Press any key to stop server.");
            Console.ReadKey();

            localServer.Stop();
            httpProxyServer.Stop();
        }

        private static void InitServers(string[] args)
        {
            ILogger logger = GetLogger();
            var configuration = ConsoleArgumentParser.ParseShadowsocksConfiguration(args);
            var serverLoader = new CustomServerLoader(configuration);

            LocalServerConfig socks5Config = new LocalServerConfig()
            {
                Port = configuration.LocalSocks5Port,
                UseLoopbackAddress = true
            };
            HttpProxyServerConfig httpConfig = new HttpProxyServerConfig()
            {
                Port = configuration.LocalHttpPort,
                UseLoopbackAddress = true
            };

            if (localServer == null)
            {
                localServer = new LocalServer(socks5Config, serverLoader, logger);
            }
            if (httpProxyServer == null)
            {
                httpProxyServer = new HttpProxyServer(httpConfig, serverLoader, logger);
            }
        }

        private static ILogger GetLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddConsole();
            });

            var logger = loggerFactory.CreateLogger("Local");
            return logger;
        }
    }
}
