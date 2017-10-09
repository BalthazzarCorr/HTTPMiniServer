namespace HTTPMiniServer.Server.HTTP.Contracts
{
   using System.Collections.Generic;

   public interface IHttpHeaderCollection : IEnumerable<ICollection<HttpHeader>>
   {
      void Add(HttpHeader header);

      bool ContainsKey(string key);

      ICollection<HttpHeader> Get(string key);
   }
}
