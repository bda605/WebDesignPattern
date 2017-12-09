using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDesignPattern.Model.Interface
{
    public interface IProductRepository
    {
        IList<Product> GetAllProductsIn(int categoryId);
    }
}