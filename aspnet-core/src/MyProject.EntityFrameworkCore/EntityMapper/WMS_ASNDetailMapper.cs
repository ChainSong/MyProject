using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ASNCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ASNDetailMapper : IEntityTypeConfiguration<WMS_ASNDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_ASNDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_ASNDetail");
        }
    }
}