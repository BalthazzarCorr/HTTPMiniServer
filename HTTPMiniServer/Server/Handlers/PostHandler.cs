namespace HTTPMiniServer.Server.Handlers
{
   using System;
   using HTTP.Contracts;

   public class PostHandler : RequestHandler
   {

      public PostHandler(Func<IHttpRequest, IHttpResponse> handelingFunc) 
         : base(handelingFunc)
      {
         
      }
   }
}
