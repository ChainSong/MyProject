using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.OrderCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_OrderMapper : IEntityTypeConfiguration<WMS_Order>
    {
        public void Configure(EntityTypeBuilder<WMS_Order> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Orders");
        }
    }
}