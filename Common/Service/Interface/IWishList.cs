using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IWishList
    {
        List<ProductViewModel> ListAll(int id);
    }
}
