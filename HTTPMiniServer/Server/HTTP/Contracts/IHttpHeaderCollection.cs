using System;
using System.Collections.Generic;
using System.Text;

namespace HTTPMiniServer.Server.HTTP.Contracts
{
    interface IHttpHeaderCollection
    {
       void Add(HttpHeader header);

       bool ContainsKey(string key);

       HttpHeader Get(string key);
    }
}
