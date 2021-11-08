using Common.ViewModel;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IOrder
    {
        List<OrderViewModel> ListOrder(int id);
        List<OrderViewModel> ListOrderAdmin_True();
        List<OrderViewModel> ListOrderAdmin_False();
        List<OrderViewModel> ListOrder_Details(int id);
        OrderViewModel Details_Order(int id);
    }
}
