using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.OrderCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_OrderAllocationMapper : IEntityTypeConfiguration<WMS_OrderAllocation>
    {
        public void Configure(EntityTypeBuilder<WMS_OrderAllocation> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_OrderAllocations");
        }
    }
}