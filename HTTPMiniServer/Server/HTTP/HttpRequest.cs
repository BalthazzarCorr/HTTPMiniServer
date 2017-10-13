namespace HTTPMiniServer.Server.HTTP
{
   using System;
   using System.Collections.Generic;
   using Enums;
   using System.Linq;
   using System.Net;
   using Common;
   using Exceptions;

   using Contracts;

   public class HttpRequest : IHttpRequest
   {
      private const string BAD_REQUEST_EXCEPTION_MESSAGE = "Request is not valid";

      private readonly string requestText;

      public HttpRequest(string requestText)
      {
         CoreValidator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

         this.requestText = requestText;

         this.FormData = new Dictionary<string, string>();
         this.QueryParameters = new Dictionary<string, string>();
         this.UrlParameters = new Dictionary<string, string>();
         this.Headers = new HttpHeaderCollection();


         this.ParseRequest(requestText);
      }


      public IDictionary<string, string> FormData { get; set; }

      public IHttpHeaderCollection Headers { get; private set; }

      public string Path { get; private set; }

      public IDictionary<string, string> QueryParameters { get; private set; }

      public HttpRequestMethod Method { get; private set; }

      public string Url { get; private set; }

      public IDictionary<string, string> UrlParameters { get; private set; }



      public void AddUrlParameter(string key, string value)
      {
         CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
         CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

         this.UrlParameters[key] = value;
      }


      private void ParseRequest(string requestText)
      {
         var requestLines = requestText.Split(Environment.NewLine);

         if (!requestLines.Any())
         {
            BadRequestException.ThrowFromInvalidRequest();
         }
         var requestLine = requestLines.First().Split(new[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

         if (requestLine.Length != 3
             || requestLine[2].ToLower() != "http/1.1")
         {
            throw new BadRequestException(BAD_REQUEST_EXCEPTION_MESSAGE);
         }

         this.Method = this.ParseMethod(requestLine.First());
         this.Url = requestLine[1];
         this.Path = this.ParsePath(this.Url);

         this.ParseHeaders(requestLines);

         this.ParseParameters();


         this.ParseFormData(requestLines.Last());
      }



      private HttpRequestMethod ParseMethod(string method)
      {

         HttpRequestMethod parsedMethod;

         if (!Enum.TryParse(method, true, out parsedMethod))
         {
            BadRequestException.ThrowFromInvalidRequest();
         }

         return parsedMethod;

      }

      private string ParsePath(string url)
         => url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

      private void ParseHeaders(string[] requestLines)
      {
         var emptyLineAfterHeadersIndex = Array.IndexOf(requestLines, string.Empty);

         for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
         {
            var currentLine = requestLines[i];
            var headerParts = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

            if (headerParts.Length != 2)
            {
               BadRequestException.ThrowFromInvalidRequest();
            }

            var headerKey = headerParts[0];
            var headerValue = headerParts[1].Trim();
            var header = new HttpHeader(headerKey, headerValue);
            this.Headers.Add(header);
         }

         if (!this.Headers.ContainsKey(HttpHeader.Host))
         {
            throw new BadRequestException(BAD_REQUEST_EXCEPTION_MESSAGE);
         }
      }


      private void ParseParameters()
      {
         if (!this.Url.Contains('?'))
         {
            return;
         }

         var query = this.Url
            .Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
            .Last();


         this.ParseQuery(query, this.UrlParameters);

         if (!query.Contains('='))
         {
            return;
         }

         var queryParis = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

         foreach (var quertPair in queryParis)
         {
            var queryKvp = quertPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (queryKvp.Length != 2)
            {
               return;
            }

            var queryKey = WebUtility.UrlDecode(queryKvp[0]);
            var queryValue = WebUtility.UrlDecode(queryKvp[1]);

            this.AddUrlParameter(queryKey, queryValue);
         }
      }

      private void ParseFormData(string fromDataLine)
      {
         if (this.Method == HttpRequestMethod.Get)
         {
            return; ;
         }

         this.ParseQuery(fromDataLine, this.FormData);
      }

      private void ParseQuery(string query, IDictionary<string, string> dict)
      {
         if (!query.Contains('='))
         {
            return;
         }


         var queryParis = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

         foreach (var quertPair in queryParis)
         {
            var queryKvp = quertPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (queryKvp.Length != 2)
            {
               return;
            }

            var queryKey = WebUtility.UrlDecode(queryKvp[0]);
            var queryValue = WebUtility.UrlDecode(queryKvp[1]);

            dict.Add(queryKey, queryValue);
         }
      }

      public override string ToString() => this.requestText;
   }
}
