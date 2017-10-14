using System;
using HTTPMiniServer.Application.Views;

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

       public IHttpResponse SessionTest(IHttpRequest req)
       {
          var session = req.Session;

          const string sessionDateKey = "saved_date";

          if (session.Get(sessionDateKey) == null)
          {
             session.Add(sessionDateKey, DateTime.UtcNow);
          }

          return new ViewResponse(
             HttpStatusCode.Ok,
             new SessionTestView(session.Get<DateTime>(sessionDateKey)));
       }
   }
}
