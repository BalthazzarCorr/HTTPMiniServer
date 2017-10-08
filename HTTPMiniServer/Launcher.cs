using  System;
namespace HTTPMiniServer
{
   using Routing;
   using Server;
   using Server.Contracts;

   public class Launcher : IRunnable
   {

      static void Main(string[] args)
      {
         new Launcher().Run();
      }

      public void Run()
      {
         var appRouteConfing = new AppRouteConfig();
         var webServer = new WebServer(1337, appRouteConfing);
         webServer.Run();
      }
   }
}
