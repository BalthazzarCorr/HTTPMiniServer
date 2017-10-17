namespace HTTPMiniServer.ByTheCakeApplication.Controllers
{
   using System;
   using System.Collections.Generic;
   using Infrastructure;
   using Server.HTTP.Contracts;


   public class CalculatorController : Controller
   {

      public IHttpResponse Add() => this.FileViewResponse(@"calculator\calculator", new Dictionary<string, string>
      {
         ["showResults"] = "none"
      });

      public IHttpResponse ParseInputFromFormData(string firstDigit, string operand, string secondDigit)
      {
         var multiplication = "*";
         var dividion = "/";
         var sum = "+";
         var subtraction = "-";

         var result = 0.0m;
         var parsedFirstDigit = decimal.Parse(firstDigit);
         var parsedSecondDigit = decimal.Parse(secondDigit);


         if (operand != dividion && operand != multiplication && operand != sum && operand != subtraction)
         {

            throw new InvalidOperationException();

         }
         switch (operand)
         {
            case "*":
               result = parsedFirstDigit * parsedSecondDigit;
               break;
            case "/":
               result = parsedFirstDigit / parsedSecondDigit;
               break;
            case "+":
               result = parsedFirstDigit + parsedSecondDigit;
               break;
            case "-":
               result = parsedFirstDigit - parsedSecondDigit;
               break;
         }

         return this.FileViewResponse(@"calculator\calculator", new Dictionary<string, string>
         {
            ["result"] = result.ToString()
         });


      }
   }
}
