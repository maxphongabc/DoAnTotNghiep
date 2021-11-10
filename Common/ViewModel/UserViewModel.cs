using Common.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public int RolesId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
        public string UserImage { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool StatusUser { get; set; }
        public DateTime? CreateOn { get; set; }
    }
}
