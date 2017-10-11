namespace HTTPMiniServer.Application.Views.User
{
   using Server.Contracts;
   using Server;
   
   public class UserDetailsView : IView
   {
      private readonly Model model;

      public UserDetailsView(Model model)
      {
         this.model = model;
      }

      public string View()
      {
         return $"<body>Hello, {model["name"]}!</body>";
      }
   }
}
