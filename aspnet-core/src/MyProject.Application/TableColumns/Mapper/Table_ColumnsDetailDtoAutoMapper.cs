
using AutoMapper;
using MyProject.TableColumns;
using MyProject.TableColumns.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Table_ColumnsDetail的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// Table_ColumnsDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class Table_ColumnsDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Table_ColumnsDetail,Table_ColumnsDetailListDto>();
            configuration.CreateMap <Table_ColumnsDetailListDto,Table_ColumnsDetail>();

            configuration.CreateMap <Table_ColumnsDetailEditDto,Table_ColumnsDetail>();
            configuration.CreateMap <Table_ColumnsDetail,Table_ColumnsDetailEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
