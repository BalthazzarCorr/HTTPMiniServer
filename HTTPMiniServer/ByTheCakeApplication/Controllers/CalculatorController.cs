
namespace HTTPMiniServer.ByTheCakeApplication.Controllers
{
   using System.Collections.Generic;
   using Infrastructure;
   using Server.HTTP.Contracts;


   public class CalculatorController : Controller
   {

      public IHttpResponse Add() => this.FileViewResponse(@"calculator\calculator", new Dictionary<string, string>
      {
         ["showResults"] = "none"
      });

      public IHttpResponse ParseInputFromFormData(string firstDigit,string operand , string secondDigit)
      {
         return null;

      }
   }
}
