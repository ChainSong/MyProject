
using AutoMapper;
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_WarehouseDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_WarehouseDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Warehouse,WMS_WarehouseListDto>();
            configuration.CreateMap <WMS_WarehouseListDto,WMS_Warehouse>();

            configuration.CreateMap <WMS_WarehouseEditDto,WMS_Warehouse>();
            configuration.CreateMap <WMS_Warehouse,WMS_WarehouseEditDto>();
					
        }
	}
}