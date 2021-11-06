using Common.ViewModel;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IOrder
    {
        List<OrderViewModel> ListOrder(int id);
        List<OrderViewModel> ListOrderAdmin();
        List<OrderViewModel> ListOrder_Details(int id);
    }
}
