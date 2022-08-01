using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.WarehouseCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_AreaMapper : IEntityTypeConfiguration<WMS_Area>
    {
        public void Configure(EntityTypeBuilder<WMS_Area> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Area");
        }
    }
}