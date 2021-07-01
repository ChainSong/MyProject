
using AutoMapper;
using MyProject.Customers;
using MyProject.Customers.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Customer的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// CustomerDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class CustomerDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Customer,CustomerListDto>();
            configuration.CreateMap <CustomerListDto,Customer>();

            configuration.CreateMap <CustomerEditDto,Customer>();
            configuration.CreateMap <Customer,CustomerEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
