using Common.Data;
using Common.Service.Interface;
using Common.ViewModel;
using System.Collections.Generic;
using System.Linq;


namespace Common.Service.Repository
{
    public class OrderRepository:IOrder
    {
        private readonly ProjectDPContext _context;
        public OrderRepository(ProjectDPContext context)
        {
            _context = context;
        }
        public List<OrderViewModel> ListOrder(int id)
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.UserId == id
                         select new OrderViewModel { 
                            OrderId = o.Id,
                            UserId=u.Id,
                            CreatedOn = o.CreatedOn,
                            Total = o.Total,
                            Description=o.Description,
                            StatusOrder=o.Status
                         });
            return order.ToList();
        }
        public OrderViewModel Details_Order(int id)
        {
            var order = (from o in _context.order
                         join od in _context.order_Details on o.Id equals od.OrderId
                         join p in _context.products on od.ProductId equals p.Id
                         join u in _context.user on o.UserId equals u.Id
                         where o.Id==id
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             ProductId = p.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             ShipEmail = o.ShipEmail,
                             StatusOrder = o.Status,
                             ShipName = o.ShipName,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description,
                             Quantity = od.Quantity,
                             Price = od.Price
                         }).OrderByDescending(x => x.CreatedOn);
            return order.FirstOrDefault();
        }
        public List<OrderViewModel> ListOrderAdmin_True()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status==true
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress=o.ShipAdress,
                             ShipEmail=o.ShipEmail,
                             StatusOrder = o.Status,
                             ShipName=o.ShipName,
                             ShipPhone=o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x=>x.CreatedOn);
            return order.ToList();
        }
        public List<OrderViewModel> ListOrderAdmin_False()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status == false
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             ShipEmail = o.ShipEmail,
                             StatusOrder = o.Status,
                             ShipName = o.ShipName,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x => x.CreatedOn);
            return order.ToList();
        }
        public List<OrderViewModel> ListOrder_Details(int id)
        {
            var order_details = (from od in _context.order_Details
                                 join o in _context.order on od.OrderId equals o.Id
                                 join p in _context.products on od.ProductId equals p.Id
                                 where od.OrderId == id 
                                 select new OrderViewModel
                                 {
                                     OrderId=o.Id,
                                     Price = od.Price,
                                     Quantity = od.Quantity,
                                     ShipAdress = o.ShipAdress,
                                     ShipEmail = o.ShipEmail,
                                     ProductImage=p.Image,
                                     ShipPhone = o.ShipPhone,
                                     ShipName = o.ShipName,
                                     Total = o.Total,
                                     CreatedOn = od.CreatedOn,
                                     Description = o.Description,
                                     ProductName = p.Name,
                                     StatusOrder_Detailsx=od.Status
                                 });
            return order_details.ToList();
        }
    }
}
