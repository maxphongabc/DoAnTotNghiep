using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IUser
    {
        List<string> ListName(string keyword);
        bool Delete(int id);
    }
}
