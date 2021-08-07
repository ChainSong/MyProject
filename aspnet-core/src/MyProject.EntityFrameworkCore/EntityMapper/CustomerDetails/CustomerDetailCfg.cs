

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;

namespace MyProject.EntityMapper.CustomerDetails
{
    public class CustomerDetailCfg : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {


            //   builder.ToTable("CustomerDetails", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("CustomerDetails");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


