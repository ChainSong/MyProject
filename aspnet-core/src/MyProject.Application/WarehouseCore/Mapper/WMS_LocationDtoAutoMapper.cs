
using AutoMapper;
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_LocationDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_LocationDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Location,WMS_LocationListDto>();
            configuration.CreateMap <WMS_LocationListDto,WMS_Location>();

            configuration.CreateMap <WMS_LocationEditDto,WMS_Location>();
            configuration.CreateMap <WMS_Location,WMS_LocationEditDto>();
					
        }
	}
}