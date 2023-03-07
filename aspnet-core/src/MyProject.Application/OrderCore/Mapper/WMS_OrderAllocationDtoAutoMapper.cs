
using AutoMapper;
using MyProject.OrderCore;
using MyProject.OrderCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_OrderAllocationDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_OrderAllocationDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_OrderAllocation,WMS_OrderAllocationListDto>();
            configuration.CreateMap <WMS_OrderAllocationListDto,WMS_OrderAllocation>();

            configuration.CreateMap <WMS_OrderAllocationEditDto,WMS_OrderAllocation>();
            configuration.CreateMap <WMS_OrderAllocation,WMS_OrderAllocationEditDto>();
					
        }
	}
}