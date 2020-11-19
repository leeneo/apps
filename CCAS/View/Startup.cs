using System;
using System.Text;
using CCAS.VModels;
using CCAS.VModels.Menus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CCAS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;//是否开启非必要Cookie检查，对应cookie声明时的CookieOptions.IsEssential (指示是否application必要的cookie,默认值false)
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = CookieSecurePolicy.SameAsRequest;
                options.OnAppendCookie = (appendCookieContext) =>
                {
                    appendCookieContext.IssueCookie = true;   //指示是否application必要的cookie,同CookieOptions.IsEssential
                };
                options.OnDeleteCookie = (context) =>
                {
                };
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
            });
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<WxSettings>(Configuration.GetSection("WxSettings"));
            services.Configure<WxMenus>(Configuration.GetSection("WxMenus"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            //app.UseHttpContextItemsMiddleware();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  //解决中文乱码的问题
            // loggerFactory.AddConsole();  //内置日志 已过时，需修改
            // loggerFactory.AddDebug();             //已过时，需修改
            //loggerFactory.AddProvider(new LoggerProvider("./log.txt"));   //自定义日志，怎样调用？
            NLog.LogManager.LoadConfiguration($@"{env.ContentRootPath}/Nlog.config");
        }
    }
}
