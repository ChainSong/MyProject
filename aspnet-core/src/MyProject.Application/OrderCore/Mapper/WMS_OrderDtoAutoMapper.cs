
using AutoMapper;
using MyProject.OrderCore;
using MyProject.OrderCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_OrderDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_OrderDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Order,WMS_OrderListDto>();
            configuration.CreateMap <WMS_OrderListDto,WMS_Order>();

            configuration.CreateMap <WMS_OrderEditDto,WMS_Order>();
            configuration.CreateMap <WMS_Order,WMS_OrderEditDto>();
					
        }
	}
}