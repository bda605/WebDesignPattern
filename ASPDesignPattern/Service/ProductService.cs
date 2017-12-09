using ASPDesignPattern.Model;
using ASPDesignPattern.Model.Interface;
using ASPDesignPattern.Model.Repository;
using ASPDesignPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDesignPattern.Service
{
    public class ProductService
    {
        //private ProductRepository _productRepository;
        //public ProductService()
        //{
        //    _productRepository = new ProductRepository();
        //}

        //public IList<Product> GetAllProductsIn(int categoryId)
        //{
        //    IList<Product> products;
        //    string storageKey = string.Format("products_in_cagegorry_id_{0}", categoryId);
        //    products = (List<Product>)HttpContext.Current.Cache.Get(storageKey);
        //    if (products == null)
        //    {
        //        products = _productRepository.GetAllProductsIn(categoryId);
        //        HttpContext.Current.Cache.Insert(storageKey, products);
        //    }
        //    return products;
        //}

        private IProductRepository _productRepository;
        private ICacheStoreage  _cacheStoreage;
        public ProductService(IProductRepository productRepository,
                              ICacheStoreage cacheStoreage)
        {
            _productRepository = productRepository;
            _cacheStoreage = cacheStoreage;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            string storageKey = string.Format("products_in_cagegorry_id_{0}", categoryId);
            products = (List<Product>)HttpContext.Current.Cache.Get(storageKey);
            if (products == null)
            {
                products = _productRepository.GetAllProductsIn(categoryId);
                _cacheStoreage.Store(storageKey, products);
            }
            return products;
        }
    }
}