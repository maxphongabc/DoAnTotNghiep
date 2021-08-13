using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class CommonHelper
    {
        private IConfiguration _config;
        public CommonHelper(IConfiguration config)
        {
            _config = config;
        }
        //public bool UserAlreadyExists(string query)
        //{
        //    bool flag = false;
        //    string connenctionString = _config["ConnectionStrings:DefaultConnection"];
        //    using (SqlConnection connection = new SqlConnection(connenctionString))
        //    {
        //        connection.Open();
        //        string
        //    }
        //}
    }
}
