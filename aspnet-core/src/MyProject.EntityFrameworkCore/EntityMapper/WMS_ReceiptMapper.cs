using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ReceiptCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ReceiptMapper : IEntityTypeConfiguration<WMS_Receipt>
    {
        public void Configure(EntityTypeBuilder<WMS_Receipt> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Receipts");
        }
    }
}