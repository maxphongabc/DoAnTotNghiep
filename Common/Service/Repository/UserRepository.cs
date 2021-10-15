using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Repository
{
    public class UserRepository:IUser
    {
        private readonly ProjectDPContext _context = null;
        private readonly IConfiguration _iconfiguration;
        public UserRepository(ProjectDPContext context, IConfiguration configuration)
        {
            _context = context;
            _iconfiguration = configuration;
        }
        public List<string> ListName(string keyword)
        {
            return _context.user.Where(x => x.FullName.Contains(keyword)).Select(x => x.FullName).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = _context.user.Find(id);
                _context.user.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
       
    }
}
