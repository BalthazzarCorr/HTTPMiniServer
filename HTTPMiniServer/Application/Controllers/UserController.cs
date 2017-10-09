using System;

namespace HTTPMiniServer.Application.Controllers
{
   using Views.Register;
   using Server.Enums;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;

   public class UserController 
    {
       public IHttpResponse RegisterGet()
       {
         return new ViewResponse(HttpStatusCode.Ok,new RegisterView());
       }

       public IHttpResponse RegisterPost(string name)
       {
        
         return new RedirectResponse($"/user/{name}");
       }
    }
}
