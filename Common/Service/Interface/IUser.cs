using Common.Model;
using Common.ViewModel;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IUser
    {
        List<UserViewModel> ListUserAdmin();
        List<string> ListName(string keyword);
        UserViewModel ProfileUser(int id);
        bool CheckEmail(string email);
        bool CheckPhone(string phone);
        bool CheckUserName(string userName);
        int Insert(UserModel user);
    }
}
