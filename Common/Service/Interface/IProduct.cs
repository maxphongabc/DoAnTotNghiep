using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IProduct
    {
        List<ProductModel> ListRelatedProduct(int id);
    }
}
