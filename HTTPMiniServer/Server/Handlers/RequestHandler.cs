namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using Common;
   using Contracts;
   using HTTP.Contracts;
   using HTTP;


   public  class RequestHandler : IRequestHandler
   {
      private readonly Func<IHttpContext, IHttpResponse> func;

      protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
      {
         this.func = func;
      }

      public IHttpResponse Handle(IHttpContext httpContext)
      {
         var response = this.func(httpContext.Request);

         if (!response.Headers.ContainsKey(HttpHeader.ContentType))
         {
            response.Headers.Add(HttpHeader.ContentType, "text/html");
         }


         return response;

      }

   }
}
