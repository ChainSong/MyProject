

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptCore;

namespace MyProject.EntityMapper.WMS_ReceiptDetails
{
    public class WMS_ReceiptDetailCfg : IEntityTypeConfiguration<WMS_ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_ReceiptDetail> builder)
        {

			 
      //   builder.ToTable("WMS_ReceiptDetails", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("WMS_ReceiptDetails");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


