

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;

namespace MyProject.EntityMapper.Customers
{
    public class CustomerCfg : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {


            //   builder.ToTable("Customers", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("Customers");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


