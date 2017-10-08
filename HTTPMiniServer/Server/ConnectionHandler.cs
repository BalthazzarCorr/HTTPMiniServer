namespace HTTPMiniServer.Server
{

   using System;
   using System.Net.Sockets;
   using System.Text;
   using System.Threading.Tasks;
   using HTTPMiniServer.Routing.Contracts;
   using HTTPMiniServer.Server.Common;
   using HTTPMiniServer.Server.Handlers;
   using HTTPMiniServer.Server.HTTP;
   using HTTPMiniServer.Server.HTTP.Contracts;

   public class ConnectionHandler
   {
      private readonly Socket client;

      private readonly IServerRoutingConfig serverRouteConfig;

      public ConnectionHandler(Socket client, IServerRoutingConfig serverRouteConfig)
      {
         CoreValidator.ThrowIfNull(client, nameof(client));
         CoreValidator.ThrowIfNull(serverRouteConfig, nameof(IServerRoutingConfig));

         this.client = client;
         this.serverRouteConfig = serverRouteConfig;
      }

      public async Task ProcessRequesAsync()
      {
         var httpRequest = await this.ReadRequest();

         if (httpRequest != null) 
         {

            var httpContext = new HttpContext(httpRequest);

            var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            var responeBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());

            var byteSegment = new ArraySegment<byte>(responeBytes);

            await this.client.SendAsync(byteSegment, SocketFlags.None);

            Console.WriteLine($"-----REQUEST-----");
            Console.WriteLine(httpRequest);
            Console.WriteLine($"-----RESPONSE-----");
            Console.WriteLine(httpResponse);
            Console.WriteLine();

         }

         this.client.Shutdown(SocketShutdown.Both);

      }

      private async Task<IHttpRequest> ReadRequest()
      {
         var result = new StringBuilder();

         var data = new ArraySegment<byte>(new byte[1024]);


         while (true)
         {
            int nuberOfBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);

            if (nuberOfBytesRead == 0)
            {
               break;
            }

            var bytesAsStirng = Encoding.UTF8.GetString(data.Array, 0, nuberOfBytesRead);

            result.Append(bytesAsStirng);

            if (nuberOfBytesRead < 1024)
            {
               break;
            }

           

         }

         if (result.Length == 0)
         {
            return null;
         }

         return new HttpRequest(result.ToString());
      }
   }
}
