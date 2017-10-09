﻿namespace HTTPMiniServer.Server.HTTP.Response
{

   using System.Text;
   using Contracts;
   using Enums;
   public abstract class HttpResponse :IHttpResponse
   {

      private string statusCodeMessage => this.StatusCode.ToString();

      protected HttpResponse()
      {
         this.Headers = new HttpHeaderCollection();
      }


      public IHttpHeaderCollection Headers { get; }
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
