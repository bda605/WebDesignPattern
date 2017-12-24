using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHAP3.Service;
namespace CHAP3.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private Service.ProductService _productService;
        public ProductListPresenter(IProductListView ProductListView, ProductService ProductService)
        {
            _productService = ProductService;
            _productListView = ProductListView;
        }

        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest();
            productListRequest.CustomerType = _productListView.CustomerType;
            ProductListResponse productListResponse = _productService.GetAllProductsFor(productListRequest);
            if (productListResponse.Success)
            {
                _productListView.Display(productListResponse.Products);
            }
            else
            {
                _productListView.ErrorMessage = productListResponse.Message;
            }
        }
    }
}
