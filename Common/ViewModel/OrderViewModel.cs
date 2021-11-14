using System;

namespace Common.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Order_DetailId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Total { get; set; }
        public string ShipName { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }
        public int StatusOrder{ get; set; }
        public string ShipAdress { get; set; }
        public string Description { get; set; }
        public int Check { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TransactStatusId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string TransactStatusName { get; set; }
        //public bool StatusOrder { get; set; }
    }
}
