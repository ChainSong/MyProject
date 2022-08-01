using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.InventoryCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_Inventory_UsedMapper : IEntityTypeConfiguration<WMS_Inventory_Used>
    {
        public void Configure(EntityTypeBuilder<WMS_Inventory_Used> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Inventory_Used");
        }
    }
}