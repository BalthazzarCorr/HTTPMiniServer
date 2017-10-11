namespace HTTPMiniServer.Application
{
   using Controllers;
   using Routing.Contracts;
   using Server.Contracts;
   using Server.Handlers;

   public class MainApplication : IApplication
   {
      public void Configure(IAppRouteConfig appRouteConfig)
      {
        appRouteConfig
            .AddRoute(
           "/", 
           new GetHandler(request=> new HomeController().Index()));

         appRouteConfig
            .AddRoute(
            "/register", 
            new PostHandler(
               httpContext => new UserController()
               .RegisterPost(httpContext.FormData["name"])));

         appRouteConfig
            .AddRoute(
            "/register", 
            new GetHandler(
               httpContext => new UserController()
               .RegisterGet()));

         appRouteConfig
            .AddRoute(
            "/user/{(?<name>[a-z]+)}", 
            new GetHandler(httpContext => new UserController()
            .Details(httpContext.UrlParameters["name"])));;

      }
   }
}
