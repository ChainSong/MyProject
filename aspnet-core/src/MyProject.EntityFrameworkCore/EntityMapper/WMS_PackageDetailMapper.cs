using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.PackageCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_PackageDetailMapper : IEntityTypeConfiguration<WMS_PackageDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_PackageDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_PackageDetails");
        }
    }
}