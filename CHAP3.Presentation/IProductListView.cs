using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHAP3.Service;
using CHAP3.Model;
namespace CHAP3.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> Products);
        CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}
