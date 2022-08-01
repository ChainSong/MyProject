
using AutoMapper;
using MyProject.InventoryCore;
using MyProject.InventoryCore.Dtos;

namespace MyProject.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Member的AutoMapper映射
	/// 前往 <see cref="MyProjectApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// WMS_Inventory_UsedDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class WMS_Inventory_UsedDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <WMS_Inventory_Used,WMS_Inventory_UsedListDto>();
            configuration.CreateMap <WMS_Inventory_UsedListDto,WMS_Inventory_Used>();

            configuration.CreateMap <WMS_Inventory_UsedEditDto,WMS_Inventory_Used>();
            configuration.CreateMap <WMS_Inventory_Used,WMS_Inventory_UsedEditDto>();
					
        }
	}
}