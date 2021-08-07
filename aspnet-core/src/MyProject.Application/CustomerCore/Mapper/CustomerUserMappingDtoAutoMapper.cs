
using AutoMapper;
using MyProject.CustomerCore;
using MyProject.CustomerCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置CustomerUserMapping的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// CustomerUserMappingDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class CustomerUserMappingDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <CustomerUserMapping,CustomerUserMappingListDto>();
            configuration.CreateMap <CustomerUserMappingListDto,CustomerUserMapping>();

            configuration.CreateMap <CustomerUserMappingEditDto,CustomerUserMapping>();
            configuration.CreateMap <CustomerUserMapping,CustomerUserMappingEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
