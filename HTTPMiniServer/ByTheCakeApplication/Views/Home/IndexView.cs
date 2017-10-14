namespace HTTPMiniServer.ByTheCakeApplication.Views.Home
{

   using Server.Contracts;

   public class IndexView :IView
   {
      private readonly string htmlFile;

      public IndexView(string htmlFile)
      {
         this.htmlFile = htmlFile;
      }
      public string View()
      {
         throw new System.NotImplementedException();
      }
   }
}
