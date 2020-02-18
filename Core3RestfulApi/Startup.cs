using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3RestfulApi.Data;
using Core3RestfulApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core3RestfulApi
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
            services.AddControllers();  //接口开发只需要注入控制器
            //注入当前使用到的类
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            //注入当前使用到的dbcontext以及连接字符串
            services.AddDbContext<RoutineDbContext>(optionsAction: option =>
             {
                 option.UseSqlite(connectionString: "Data Source=routine.db");
             });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //配置请求管道
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
