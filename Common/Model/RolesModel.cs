﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserModel> user { get;set; }
        public bool Status { get; set; }
    }
}