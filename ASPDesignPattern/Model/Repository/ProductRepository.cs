using ASPDesignPattern.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDesignPattern.Model.Repository
{
    //public class ProductRepository
    //{
    //    //public IList<Product> GetAllProductsIn(int categoryId)
    //    //{
    //    //    IList<Product> products = new List<Product>();
    //    //    return products;
    //    //}
    //}
    public class ProductRepository:IProductRepository
    {
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products = new List<Product>();
            return products;
        }
    }
}