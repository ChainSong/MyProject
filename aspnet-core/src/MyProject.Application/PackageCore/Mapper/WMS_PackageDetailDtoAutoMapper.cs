
using AutoMapper;
using MyProject.PackageCore;
using MyProject.PackageCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_PackageDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_PackageDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_PackageDetail,WMS_PackageDetailListDto>();
            configuration.CreateMap <WMS_PackageDetailListDto,WMS_PackageDetail>();

            configuration.CreateMap <WMS_PackageDetailEditDto,WMS_PackageDetail>();
            configuration.CreateMap <WMS_PackageDetail,WMS_PackageDetailEditDto>();
					
        }
	}
}