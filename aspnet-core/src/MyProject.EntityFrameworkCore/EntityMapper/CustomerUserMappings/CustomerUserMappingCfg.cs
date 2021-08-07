

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.CustomerCore;

namespace MyProject.EntityMapper.CustomerUserMappings
{
    public class CustomerUserMappingCfg : IEntityTypeConfiguration<CustomerUserMapping>
    {
        public void Configure(EntityTypeBuilder<CustomerUserMapping> builder)
        {

			 
      //   builder.ToTable("CustomerUserMappings", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("CustomerUserMappings");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


