

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ASNCode;

namespace MyProject.EntityMapper.WMS_ASNDetails
{
    public class WMS_ASNDetailCfg : IEntityTypeConfiguration<WMS_ASNDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_ASNDetail> builder)
        {


            //   builder.ToTable("WMS_ASNDetails", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("WMS_ASNDetails");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


