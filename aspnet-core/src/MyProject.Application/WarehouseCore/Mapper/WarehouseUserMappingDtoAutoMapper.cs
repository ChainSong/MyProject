
using AutoMapper;
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WarehouseUserMapping的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WarehouseUserMappingDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WarehouseUserMappingDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WarehouseUserMapping,WarehouseUserMappingListDto>();
            configuration.CreateMap <WarehouseUserMappingListDto,WarehouseUserMapping>();

            configuration.CreateMap <WarehouseUserMappingEditDto,WarehouseUserMapping>();
            configuration.CreateMap <WarehouseUserMapping,WarehouseUserMappingEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
