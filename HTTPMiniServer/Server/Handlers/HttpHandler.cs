﻿namespace HTTPMiniServer.Server.Handlers
{
   using System.Text.RegularExpressions;
   using Contracts;
   using HTTP.Contracts;
   using HTTP.Response;
   using Common;
   using Routing.Contracts;


   public class HttpHandler : IRequestHandler
   {
      private readonly IServerRouteConfig serverRouteConfig;

      public HttpHandler(IServerRouteConfig routeConfig)
      {
         CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

         this.serverRouteConfig = routeConfig;
      }

      public IHttpResponse Handle(IHttpContext httpContext)
      {

         var requestMethod = httpContext.Request.Method;
         var requestPath = httpContext.Request.Path;

         var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];


         foreach (var registeredRoute in registeredRoutes)
         {
            var routePattern = registeredRoute.Key;
            var routingContext = registeredRoute.Value;

            var routeRegex = new Regex(routePattern);
            var match = routeRegex.Match(requestPath);

            if (!match.Success)
            {
               continue;
            }

            var parameters = routingContext.Parameters;


            foreach (var parameter in parameters)
            {
               var parameterValue = match.Groups[parameter].Value;

               httpContext.Request.AddUrlParameter(parameter, parameterValue);
            }

            return routingContext.Handler.Handle(httpContext);
         }

            return new NotFondResponse();
      }
   }
}
