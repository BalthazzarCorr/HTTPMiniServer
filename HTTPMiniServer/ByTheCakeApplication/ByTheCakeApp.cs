﻿namespace HTTPMiniServer.ByTheCakeApplication
{
   using Controllers;
   using Routing.Contracts;
   using Server.Contracts;



   public class ByTheCakeApp:IApplication
   {
      public void Configure(IAppRouteConfig appRouteConfig)
      {
         appRouteConfig
            .Get("/", req => new HomeController().Index());

         appRouteConfig
            .Get("/about" , req => new HomeController().About());

         appRouteConfig
            .Get("/add",req => new CakesController().Add());

         appRouteConfig
            .Post("/add",req => new CakesController().Add(req.FormData["name"],req.FormData["price"]));

         appRouteConfig
            .Get("/search", req => new CakesController().Search(req.UrlParameters));

         appRouteConfig
            .Get("/calculator",req => new CalculatorController().Add());

         appRouteConfig
            .Post("/calculator",req => new CalculatorController().ParseInputFromFormData(req.FormData["firstDigit"],req.FormData["operand"],req.FormData["secondDigit"]));
        
      }
   }
}
