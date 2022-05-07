using System;

namespace Proxy_structural
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();
            // Wait for user
            Console.ReadKey();
        }

        /// <summary>
        /// The 'Subject' abstract class
        /// </summary>
        abstract class Subject
        {
            public abstract void Request();
        }
        /// <summary>
        /// The 'RealSubject' class
        /// </summary>
        class RealSubject : Subject
        {
            public override void Request()
            {
                Console.WriteLine("Called RealSubject.Request()");
            }
        }
        /// <summary>
        /// The 'Proxy' class
        /// </summary>
        class Proxy : Subject
        {
            private RealSubject _realSubject;
            public override void Request()
            {
                // Use 'lazy initialization'
                if (_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }
                _realSubject.Request();
            }
        }
    }
}
