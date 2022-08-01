
using AutoMapper;
using MyProject.PackageCore;
using MyProject.PackageCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_PackageDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_PackageDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Package,WMS_PackageListDto>();
            configuration.CreateMap <WMS_PackageListDto,WMS_Package>();

            configuration.CreateMap <WMS_PackageEditDto,WMS_Package>();
            configuration.CreateMap <WMS_Package,WMS_PackageEditDto>();
					
        }
	}
}