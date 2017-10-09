namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using Common;
   using Contracts;
   using HTTP.Contracts;
   using HTTP;


   public  class RequestHandler : IRequestHandler
   {
      private readonly Func<IHttpRequest, IHttpResponse> handelingFunc;

      protected RequestHandler(Func<IHttpRequest, IHttpResponse> handelingFunc)
      {
         CoreValidator.ThrowIfNull(handelingFunc, nameof(handelingFunc));

         this.handelingFunc = handelingFunc;
      }

      public IHttpResponse Handle(IHttpContext context)
      {
         var response = this.handelingFunc(context.Request);
         response.Headers.Add(new HttpHeader("Content-Type","text/plain"));

         return response;

      }

   }
}
