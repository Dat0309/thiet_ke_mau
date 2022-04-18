using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Singleton_optimized
{
    public class Program
    {
        
        public static void Main()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();
            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                WriteLine("Same instance\n");
            }
            // Next, load balance 15 requests for a server
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                WriteLine("Dispatch request to: " + serverName);
            }
            // Wait for user
            ReadKey();
        }
    }
  
    public sealed class LoadBalancer
    {
        
        private static readonly LoadBalancer instance = new LoadBalancer();
        private readonly List<Server> servers;
        private readonly Random random = new Random();
        private LoadBalancer()
        {
            servers = new List<Server>
                {
                  new Server{ Name = "ServerI", IP = "120.14.220.18" },
                  new Server{ Name = "ServerII", IP = "120.14.220.19" },
                  new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                  new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                  new Server{ Name = "ServerV", IP = "120.14.220.22" },
                };
        }
        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }
        // Simple, but effective load balancer
        public Server NextServer
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r];
            }
        }
    }
   
    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}
