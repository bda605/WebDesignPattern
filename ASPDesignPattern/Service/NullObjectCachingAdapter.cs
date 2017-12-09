using ASPDesignPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDesignPattern.Service
{
    public class NullObjectCachingAdapter:ICacheStoreage
    {
        public void Remove(string key)
        {

        }
        public void Store(string key, object data)
        {

        }
        public T Retrieve<T>(string StoreageKey)
        {
            return default(T);
        }
    }
}