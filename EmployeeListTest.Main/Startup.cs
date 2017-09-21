using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeListTest.DAL;
using Microsoft.EntityFrameworkCore;
using EmployeeListTest.DAL.Repositories;
using EmployeeListTest.EF;
using EmployeeListTest.EF.Repositories;
using AutoMapper;

namespace EmployeeListTest_Main
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
            services.AddMvc();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            IMapper mapper = ConfigureMapper();
            // Add application services.
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddSingleton<IMapper>(mapper);
        }

        private IMapper ConfigureMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeListTest.DomainModel.Job, EmployeeListTest.Main.Models.JobModel>();
                cfg.CreateMap<EmployeeListTest.DomainModel.Employee, EmployeeListTest.Main.Models.EmployeeListModel>();
                cfg.CreateMap<EmployeeListTest.Main.Models.CreateEmployeeModel, EmployeeListTest.DomainModel.Employee>();
            });

            return config.CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EmployeeContext>().Initialize();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
