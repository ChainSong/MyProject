

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptReceivingCore;

namespace MyProject.EntityMapper.WMS_ReceiptReceivings
{
    public class WMS_ReceiptReceivingCfg : IEntityTypeConfiguration<WMS_ReceiptReceiving>
    {
        public void Configure(EntityTypeBuilder<WMS_ReceiptReceiving> builder)
        {


            //   builder.ToTable("WMS_ReceiptReceivings", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("WMS_ReceiptReceivings");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


