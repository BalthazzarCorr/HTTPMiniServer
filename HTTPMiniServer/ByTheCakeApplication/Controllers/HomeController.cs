namespace HTTPMiniServer.ByTheCakeApplication.Controllers
{
   using Server.Enums;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;
   using Views.Home;

   public class HomeController
   {
      public IHttpResponse Index()
      {
         return new ViewResponse(HttpStatusCode.Ok,new IndexView("Test"));
      }
   }
}
