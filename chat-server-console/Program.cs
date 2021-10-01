using System;
using System.ServiceModel;
using chat_library;

namespace chat_server_console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();
                Console.WriteLine("Server is running.");
                Console.ReadLine();
            }

            //var uris = new Uri[1];
            //string adr = "net.tcp://localhost:8081";
            //uris[0] = new Uri(adr);
            //IChatService service = new ChatService();
            //ServiceHost host = new ServiceHost(service, uris);
            //var binding = new NetTcpBinding(SecurityMode.None);
            //host.AddServiceEndpoint(typeof(IChatService), binding, String.Empty);
            //host.Opened += HostOnOpened;
            //host.Open();
        }

        //private static void HostOnOpened(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Server is running.");
        //}
    }
}
