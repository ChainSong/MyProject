using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.ProductCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_ProductMapper : IEntityTypeConfiguration<WMS_Product>
    {
        public void Configure(EntityTypeBuilder<WMS_Product> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_Products");
        }
    }
}