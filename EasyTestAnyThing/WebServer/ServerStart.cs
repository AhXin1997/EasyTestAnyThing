using Microsoft.Owin.Hosting;
using System;

namespace EasyTestAnyThing.WebServer
{
    public class ServerStart
    {
        public static void StartServer()
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses.
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx
            // for more information.
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadKey();
            }
        }
    }
}