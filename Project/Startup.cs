using Common.Data;
using Common.Service.Interface;
using Common.Service.Repository;
using Common.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Project
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IBlog, BlogRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IWishList, WishListRepository>();
            services.AddTransient<ISendMailService, SendMailService>();
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddDbContext<ProjectDPContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjectDPContext")));
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });
            services.AddOptions();                                         // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);                // đăng ký để Inject


            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/account/dang-nhap-tu-google";
            //    })
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "846805682596-r2610qkh5e0ln6olk5b5sk8bes0k0do3.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //        options.CallbackPath = "/dang-nhap-tu-google";
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
               name: "MyArea",
               areaName: "Admin",
               pattern: "Admin/{controller=HomeAdmin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapGet("/admin/testmail", async context =>
                {

                    // Lấy dịch vụ sendmailservice
                    var sendmailservice = context.RequestServices.GetService<ISendMailService>();
                    var mailContent = new MailContent();
                    {
                        mailContent.To = "0306181149@caothang.edu.vn";
                        mailContent.Subject = "Phụng ngu";
                        mailContent.Body = "<p>Ngu vcl</p>";
                    }
                    await sendmailservice.SendMail(mailContent);
                    await context.Response.WriteAsync("SendMail");

                });
            });

        }
    }
}
