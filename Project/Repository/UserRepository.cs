using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UserRepository
    {
        private readonly DPContext _context;

        public UserRepository(DPContext context)
        {
            _context = context;
        }
        public bool CheckUserName(string userName)
        {
            return _context.user.Count(x => x.UserName == userName)>0;
        }
        public bool CheckMail(string mail)
        {
            return _context.user.Count(x => x.Email == mail) > 0;
        }
    }
}
