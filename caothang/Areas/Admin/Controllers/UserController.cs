using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using caothang.Models;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly DPContext _context;

        public UserController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/User
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.user.Include(u => u.roles);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .Include(u => u.roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            ViewData["RolesId"] = new SelectList(_context.roles.Where(s=>s.Status==true), "Id", "Name");
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserModel userModel,IFormFile ful)
        {
            userModel.Status = true;
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                string path = Path.Combine(
                  Directory.GetCurrentDirectory(), "wwwroot/img/user",
                  +userModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                userModel.Avarta = userModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                userModel = new UserModel()
                {
                    RolesId=userModel.RolesId,
                    FullName=userModel.FullName,
                    Address= userModel.Address,
                    Phone= userModel.Phone,
                    Email= userModel.Email,
                    DateOfBirth= userModel.DateOfBirth,
                    Avarta= userModel.Avarta,
                    UserName=userModel.UserName,
                    PassWord= userModel.PassWord,
                    CreatedOn=DateTime.Now
                };
                await _context.user.AddAsync(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolesId"] = new SelectList(_context.roles.Where(s=>s.Status==true), "Id", "Name", userModel.RolesId);
            return View(userModel);
        }

        // GET: Admin/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Id", userModel.RolesId);
            return View(userModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RolesId,FullName,Address,Phone,Email,DateOfBirth,Avarta,UserName,PassWord,CreatedOn,UpdatedOn,Status")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Id", userModel.RolesId);
            return View(userModel);
        }

        // GET: Admin/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .Include(u => u.roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.user.FindAsync(id);
            _context.user.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel member)
        {
            if (member.UserName != null && member.PassWord != null)
            {
                member.PassWord = Encryptor.Encryptor.Decrypt(member.PassWord);
                var r = _context.user.Where(m => m.UserName == member.UserName && m.PassWord == (member.PassWord)).ToList();               
                if (r.Count == 0)
                {
                    return View("Login");
                }
                else
                {
                    if (r[0].RolesId == 1)
                    {
                        var str = JsonConvert.SerializeObject(r[0]);
                        HttpContext.Session.SetString("user", str);
                        
                        var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "Admin" });
                        return Redirect(urlAdmin);
                    }
                    else
                    {
                        var str = JsonConvert.SerializeObject(r[0]);
                        HttpContext.Session.SetString("user", str);
                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                        return Redirect(urlAdmin);

                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        private bool UserModelExists(int id)
        {
            return _context.user.Any(e => e.Id == id);
        }
    }
}
