namespace HTTPMiniServer.Server
{
   using System;
   using System.Net;
   using System.Net.Sockets;
   using System.Threading.Tasks;
   using Contracts;
   using Routing;
   using Handlers;
   using Routing.Contracts;


   public class WebServer : IRunnable
   {
      private const string localHostIpaAddres = "127.0.0.1";

      private readonly int port;

      private readonly IServerRoutingConfig serverRoutingConfig;

      private readonly TcpListener listener;

      private bool isRunning;

      public WebServer(int port, IAppRoutConfig appRouteConfig)
      {
         this.port = port;
         this.serverRoutingConfig = new ServerRouteConfig(appRouteConfig);

         this.listener = new TcpListener(IPAddress.Parse(localHostIpaAddres), port);

      }

      public void Run()
      {
         this.listener.Start();

         this.isRunning = true;

         Console.WriteLine($"Server running on {localHostIpaAddres}:{port}");

         Task.Run(this.ListenLoop);
      }

      private async Task ListenLoop()
      {
         while (this.isRunning)
         {
            var client = await this.listener.AcceptSocketAsync();

            var connectionHandler = new ConnectionHandler(client, this.serverRoutingConfig);

            await connectionHandler.ProcessRequesAsync();
         }
      }
   }
}
