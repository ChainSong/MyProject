using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class CustomerUserMappingMapper : IEntityTypeConfiguration<CustomerUserMapping>
    {
        public void Configure(EntityTypeBuilder<CustomerUserMapping> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "CustomerUserMappings");
        }
    }
}