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
                         join tr in _context.TransactStatuses on o.TransactStatusId equals tr.Id
                         where o.UserId == id
                         select new OrderViewModel { 
                            OrderId = o.Id,
                            UserId=u.Id,
                            CreatedOn = o.CreatedOn,
                            Total = o.Total,
                            TransactStatusId=o.TransactStatusId,
                            Description=o.Description,
                            TransactStatusName=tr.Name
                         });
            return order.ToList();
        }
        public OrderViewModel Details_Order(int id)
        {
            var order = (from o in _context.order
                         join od in _context.order_Details on o.Id equals od.OrderId
                         join tr in _context.TransactStatuses on o.TransactStatusId equals tr.Id
                         join p in _context.products on od.ProductId equals p.Id
                         join u in _context.user on o.UserId equals u.Id
                         where o.Id == id
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             ProductId = p.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             TransactStatusId = o.TransactStatusId,
                             TransactStatusName = tr.Name,
                             ShipEmail = o.ShipEmail,
                             ShipName = o.ShipName,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description,
                             Quantity = od.Quantity,
                             Price = od.Price
                         }).OrderByDescending(x => x.CreatedOn);
            return order.FirstOrDefault();
        }
        public List<OrderViewModel> ListOrderAdmin_1()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status==true && o.TransactStatusId==1
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress=o.ShipAdress,
                             ShipEmail=o.ShipEmail,
                             ShipName=o.ShipName,
                             ShipPhone=o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x=>x.CreatedOn);
            return order.ToList();
        }
        public List<OrderViewModel> ListOrderAdmin_2()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status == true && o.TransactStatusId==2
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             ShipEmail = o.ShipEmail,
                             ShipName = o.ShipName,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x => x.CreatedOn);
            return order.ToList();
        }    
        public List<OrderViewModel> ListOrderAdmin_3()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status == true && o.TransactStatusId == 3
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             ShipEmail = o.ShipEmail,
                             ShipName = o.ShipName,
                             ShipDateOn = o.ShipDateOn,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x => x.CreatedOn);
            return order.ToList();
        }
        public List<OrderViewModel> ListOrderAdmin_4()
        {
            var order = (from o in _context.order
                         join u in _context.user on o.UserId equals u.Id
                         where o.Status == true && o.TransactStatusId == 4
                         select new OrderViewModel
                         {
                             OrderId = o.Id,
                             UserId = u.Id,
                             CreatedOn = o.CreatedOn,
                             UserName = u.UserName,
                             Total = o.Total,
                             ShipAdress = o.ShipAdress,
                             ShipDateOn=o.ShipDateOn,
                             ShipEmail = o.ShipEmail,
                             ShipName = o.ShipName,
                             ShipPhone = o.ShipPhone,
                             Description = o.Description
                         }).OrderByDescending(x => x.CreatedOn);
            return order.ToList();
        }
        public List<OrderViewModel> ListOrder_Details(int id)
        {
            var order_details = (from od in _context.order_Details
                                 join p in _context.products on od.ProductId equals p.Id
                                 where od.OrderId == id 
                                 select new OrderViewModel
                                 {  
                                     Order_DetailId = od.Id,
                                     Price = od.Price,
                                     ProductImage=p.Image,
                                     Quantity = od.Quantity,
                                     CreatedOn = od.CreatedOn,
                                     ProductName = p.Name
                                 });
            return order_details.ToList();
        }
    }
}
