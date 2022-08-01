using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.WarehouseCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_WarehouseMapper : IEntityTypeConfiguration<WMS_Warehouse>
    {
        public void Configure(EntityTypeBuilder<WMS_Warehouse> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Warehouses");
        }
    }
}