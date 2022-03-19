using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
            Console.ReadKey();
        }
    }
  
    public class Singleton
    {
        static Singleton instance;
        protected Singleton()
        {
        }
        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
