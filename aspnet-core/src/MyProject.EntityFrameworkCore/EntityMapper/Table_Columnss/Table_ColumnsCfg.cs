

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.TableColumns;

namespace MyProject.EntityMapper.Table_Columnss
{
    public class Table_ColumnsCfg : IEntityTypeConfiguration<Table_Columns>
    {
        public void Configure(EntityTypeBuilder<Table_Columns> builder)
        {


            //   builder.ToTable("Table_Columnss", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("Table_Columnss");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


