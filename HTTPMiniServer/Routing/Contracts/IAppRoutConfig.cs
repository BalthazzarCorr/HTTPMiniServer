namespace HTTPMiniServer.Routing.Contracts
{
   using System.Collections.Generic;
   using Server.Enums;
   using Server.Handlers;



   public interface IAppRoutConfig
   {
      IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

      void AddRoute(string route, RequestHandler httpHandler);
   }
}
