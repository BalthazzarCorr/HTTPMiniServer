namespace HTTPMiniServer.ByTheCakeApplication
{
   using HTTPMiniServer.ByTheCakeApplication.Controllers;
   using HTTPMiniServer.Routing.Contracts;
   using HTTPMiniServer.Server.Contracts;



   public class ByTheCakeApp:IApplication
   {
      public void Configure(IAppRouteConfig appRouteConfig)
      {
         appRouteConfig
            .Get("/", req => new HomeController().Index());
      }
   }
}
