using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.PreOrderCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_PreOrderMapper : IEntityTypeConfiguration<WMS_PreOrder>
    {
        public void Configure(EntityTypeBuilder<WMS_PreOrder> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_PreOrder");
        }
    }
}