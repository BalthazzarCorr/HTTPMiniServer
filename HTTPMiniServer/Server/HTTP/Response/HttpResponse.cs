
using System.Text;
using HTTPMiniServer.Server.Common;

namespace HTTPMiniServer.Server.HTTP.Response
{
   using Enums;
   using Contracts;
   using Server.Contracts;
   public abstract class HttpResponse
   {

      private string statusCodeMessage => this.StatusCode.ToString();

      protected HttpResponse()
      {
         this.Headers = new HttpHeaderCollection();
      }


      public HttpHeaderCollection Headers { get; }
      public HttpStatusCode StatusCode { get; protected set; }


      public override string ToString()
      {
         var response = new StringBuilder();

         var statusCodeNumber = (int)this.StatusCode;

         response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");

         response.AppendLine(this.Headers.ToString());

        
         return response.ToString();
      }
   }
}
