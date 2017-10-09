namespace HTTPMiniServer.Application.Controllers
{
   using Views.Home;
   using Server.Enums;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;

   public class HomeController
    {
       public IHttpResponse Index()
       { 
         return  new ViewResponse(HttpStatusCode.Ok,new IndexView());
       }
    }
}
