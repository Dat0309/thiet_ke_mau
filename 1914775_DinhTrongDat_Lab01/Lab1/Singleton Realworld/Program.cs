using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Realworld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();
            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }
            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public class LoadBalancer
    {
        static LoadBalancer instance;
        List<string> servers = new List<string>();
        Random random = new Random();
        private static object locker = new object();
        protected LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }
        public static LoadBalancer GetLoadBalancer()
        {
           
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }
            return instance;
        }

        public string Server
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            }
        }
    }
}
