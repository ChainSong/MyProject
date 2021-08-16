
using AutoMapper;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WMS_Receipt的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ReceiptDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_ReceiptDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Receipt,WMS_ReceiptListDto>();
            configuration.CreateMap <WMS_ReceiptListDto,WMS_Receipt>();

            configuration.CreateMap <WMS_ReceiptEditDto,WMS_Receipt>();
            configuration.CreateMap <WMS_Receipt,WMS_ReceiptEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
