using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.ASNCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.CustomerCore;
using MyProject.MultiTenancy;
using MyProject.TableColumns;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }

        public virtual DbSet<Table_Columns> Table_Columns { get; set; }

        public virtual DbSet<Table_ColumnsDetail> Table_ColumnsDetail { get; set; }

        public virtual DbSet<WMS_ASN> WMS_ASN { get; set; }

        public virtual DbSet<WMS_ASNDetail> WMS_ASNDetail { get; set; }


        public virtual DbSet<CustomerUserMapping> CustomerUserMapping { get; set; }


        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
            //Database.Log = msg => Debug.WriteLine(msg);
        }
        //输出到debug输出
        //public static readonly LoggerFactory LoggerFactory =
        //       new LoggerFactory(new[] { new DebugLoggerProvider((_, __) => true) });
        // 输出到Console
        //public static readonly LoggerFactory LoggerFactory =
        //       new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseLoggerFactory(LoggerFactory);
        //}
    }
}
