namespace HTTPMiniServer.ByTheCakeApplication.Infrastructure

{
   using System;
   using System.IO;
   using Server.Enums;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;
   using Views.Home;

   public abstract  class Controller
   {

      public const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
      public const string ContentPlaceholder = "{{{content}}}";

       public IHttpResponse FileViewResponse(string fileName)
       {
          var layoutHtml = File.ReadAllText(String.Format(DefaultPath,"layout"));

          var fileHtml = File.ReadAllText(String.Format(DefaultPath, fileName));


          var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

          return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
      }
    }
}
