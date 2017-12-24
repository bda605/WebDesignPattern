using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAP3.Service
{
    public  class ProductService
    {
        private Model.ProductService _productService;
        public ProductService(Model.ProductService ProductService)
        {
            _productService = ProductService;
        }
        public ProductListResponse GetAllProductsFor(ProductListRequest ProductListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();
            try
            {
                IList <Model.Product> productEntities = _productService.GetAllProductsFor(ProductListRequest.CustomerType);
                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                productListResponse.Success = false;
                productListResponse.Message = "Check that your database is in the correct place. Hint: Check the AttachDbFilename section within App.config in the project ASPPatterns.Chap3.Layered.Repository.";
            }
            catch (Exception ex) {
                productListResponse.Success = false;
                productListResponse.Message = "An error occured";
            }
            return productListResponse;
        }
    }
}
