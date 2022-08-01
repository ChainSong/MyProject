using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.OrderExpandCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_OrderAddressMapper : IEntityTypeConfiguration<WMS_OrderAddress>
    {
        public void Configure(EntityTypeBuilder<WMS_OrderAddress> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_OrderAddress");
        }
    }
}