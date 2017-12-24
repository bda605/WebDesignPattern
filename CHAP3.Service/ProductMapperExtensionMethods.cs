using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAP3.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Model.Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Model.Product p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }
            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(this Model.Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.RRP = string.Format("{0:C}", product.Price.RRP);
            productViewModel.SellingPrice = string.Format("{0:C}", product.Price.Discount);
            if (product.Price.Discount > 0)
                productViewModel.Discount = string.Format("{0:C}", product.Price.Discount);

            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString("#%");

            return productViewModel;
        }
    }
}
