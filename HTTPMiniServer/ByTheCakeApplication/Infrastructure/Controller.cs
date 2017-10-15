using System.Linq;

namespace HTTPMiniServer.ByTheCakeApplication.Infrastructure
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using Server.Enums;
   using Server.HTTP.Contracts;
   using Server.HTTP.Response;
   using Views.Home;

   public abstract class Controller
   {

      public const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
      public const string ContentPlaceholder = "{{{content}}}";

      public IHttpResponse FileViewResponse(string fileName)
      {
         var result = this.ProcessFileHtml(fileName);

         return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
      }

      public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
      {
         var result = this.ProcessFileHtml(fileName);

         if (values!= null && values.Any())
         {
            foreach (var value in values)
            {
               result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
            }
         }

         return new ViewResponse(HttpStatusCode.Ok,new FileView(result));
      }

      private string ProcessFileHtml(string fileName)
      {
         var layoutHtml = File.ReadAllText(String.Format(DefaultPath, "layout"));

         var fileHtml = File.ReadAllText(String.Format(DefaultPath, fileName));


         var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);


         return result;
      }
   }
}
