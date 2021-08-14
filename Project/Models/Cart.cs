using Common.Model;

namespace Project.Models
{
    public class Cart
    {
        public ProductModel Product { get; set; }
        public int Quanlity { get; set; }
        public int Total { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictID { get; set; }
    }
}
