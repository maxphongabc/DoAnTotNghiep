using caothang.Areas.API.Model;
using caothang.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly DPContext _context;
        public UserAPIController(DPContext context)
        {
            _context = context;
        }    

        [HttpPost("Login")]
        public async Task<ActionResult<bool>>Login(Login val)
        {
            var r = _context.user.Where(m => (m.UserName == val.UserName && m.PassWord == val.PassWord)).ToList();
            if(r.Count==0)
            {
                return false;
            } 
            else
            {
                if(r[0].RolesId==1)
                {
                    var str = JsonConvert.SerializeObject(val);
                    HttpContext.Session.SetString("user", str);
                    var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "Admin" });
                    return Redirect(urlAdmin);
                }
                else
                {
                    var str = JsonConvert.SerializeObject(val);
                    HttpContext.Session.SetString("user", str);

                    var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                    return Redirect(urlAdmin);

                }
            }    
        }

    }
}
