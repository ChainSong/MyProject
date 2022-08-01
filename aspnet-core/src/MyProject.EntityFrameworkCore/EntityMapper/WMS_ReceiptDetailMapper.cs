using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ReceiptDetailMapper : IEntityTypeConfiguration<WMS_ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_ReceiptDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_ReceiptDetails");
        }
    }
}