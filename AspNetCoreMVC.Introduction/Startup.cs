using AspNetCoreMVC.Introduction.Models;
using AspNetCoreMVC.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Introduction
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddConnections();
            services.AddDbContext<SchoolContext>(options =>
              options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDb;Trusted_Connection=true"));
          
            services.AddMvc()
                     .AddControllersAsServices();
            services.AddControllers().AddControllersAsServices();
            services.AddTransient<ICalculator, Calculator18>();

            services.AddSession();
            services.AddDistributedMemoryCache();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSession();

            //app.UseStaticFiles(new StaticFileOptions
            //{ 
            //FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"lib")),
            //RequestPath="/lib"
            //});

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=home}/{action=index}/{id?}");
            //});

            app.UseMvc(ConfigureRoutes);
           
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Filter}/{action=Index}/{id?}");
            routeBuilder.MapRoute("MyRoute", "Engin/{controller=Home}/{action=Index3}/{id?}");


            routeBuilder.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

        }
    }
}

