namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using HTTP.Contracts;

   public class GetHandler : RequestHandler
   {
      public GetHandler(Func<IHttpContext, IHttpResponse> handelingFunc) 
         : base(handelingFunc)
      {

      }
   }
}
