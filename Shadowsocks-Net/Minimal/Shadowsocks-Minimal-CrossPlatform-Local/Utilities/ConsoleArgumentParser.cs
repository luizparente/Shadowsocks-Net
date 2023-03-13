using Shadowsocks_Minimal_Crossplatform_Local.Configuration;
using System.Collections.Generic;
using System.Net;

namespace Shadowsocks_Minimal_Crossplatform_Local.Utilities
{
    public static class ConsoleArgumentParser
    {
        public static ShadowsocksConfiguration ParseShadowsocksConfiguration(string[] args)
        {
            var parsed = Parse(args);
            var configuration = new ShadowsocksConfiguration()
            {
                RemoteServerIP = IPAddress.Parse(parsed["-r"]),
                RemotePort = int.Parse(parsed["-q"]),
                RemotePassword = parsed["-k"],
                Cypher = parsed["-c"],
                LocalServerIP = IPAddress.Parse(parsed["-l"]),
                LocalHttpPort = int.Parse(parsed["-h"]),
                LocalSocks5Port = int.Parse(parsed["-s"])
            };

            return configuration;
        }
        private static IDictionary<string, string> Parse(string[] args)
        {
            var result = new Dictionary<string, string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(args[i], args[i + 1]);
                }
            }

            return result;
        }
    }
}
