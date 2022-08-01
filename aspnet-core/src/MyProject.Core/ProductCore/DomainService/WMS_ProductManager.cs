
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ProductCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_ProductManager :DomainServiceBase, IWMS_ProductManager
    {
		
		private readonly IRepository<WMS_Product,long> _wms_productRepository;

		/// <summary>
		/// 【WMS_Product】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_ProductManager(IRepository<WMS_Product, long> wms_productRepository)	{
			_wms_productRepository =  wms_productRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Product> QueryEntityListAsNoTracking() { 

            var query = _wms_productRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Product
                        {
                           
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            SKU = x.SKU,
                            ProductStatus = x.ProductStatus,
                            GoodsName = x.GoodsName,
                            GoodsType = x.GoodsType,
                            SKUClassification = x.SKUClassification,
                            SKULevel = x.SKULevel,
                            SKUGroup = x.SKUGroup,
                            ManufacturerSKU = x.ManufacturerSKU,
                            RetailSKU = x.RetailSKU,
                            ReplaceSKU = x.ReplaceSKU,
                            BoxGroup = x.BoxGroup,
                            Country = x.Country,
                            Manufacturer = x.Manufacturer,
                            DangerCode = x.DangerCode,
                            Vvolume = x.Vvolume,
                            StandardVolume = x.StandardVolume,
                            Weight = x.Weight,
                            StandardWeight = x.StandardWeight,
                            NetWeight = x.NetWeight,
                            StandardNetWeight = x.StandardNetWeight,
                            Cost = x.Cost,
                            Color = x.Color,
                            ExpirationDate = x.ExpirationDate,
                            Remark = x.Remark,
                            Creator = x.Creator,
                            Str1 = x.Str1,
                            Str2 = x.Str2,
                            Str3 = x.Str3,
                            Str4 = x.Str4,
                            Str5 = x.Str5,
                            Str6 = x.Str6,
                            Str7 = x.Str7,
                            Str8 = x.Str8,
                            Str9 = x.Str9,
                            Str10 = x.Str10,
                            Str11 = x.Str11,
                            Str12 = x.Str12,
                            Str13 = x.Str13,
                            Str14 = x.Str14,
                            Str15 = x.Str15,
                            Str16 = x.Str16,
                            Str17 = x.Str17,
                            Str18 = x.Str18,
                            Str19 = x.Str19,
                            Str20 = x.Str20,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Product】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Product> Query()
        {
            return _wms_productRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Product】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Product> QueryAsNoTracking()
        {
            return _wms_productRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Product】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Product> FindByIdAsync(long id)
        {
            var entity = await _wms_productRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Product】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_productRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Product】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Product> CreateAsync(WMS_Product entity)
        {
            entity.Id = await _wms_productRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Product】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Product entity)
        {
            await _wms_productRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Product】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_productRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Product】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_productRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
