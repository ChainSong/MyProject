
using AutoMapper;
using MyProject.PreOrderCore;
using MyProject.PreOrderCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_PreOrderDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_PreOrderDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_PreOrderDetail,WMS_PreOrderDetailListDto>();
            configuration.CreateMap <WMS_PreOrderDetailListDto,WMS_PreOrderDetail>();

            configuration.CreateMap <WMS_PreOrderDetailEditDto,WMS_PreOrderDetail>();
            configuration.CreateMap <WMS_PreOrderDetail,WMS_PreOrderDetailEditDto>();
					
        }
	}
}