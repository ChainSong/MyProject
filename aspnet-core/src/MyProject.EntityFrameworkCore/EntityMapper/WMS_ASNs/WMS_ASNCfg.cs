

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ASNCore;

namespace MyProject.EntityMapper.WMS_ASNs
{
    public class WMS_ASNCfg : IEntityTypeConfiguration<WMS_ASN>
    {
        public void Configure(EntityTypeBuilder<WMS_ASN> builder)
        {


            //   builder.ToTable("WMS_ASNs", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("WMS_ASNs");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


