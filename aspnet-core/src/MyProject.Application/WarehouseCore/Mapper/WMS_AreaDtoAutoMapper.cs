
using AutoMapper;
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_AreaDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_AreaDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Area,WMS_AreaListDto>();
            configuration.CreateMap <WMS_AreaListDto,WMS_Area>();

            configuration.CreateMap <WMS_AreaEditDto,WMS_Area>();
            configuration.CreateMap <WMS_Area,WMS_AreaEditDto>();
					
        }
	}
}