
using AutoMapper;
using MyProject.ProductCore;
using MyProject.ProductCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

    /// <summary>
    /// 配置WMS_Product的AutoMapper映射
    /// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_ProductDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
    public static class WMS_ProductDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<WMS_Product, WMS_ProductListDto>();
            configuration.CreateMap<WMS_ProductListDto, WMS_Product>();

            configuration.CreateMap<WMS_ProductEditDto, WMS_Product>();
            configuration.CreateMap<WMS_Product, WMS_ProductEditDto>();

            //// custom codes



            //// custom codes end
        }
    }
}
