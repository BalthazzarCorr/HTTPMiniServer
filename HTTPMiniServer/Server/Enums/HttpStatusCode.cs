namespace HTTPMiniServer.Server.Enums
{
   public enum HttpStatusCode
   {
      Ok = 200,
      MovedPermanetly = 301,
      Found = 302,
      MovedTemporary = 303,
      BadRequest = 400,
      NotAuthorized = 401,
      NotFound = 404,
      InternerServerError = 500
   }
}
