

namespace HTTPMiniServer.Server.HTTP.Response
{
   using Server.Contracts;

   public abstract class HttpResponse
   {
      private readonly IView view;

      protected HttpResponse(string redirectUrl)
      {

      }

     
   }
}
