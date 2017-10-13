namespace HTTPMiniServer.Server.HTTP.Response
{
   using Enums;
   using Exceptions;
   using Server.Contracts;

   public class ViewResponse : HttpResponse
   {
      private readonly IView view;

      public ViewResponse(HttpStatusCode statsuCode, IView view)

      {
         this.ValidateStatusCode(statsuCode);

         this.view = view;
         this.StatusCode = statsuCode;
         this.Headers.Add(HttpHeader.ContentType , "text/html");
      }

      private void ValidateStatusCode(HttpStatusCode statsuCode)
      {
         var statusCodeNumber = (int)StatusCode;
         if (299 < statusCodeNumber && statusCodeNumber > 400)
         {
            throw new InvalidResponseException("View responses need a status code below 300 or above 400 (inclusive) ");
         }
      }

      public override string ToString()
      {
         return $"{base.ToString()} {this.view.View()}";
      }
   }
}
