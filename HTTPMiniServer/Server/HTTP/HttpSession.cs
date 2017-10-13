namespace HTTPMiniServer.Server.HTTP
{
   using Contracts;

   public class HttpSession: IHttpSesion 
   {
      public string Id { get; private set; }


      public HttpSession(string id)
      {
         this.Id = id;
      }

      public object Get(string key)
      {
         throw new System.NotImplementedException();
      }

      public void Add(string key, object value)
      {
         throw new System.NotImplementedException();
      }

      public void Clear()
      {
         throw new System.NotImplementedException();
      }
   }
}
