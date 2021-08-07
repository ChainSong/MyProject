

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.WarehouseCore;

namespace MyProject.EntityMapper.WarehouseUserMappings
{
    public class WarehouseUserMappingCfg : IEntityTypeConfiguration<WarehouseUserMapping>
    {
        public void Configure(EntityTypeBuilder<WarehouseUserMapping> builder)
        {


            //   builder.ToTable("WarehouseUserMappings", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("WarehouseUserMappings");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


