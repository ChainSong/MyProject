using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;
using MyProject;

namespace MyProject.EntityFrameworkCore.EntityMapper
{
    public class CustomerMapper : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(AppCoreConst.SchemaNames.TABLE_PREFIX + "Customers");
        }
    }
}