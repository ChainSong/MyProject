
using AutoMapper;
using MyProject.ASNCore;
using MyProject.ASNCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WMS_ASNDetail的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ASNDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_ASNDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_ASNDetail,WMS_ASNDetailListDto>();
            configuration.CreateMap <WMS_ASNDetailListDto,WMS_ASNDetail>();

            configuration.CreateMap <WMS_ASNDetailEditDto,WMS_ASNDetail>();
            configuration.CreateMap <WMS_ASNDetail,WMS_ASNDetailEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
