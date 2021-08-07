
using AutoMapper;
using MyProject.ASNCore;
using MyProject.ASNCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WMS_ASN的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ASNDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_ASNDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_ASN,WMS_ASNListDto>();
            configuration.CreateMap <WMS_ASNListDto,WMS_ASN>();

            configuration.CreateMap <WMS_ASNEditDto,WMS_ASN>();
            configuration.CreateMap <WMS_ASN,WMS_ASNEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
