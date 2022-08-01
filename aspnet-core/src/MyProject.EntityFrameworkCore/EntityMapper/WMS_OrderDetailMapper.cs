using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.OrderCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_OrderDetailMapper : IEntityTypeConfiguration<WMS_OrderDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_OrderDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_OrderDetail");
        }
    }
}