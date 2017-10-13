namespace HTTPMiniServer.Application.Controllers
{
   using Server.Enums;
   using Server.HTTP;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;
   using Views.Home;

   public class HomeController
    {
       public IHttpResponse Index()
       { 
         var response = new ViewResponse(HttpStatusCode.Ok, new IndexView());
         
         response.Cookies.Add(new HttpCookie("lang", "en"));

         return  response ;
       }
    }
}
