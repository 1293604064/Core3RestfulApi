using Core3RestfulApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestfulApi.Data
{
    public class RoutineDbContext: DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options):base(options)
        { 
            
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 设置对类中的字段进行限制
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(x => x.Introduction).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Employee>().Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>().Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.LastName).IsRequired().HasMaxLength(50);

            //设置导航属性
            modelBuilder.Entity<Employee>()
                .HasOne(navigationExpression: x => x.Company)   //指明该外键的导航属性是company
                .WithMany(navigationExpression: x => x.Employee)   //反过来的导航属性是Employee
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);   //删除的时候如果下面有员工就不能删除

            //生成数据库并且给赋予初始值
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("ca76f5c6-37c8-4c4f-9451-b8d89a5c361c"),
                    Name="Micrsoft",
                    Introduction="Great commany"
                },
                new Company
                { 
                    Id=Guid.Parse("6e548740-e35b-4840-9179-a1428b96f701"),
                    Name="google",
                    Introduction="这是谷歌"
                },
                new Company
                { 
                    Id=Guid.Parse("8cecb07a-3b6d-4bb6-b5cb-b48388e3c528"),
                    Name="baidu",
                    Introduction="这是百度" 
                });
        }
    }
}
