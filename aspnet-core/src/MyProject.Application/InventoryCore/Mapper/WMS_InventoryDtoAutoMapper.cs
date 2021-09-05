
using AutoMapper;
using MyProject.InventoryCore;
using MyProject.InventoryCore.Dtos;

// ReSharper disable once CheckNamespace
namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置WMS_Inventory的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_InventoryDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_InventoryDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Inventory,WMS_InventoryListDto>();
            configuration.CreateMap <WMS_InventoryListDto,WMS_Inventory>();

            configuration.CreateMap <WMS_InventoryEditDto,WMS_Inventory>();
            configuration.CreateMap <WMS_Inventory,WMS_InventoryEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
