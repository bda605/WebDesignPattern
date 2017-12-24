using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAP3.Model
{
    public interface IProductRepository
    {
        IList<Product> FindAll();
    }
}
