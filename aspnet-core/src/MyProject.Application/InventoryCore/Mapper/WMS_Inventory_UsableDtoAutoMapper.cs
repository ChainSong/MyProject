
using AutoMapper;
using MyProject.InventoryCore;
using MyProject.InventoryCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_Inventory_UsableDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_Inventory_UsableDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Inventory_Usable,WMS_Inventory_UsableListDto>();
            configuration.CreateMap <WMS_Inventory_UsableListDto,WMS_Inventory_Usable>();

            configuration.CreateMap <WMS_Inventory_UsableEditDto,WMS_Inventory_Usable>();
            configuration.CreateMap <WMS_Inventory_Usable,WMS_Inventory_UsableEditDto>();
					
        }
	}
}