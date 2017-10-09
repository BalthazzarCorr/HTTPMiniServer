namespace HTTPMiniServer.Application
{
   using Controllers;
   using Server.Handlers;
   using Routing.Contracts;
   using Server.Contracts;

   public class MainApplication : IApplication
   {
      public void Configure(IAppRouteConfig appRoutConfig)
      {
        appRoutConfig
            .AddRoute("/", new GetHandler(request=> new HomeController().Index()));

         //appRoutConfig
         //   .AddRoute("/about" , new GetHandler(requeset=>));
      }
   }
}
