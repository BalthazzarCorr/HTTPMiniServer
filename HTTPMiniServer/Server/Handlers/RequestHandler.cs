namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using Common;
   using Contracts;
   using HTTP.Contracts;
   using HTTP;


   public  class RequestHandler : IRequestHandler
   {
      private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

      public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
      {
         CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

         this.handlingFunc = handlingFunc;
      }
      public IHttpResponse Handle(IHttpContext httpContext)
      {
         var response = this.handlingFunc(httpContext.Request);

         if (!response.Headers.ContainsKey(HttpHeader.ContentType))
         {
            response.Headers.Add(HttpHeader.ContentType, "text/html");
         }

        


         return response;

      }

   }
}
