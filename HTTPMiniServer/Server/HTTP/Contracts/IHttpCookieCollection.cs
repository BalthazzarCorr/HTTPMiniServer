﻿namespace HTTPMiniServer.Server.HTTP.Contracts
{
   using System.Collections.Generic;

   public interface IHttpCookieCollection : IEnumerable<HttpCookie>
   {

      void Add(HttpCookie cookies);

      void Add(string key, string value);

      bool ContainsKey(string key);

      HttpCookie Get(string key);
   }
}
