﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class UserModel 
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avarta { get; set; }
        public string UserName { get; set; }
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
