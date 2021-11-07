using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Service.Repository
{
    public class UserRepository:IUser
    {
        private readonly ProjectDPContext _context;
        public UserRepository(ProjectDPContext context)
        {
            _context = context;
        }
        public List<UserViewModel> ListUserAdmin()
        {
            var user = (from u in _context.user
                        join r in _context.roles on u.RolesId equals r.Id
                        select new UserViewModel
                        {
                            UserId = u.Id,
                            RolesId = r.Id,
                            Email= u.Email,
                            UserName = u.UserName,
                            FullName = u.FullName,
                            RoleName = r.Name,
                            Phone = u.Phone,
                            UserImage = u.Avarta,
                            Address = u.Address,
                            StatusUser = u.Status,
                            CreateOn = u.CreatedOn
                        });
            return user.ToList();
        }
        public UserViewModel ProfileUser(int id)
        {
            var user = (from u in _context.user
                        join r in _context.roles on u.RolesId equals r.Id
                        where u.Id == id
                        select new UserViewModel
                        {
                            FullName = u.FullName,
                            UserName = u.UserName,
                            Phone = u.Phone,
                            Address = u.Address,
                            UserImage = u.Avarta,
                            Email = u.Email,
                            PassWord =Encryptor.Encryptor.MD5Hash(u.PassWord),
                            CreateOn=u.CreatedOn
                        }).FirstOrDefault();
            return user;
        }
        public List<string> ListName(string keyword)
        {
            return _context.user.Where(x => x.FullName.Contains(keyword)).Select(x => x.FullName).ToList();
        }
        public bool CheckUserName(string userName)
        {
            return _context.user.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return _context.user.Count(x => x.Email == email) > 0;
        }
        public bool CheckPhone(string phone)
        {
            return _context.user.Count(x => x.Phone == phone) > 0;
        }
        public int Insert(UserModel user)
        {
            _context.Add(user);
             _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
