namespace HTTPMiniServer.Server.HTTP.Response
{
   using Enums;
   public class NotFondResponse : HttpResponse
    {
       public NotFondResponse()
       {
          this.StatusCode = HttpStatusCode.NotFound;
       }
    }
}
