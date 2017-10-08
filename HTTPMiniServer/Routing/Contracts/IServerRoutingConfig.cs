namespace HTTPMiniServer.Routing.Contracts
{
   using System.Collections.Generic;
   using Server.Enums;

   public interface IServerRoutingConfig
   {
      IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
   }
}
