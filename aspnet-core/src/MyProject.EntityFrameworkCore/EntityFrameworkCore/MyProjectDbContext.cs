using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.ASNCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.CustomerCore;
using MyProject.InventoryCore;
using MyProject.MultiTenancy;
using MyProject.OrderCore;
using MyProject.OrderExpandCore;
using MyProject.PackageCore;
using MyProject.PreOrderCore;
using MyProject.ProductCore;
using MyProject.ReceiptCore;
using MyProject.ReceiptReceivingCore;
using MyProject.TableColumns;
using MyProject.WarehouseCore;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        //public virtual DbSet<Customer_Func_Rule> Customer_Func_Rule { get; set; }
        //public virtual DbSet<Customer_User_Mapping> Customer_User_Mapping { get; set; }
        //public virtual DbSet<Warehouse_User_Mapping> Warehouse_User_Mapping { get; set; }
        public virtual DbSet<WMS_Area> WMS_Area { get; set; }
        public virtual DbSet<WMS_ASN> WMS_ASN { get; set; }
        public virtual DbSet<WMS_ASNDetail> WMS_ASNDetail { get; set; }
        public virtual DbSet<WMS_Inventory_Usable> WMS_Inventory_Usable { get; set; }
        public virtual DbSet<WMS_Inventory_Used> WMS_Inventory_Used { get; set; }
        public virtual DbSet<WMS_Location> WMS_Location { get; set; }
        public virtual DbSet<WMS_OrderAddress> WMS_OrderAddress { get; set; }
        public virtual DbSet<WMS_Package> WMS_Package { get; set; }
        public virtual DbSet<WMS_PackageDetail> WMS_PackageDetail { get; set; }
        public virtual DbSet<WMS_PreOrder> WMS_PreOrder { get; set; }
        public virtual DbSet<WMS_PreOrderDetail> WMS_PreOrderDetail { get; set; }
        public virtual DbSet<WMS_Product> WMS_Product { get; set; }
        public virtual DbSet<WMS_Receipt> WMS_Receipt { get; set; }
        public virtual DbSet<WMS_ReceiptDetail> WMS_ReceiptDetail { get; set; }
        public virtual DbSet<WMS_ReceiptReceiving> WMS_ReceiptReceiving { get; set; }
        public virtual DbSet<WMS_Warehouse> WMS_Warehouse { get; set; }
        public virtual DbSet<WMS_Order> WMS_Order { get; set; }
        public virtual DbSet<WMS_OrderDetail> WMS_OrderDetail { get; set; }




        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
            //modelBuilder.ApplyConfiguration(new WMS_ReceiptMapper());
            //base.OnModelCreating(modelBuilder);
            //Database.Log = msg => Debug.WriteLine(msg);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new SysTasksQzMapper());
        //    modelBuilder.ApplyConfiguration(new SysTasksLogMapper());

        //    base.OnModelCreating(modelBuilder);
        //}
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
