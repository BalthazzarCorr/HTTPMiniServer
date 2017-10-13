using System;

namespace HTTPMiniServer.Server.HTTP
{
    public class HttpCookies
    {
       public HttpCookies(string key ,string value , int expires = 3 )
       {
          
       }


       public HttpCookies(string key, string value ,bool isNew, int expire = 3 )
       {
          
       }
       public string Key { get; private set; }

       public string Value { get; private set; }

       public DateTime Expires { get; private set; }

       public bool IsNew { get; private set; } = true;

       public override string ToString()
       {
         
       }
    }
}
