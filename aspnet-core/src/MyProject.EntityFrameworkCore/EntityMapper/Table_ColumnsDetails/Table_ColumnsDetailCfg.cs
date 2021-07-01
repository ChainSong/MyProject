

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.TableColumns;

namespace MyProject.EntityMapper.Table_ColumnsDetails
{
    public class Table_ColumnsDetailCfg : IEntityTypeConfiguration<Table_ColumnsDetail>
    {
        public void Configure(EntityTypeBuilder<Table_ColumnsDetail> builder)
        {


            //   builder.ToTable("Table_ColumnsDetails", YoYoAbpefCoreConsts.SchemaNames.CMS);
            builder.ToTable("Table_ColumnsDetails");

            //可以自定义配置参数内容

            //// custom codes



            //// custom codes end
        }
    }
}


