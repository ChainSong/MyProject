using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.PackageCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_PackageMapper : IEntityTypeConfiguration<WMS_Package>
    {
        public void Configure(EntityTypeBuilder<WMS_Package> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Packages");
        }
    }
}