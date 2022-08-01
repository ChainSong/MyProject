
using AutoMapper;
using MyProject.TableColumns;
using MyProject.TableColumns.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Table_Columns的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// Table_ColumnsDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class Table_ColumnsDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Table_Columns,Table_ColumnsListDto>();
            configuration.CreateMap <Table_ColumnsListDto,Table_Columns>();

            configuration.CreateMap <Table_ColumnsEditDto,Table_Columns>();
            configuration.CreateMap <Table_Columns,Table_ColumnsEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
