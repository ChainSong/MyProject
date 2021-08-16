

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptCore;

namespace MyProject.EntityMapper.WMS_Receipts
{
    public class WMS_ReceiptCfg : IEntityTypeConfiguration<WMS_Receipt>
    {
        public void Configure(EntityTypeBuilder<WMS_Receipt> builder)
        {

			 
      //   builder.ToTable("WMS_Receipts", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("WMS_Receipts");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


