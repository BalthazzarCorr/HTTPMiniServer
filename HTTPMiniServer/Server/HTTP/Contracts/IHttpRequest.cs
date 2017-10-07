﻿namespace HTTPMiniServer.Server.HTTP.Contracts
{

   using System.Collections.Generic;
   using HTTPMiniServer.Server.Enums;


   public interface IHttpRequest
   {
      IDictionary<string, string> FromData { get; set; }

      HttpHeaderCollection Headers { get; }

      string Path { get; }

      IDictionary<string, string> QueryParameters { get; }

      HttpRequestMethod Method { get; }

      string Url { get; }

      IDictionary<string, string> UrlParameters { get; }

      void AddUrlParameter(string key, string value);


   }
}
