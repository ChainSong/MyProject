using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.PreOrderCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class WMS_PreOrderDetailMapper : IEntityTypeConfiguration<WMS_PreOrderDetail>
    {
        public void Configure(EntityTypeBuilder<WMS_PreOrderDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "WMS_PreOrderDetail");
        }
    }
}