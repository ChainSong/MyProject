using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.WarehouseCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_LocationMapper : IEntityTypeConfiguration<WMS_Location>
    {
        public void Configure(EntityTypeBuilder<WMS_Location> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Locations");
        }
    }
}