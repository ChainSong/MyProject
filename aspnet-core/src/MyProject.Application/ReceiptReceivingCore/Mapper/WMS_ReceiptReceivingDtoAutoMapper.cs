
using AutoMapper;
using MyProject.ReceiptReceivingCore;
using MyProject.ReceiptReceivingCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WMS_ReceiptReceiving的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ReceiptReceivingDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_ReceiptReceivingDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_ReceiptReceiving,WMS_ReceiptReceivingListDto>();
            configuration.CreateMap <WMS_ReceiptReceivingListDto,WMS_ReceiptReceiving>();

            configuration.CreateMap <WMS_ReceiptReceivingEditDto,WMS_ReceiptReceiving>();
            configuration.CreateMap <WMS_ReceiptReceiving,WMS_ReceiptReceivingEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
