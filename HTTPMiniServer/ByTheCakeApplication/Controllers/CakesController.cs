namespace HTTPMiniServer.ByTheCakeApplication.Controllers
{
   using System.Collections.Generic;
   using System.IO;
   using Infrastructure;
   using Models;
   using Server.HTTP.Contracts;



   public class CakesController : Controller
   {
      private static List<Cake> cakes = new List<Cake>();

      public IHttpResponse Add() => this.FileViewResponse(@"cakes\add",new Dictionary<string, string>
      {
         ["showResults"] = "none"
      });

      public IHttpResponse Add(string name, string price)
      {

         var cake = new Cake
         {
            Name = name,
            Price = decimal.Parse(price)
         };

         cakes.Add(cake);

         using (var streaWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv",true))
         {
           streaWriter.WriteLine($"{name},{price}");
         }

         return this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
            {
               ["name"] = name,
               ["price"] = price,
               ["showResults"] = "block"
            }
         );
      }

   }
}
