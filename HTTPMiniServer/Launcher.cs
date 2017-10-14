namespace HTTPMiniServer
{
   using Routing;
   using Server;
   using Server.Contracts;
   using ByTheCakeApplication;
   public class Launcher : IRunnable
   {

      static void Main(string[] args)
      {
         new Launcher().Run();
      }

      public void Run()
      {

        // var mainApplication = new MainApplication();

         var mainApplication = new ByTheCakeApp();
         var appRouteConfing = new AppRouteConfig();
         mainApplication.Configure(appRouteConfing);

         var webServer = new WebServer(1337, appRouteConfing);
         webServer.Run();
      }
   }
}
