using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
