
using AutoMapper;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

    /// <summary>
    /// 配置WMS_ReceiptDetail的AutoMapper映射
    /// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ReceiptDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
    public static class WMS_ReceiptDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<WMS_ReceiptDetail, WMS_ReceiptDetailListDto>();
            configuration.CreateMap<WMS_ReceiptDetailListDto, WMS_ReceiptDetail>();

            configuration.CreateMap<WMS_ReceiptDetailEditDto, WMS_ReceiptDetail>();
            configuration.CreateMap<WMS_ReceiptDetail, WMS_ReceiptDetailEditDto>();

            //// custom codes



            //// custom codes end
        }
    }
}
