namespace HTTPMiniServer.Server.HTTP.Contracts
{
   public interface IHttpSesion
   {
      string Id { get; }

      object Get(string key);

      void Add(string key, object value);

      void Clear();



   }
}
