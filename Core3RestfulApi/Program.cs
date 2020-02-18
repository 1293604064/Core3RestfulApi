using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3RestfulApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core3RestfulApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //修改
            //CreateHostBuilder(args).Build().Run();
            var host= CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetService<RoutineDbContext>();
                    dbContext.Database.EnsureDeleted();   //删除原有的数据库
                    dbContext.Database.Migrate();     //重新加载数据库，进行数据迁移
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, message: "DateBase Migration Error!");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
