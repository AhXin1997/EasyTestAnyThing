using Microsoft.Owin.Hosting;
using System;

namespace EasyTestAnyThing.WebServer
{
    public static class ServerStart
    {
        public static void Server(bool open)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses.
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx
            // for more information.
            if (!open)
            {
                return;
            }
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadKey();
            }
        }
    }
}