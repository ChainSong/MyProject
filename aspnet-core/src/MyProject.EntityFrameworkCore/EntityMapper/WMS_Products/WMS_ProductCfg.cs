

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ProductCore;

namespace MyProject.EntityMapper.WMS_Products
{
    public class WMS_ProductCfg : IEntityTypeConfiguration<WMS_Product>
    {
        public void Configure(EntityTypeBuilder<WMS_Product> builder)
        {


            //   builder.ToTable("WMS_Products", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("WMS_Products");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


