using System;
using System.Linq;

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

      public IHttpResponse Add() => this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
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

         using (var streaWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv", true))
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

      public IHttpResponse Search(IDictionary<string, string> urlParameters)
      {
         const string searchTermKey = "searchTerm";

         var results = string.Empty;

         if (urlParameters.ContainsKey(searchTermKey))
         {
            var searchTerm = urlParameters[searchTermKey];

            var savedCakesDivs = File
               .ReadAllLines(@"ByTheCakeApplication\Data\database.csv")
               .Where(l=> l.Contains(','))
               .Select(l=> l.Split(','))
               .Select(l=> new Cake
                  {
                     Name = l[0],
                     Price = decimal.Parse(l[1])
                  })
                  .Where(c=>c.Name.ToLower()
                  .Contains(searchTerm.ToLower())).Select(c=> $"<div>{c.Name} - {c.Price}</div>");


            results = string.Join(Environment.NewLine, savedCakesDivs);
         }

         return this.FileViewResponse(@"cakes\search",new Dictionary<string, string>
         {
            ["results"]= results
         });

      }
   }
}
