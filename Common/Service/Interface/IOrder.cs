using Common.ViewModel;
using System;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IOrder
    {
        List<OrderViewModel> ListOrder(int id);
        List<OrderViewModel> ListOrder_Details(int id);
    }
}
