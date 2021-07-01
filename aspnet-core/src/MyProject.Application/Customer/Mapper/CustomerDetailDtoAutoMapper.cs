
using AutoMapper;
using MyProject.Customers;
using MyProject.Customers.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置CustomerDetail的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// CustomerDetailDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class CustomerDetailDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <CustomerDetail,CustomerDetailListDto>();
            configuration.CreateMap <CustomerDetailListDto,CustomerDetail>();

            configuration.CreateMap <CustomerDetailEditDto,CustomerDetail>();
            configuration.CreateMap <CustomerDetail,CustomerDetailEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
