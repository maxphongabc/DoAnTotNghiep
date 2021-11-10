using Common.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public int RolesId { get; set; }
        public DateTime CreateOn { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "SĐT")]
        [Required(ErrorMessage = "SĐT không đúng!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Không đúng số nhà mạng.")]
        public string Phone { get; set; }
        public string Avarta { get; set; }

        public bool Status { get; set; }
    }
}
