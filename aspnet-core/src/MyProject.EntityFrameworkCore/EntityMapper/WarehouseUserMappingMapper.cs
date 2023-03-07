using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.WarehouseCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WarehouseUserMappingMapper : IEntityTypeConfiguration<WarehouseUserMapping>
    {
        public void Configure(EntityTypeBuilder<WarehouseUserMapping> builder)
        {
            builder.ToTable("Warehouse_User_Mapping");
        }
    }
}