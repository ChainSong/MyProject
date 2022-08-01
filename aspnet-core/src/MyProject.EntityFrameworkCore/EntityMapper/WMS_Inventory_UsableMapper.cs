using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.InventoryCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_Inventory_UsableMapper : IEntityTypeConfiguration<WMS_Inventory_Usable>
    {
        public void Configure(EntityTypeBuilder<WMS_Inventory_Usable> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Inventory_Usable");
        }
    }
}