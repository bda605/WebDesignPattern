using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHAP3.Model;
using System.Data.Entity;
namespace CHAP3.Repository
{
    public class ProductRepository:IProductRepository
    {
        private ASPCHAP3Entities db = new ASPCHAP3Entities();
        public IList<Model.Product> FindAll()
        {

            var products = from p in db.Product
                           select new Model.Product
                           {
                               Id = p.ProductId,
                               Name = p.ProductName,
                               Price = new Model.Price(p.RRP, p.SellingPrice)
                           };
            return products.ToList();    
        }
    }
}
