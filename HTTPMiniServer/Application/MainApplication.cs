namespace HTTPMiniServer.Application
{
   using Controllers;
   using Routing.Contracts;
   using Server.Contracts;

   public class MainApplication : IApplication
   {
      public void Configure(IAppRouteConfig appRouteConfig)
      {

     
        appRouteConfig.Get(
           "/", 
           request=> new HomeController().Index());

         appRouteConfig.Post(
            "/register", 
               httpContext => new UserController()
               .RegisterPost(httpContext.FormData["name"]));

         appRouteConfig
           .Get(
            "/register", 
              httpContext => new UserController()
               .RegisterGet());

         appRouteConfig
            .Get(
            "/user/{(?<name>[a-z]+)}", 
            httpContext => new UserController()
            .Details(httpContext.UrlParameters["name"]));

      }
   }
}
