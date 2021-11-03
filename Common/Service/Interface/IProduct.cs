using Common.Model;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IProduct
    {
        List<ProductViewModel> ListAll();
        List<ProductModel> ListRelatedProduct(int id);
        ProductViewModel DetailProduct(string slug);
        List<ProductViewModel> ListProductCate(string slug);
        List<CommentProductViewModel> ListComment(int productId);
    }
}
