namespace HTTPMiniServer.Routing
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Contracts;
   using Server.HTTP.Contracts;
   using Server.Enums;
   using Server.Handlers;

   public class AppRouteConfig : IAppRouteConfig
   {
      private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

      public AppRouteConfig()
      {
         this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

         var availableMthods = Enum
            .GetValues(typeof(HttpRequestMethod))
            .Cast<HttpRequestMethod>();

         foreach (var method in availableMthods)
         {
            this.routes[method] = new Dictionary<string, RequestHandler>();
         }
      }

      public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

      public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
      {
         this.AddRoute(route,HttpRequestMethod.Get,new RequestHandler(handler));
      }

      public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
      {
         this.AddRoute(route, HttpRequestMethod.Post, new RequestHandler(handler));
      }

      public void AddRoute(string route, HttpRequestMethod method, RequestHandler handler)
      {
         this.routes[method].Add(route,handler);
      }
   }
}
