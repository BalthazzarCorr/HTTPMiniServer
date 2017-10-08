namespace HTTPMiniServer.Routing
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Text.RegularExpressions;
   using Contracts;
   using Server.Enums;

   public class ServerRouteConfig : IServerRoutingConfig
   {
      private readonly IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> routes;

      public ServerRouteConfig(IAppRoutConfig appRouteConfig)
      {
         this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();

         var availibleMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

         foreach (var method in availibleMethods)

         {
            this.routes[method] = new Dictionary<string, IRoutingContext>();
         }

         this.InitializeRouteConfig(appRouteConfig);
      }


      public IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }

      private void InitializeRouteConfig(IAppRoutConfig appRouteConfig)
      {
         foreach (var registerdRoute in appRouteConfig.Routes)
         {
            var requestMethod = registerdRoute.Key;
            var routeWithHandlers = registerdRoute.Value;

            foreach (var routeWithHandler in routeWithHandlers)
            {

               var route = routeWithHandler.Key;
               var handler = routeWithHandler.Value;

               var parameters = new List<string>();

               var parsedRouteRegex = this.ParsedRoute(route, parameters);

               var routingContext = new RoutingContext(handler, parameters);

               this.routes[requestMethod].Add(parsedRouteRegex, routingContext);
            }
         }
      }

      private string ParsedRoute(string route, List<string> parameters)
      {
         var result = new StringBuilder();
         result.Append("^");

         if (route == "/")
         {
            result.Append("/$");
            return result.ToString();

         }

         var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

         this.ParseTokens(tokens, parameters, result);

         return result.ToString();

      }

      private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder result)
      {
         for (int i = 0; i < tokens.Length; i++)
         {
            var end = tokens.Length - 1 == i ? "$" : "/";

            var currentToken = tokens[i];

            if (!currentToken.StartsWith('{') && !currentToken.EndsWith('}'))
            {
               result.Append($"{currentToken}{end}");
               continue;
            }

            var parameterRegex = new Regex("<\\w+>");

            var parameterMatch = parameterRegex.Match(currentToken);

            if (!parameterMatch.Success)
            {
               throw  new InvalidOperationException($"Route parameter in {currentToken} is not valid.");
               continue;
            }

            var match = parameterMatch.Value;
            var parameter = match.Substring(1, match.Length - 2);

            parameters.Add(parameter);

            var currentTokenWithoutCurlyBrackets = currentToken.Substring(1, currentToken.Length - 2);

            result.Append($"{currentTokenWithoutCurlyBrackets}{end}");
         }
      }
   }
}
