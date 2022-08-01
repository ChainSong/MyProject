using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptReceivingCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ReceiptReceivingMapper : IEntityTypeConfiguration<WMS_ReceiptReceiving>
    {
        public void Configure(EntityTypeBuilder<WMS_ReceiptReceiving> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_ReceiptReceivings");
        }
    }
}