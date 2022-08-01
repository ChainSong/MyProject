
using AutoMapper;
using MyProject.PreOrderCore;
using MyProject.PreOrderCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_PreOrderDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_PreOrderDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_PreOrder,WMS_PreOrderListDto>();
            configuration.CreateMap <WMS_PreOrderListDto,WMS_PreOrder>();

            configuration.CreateMap <WMS_PreOrderEditDto,WMS_PreOrder>();
            configuration.CreateMap <WMS_PreOrder,WMS_PreOrderEditDto>();
					
        }
	}
}