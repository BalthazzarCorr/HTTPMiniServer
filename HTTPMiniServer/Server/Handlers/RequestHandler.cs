using HTTPMiniServer.Server.Common;

namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using Contracts;
   using HTTP;
   using HTTP.Contracts;


   public  class RequestHandler : IRequestHandler
   {
      private readonly Func<IHttpRequest, IHttpResponse> func;

      public RequestHandler(Func<IHttpRequest, IHttpResponse> func)
      {
         CoreValidator.ThrowIfNull(func,nameof(func));
         this.func = func;
      }

      public IHttpResponse Handle(IHttpContext httpContext)
      {
         var response = this.func(httpContext.Request);

         if (!response.Headers.ContainsKey(HttpHeader.ContentType))
         {
            response.Headers.Add(HttpHeader.ContentType, "text/html");
         }

         foreach (var cookie in response.Cookies)
         {
            response.Headers.Add(HttpHeader.SetCookie, cookie.ToString());
         }

         return response;

      }

   }
}
