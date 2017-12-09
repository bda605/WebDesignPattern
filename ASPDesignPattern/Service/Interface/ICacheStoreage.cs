using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDesignPattern.Service.Interface
{
    public interface ICacheStoreage
    {
        void Remove(string key);
        void Store(string key, object data);

        T Retrieve<T>(string storeageKey);
    }
}