namespace HTTPMiniServer.Routing
{
   using System.Collections.Generic;
   using Contracts;
   using Server.Common;
   using Server.Handlers;


   public class RoutingContext : IRoutingContext
   {
      public RoutingContext(RequestHandler handler, IEnumerable<string> paramaters)
      {
         CoreValidator.ThrowIfNull(handler, nameof(handler));
         CoreValidator.ThrowIfNull(paramaters, nameof(paramaters));

         this.Handler = handler;
         this.Parameters = paramaters;
      }

      public IEnumerable<string> Parameters { get; private set; }

      public RequestHandler Handler { get; private set; }
   }
}
