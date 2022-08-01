using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class CustomerDetailMapper : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "CustomerDetails");
        }
    }
}