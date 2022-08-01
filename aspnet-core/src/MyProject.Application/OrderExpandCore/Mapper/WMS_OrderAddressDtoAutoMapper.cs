
using AutoMapper;
using MyProject.OrderExpandCore;
using MyProject.OrderExpandCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_OrderAddressDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_OrderAddressDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_OrderAddress,WMS_OrderAddressListDto>();
            configuration.CreateMap <WMS_OrderAddressListDto,WMS_OrderAddress>();

            configuration.CreateMap <WMS_OrderAddressEditDto,WMS_OrderAddress>();
            configuration.CreateMap <WMS_OrderAddress,WMS_OrderAddressEditDto>();
					
        }
	}
}