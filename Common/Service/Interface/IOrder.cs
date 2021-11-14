using Common.ViewModel;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IOrder
    {
        List<OrderViewModel> ListOrder(int id);
        List<OrderViewModel> ListOrderAdmin_1();
        List<OrderViewModel> ListOrderAdmin_2();
        List<OrderViewModel> ListOrderAdmin_3();
        List<OrderViewModel> ListOrderAdmin_4();
        List<OrderViewModel> ListOrder_Details(int id);
        OrderViewModel Details_Order(int id);
    }
}
