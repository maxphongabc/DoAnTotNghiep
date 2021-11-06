using Common.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class UserModel 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Quyền người dùng là bắt buộc")]
        public int RolesId { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }
        [Display(Name = "Địa chỉ ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "SĐT")]
        [Required(ErrorMessage = "SĐT không đúng!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                  ErrorMessage = "Không đúng số nhà mạng.")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng")]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avarta { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
        [Required(ErrorMessage = "Không được để trống tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được để trống mật khẩu")]
        public string PassWord { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool Status { get; set; }
        public RolesModel roles { get; set; }
        public ICollection<OrderModel> orders { get; set; }
        public ICollection<BlogModel> blogs { get; set; }
        public ICollection<WishListModel> wishLists { get; set; }
        public ICollection<CommentProduct> commentProducts { get; set; }
    }
}
