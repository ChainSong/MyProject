
using AutoMapper;
using MyProject.OrderCore;
using MyProject.OrderCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_OrderDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_OrderDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_OrderDetail,WMS_OrderDetailListDto>();
            configuration.CreateMap <WMS_OrderDetailListDto,WMS_OrderDetail>();

            configuration.CreateMap <WMS_OrderDetailEditDto,WMS_OrderDetail>();
            configuration.CreateMap <WMS_OrderDetail,WMS_OrderDetailEditDto>();
					
        }
	}
}