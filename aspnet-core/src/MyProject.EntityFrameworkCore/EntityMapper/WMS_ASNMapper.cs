using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ASNCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ASNMapper : IEntityTypeConfiguration<WMS_ASN>
    {
        public void Configure(EntityTypeBuilder<WMS_ASN> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_ASN");
        }
    }
}