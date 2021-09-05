

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.InventoryCore;

namespace MyProject.EntityMapper.WMS_Inventorys
{
    public class WMS_InventoryCfg : IEntityTypeConfiguration<WMS_Inventory>
    {
        public void Configure(EntityTypeBuilder<WMS_Inventory> builder)
        {

			 
      //   builder.ToTable("WMS_Inventorys", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("WMS_Inventorys");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


