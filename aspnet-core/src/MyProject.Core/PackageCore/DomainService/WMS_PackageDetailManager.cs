
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.PackageCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_PackageDetailManager :DomainServiceBase, IWMS_PackageDetailManager
    {
		
		private readonly IRepository<WMS_PackageDetail,long> _wms_packagedetailRepository;

		/// <summary>
		/// 【WMS_PackageDetail】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_PackageDetailManager(IRepository<WMS_PackageDetail, long> wms_packagedetailRepository)	{
			_wms_packagedetailRepository =  wms_packagedetailRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_PackageDetail> QueryEntityListAsNoTracking() { 

            var query = _wms_packagedetailRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_PackageDetail
                        {
                           
                            PackageId = x.PackageId,
                            OrderNumber = x.OrderNumber,
                            ExternOrderNumber = x.ExternOrderNumber,
                            PackageNumber = x.PackageNumber,
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            WarehouseName = x.WarehouseName,
                            SKU = x.SKU,
                            GoodsName = x.GoodsName,
                            GoodsType = x.GoodsType,
                            Qty = x.Qty,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Updator = x.Updator,
                            Remark = x.Remark,
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
                            UPC = x.UPC,
                            WMS_Package = x.WMS_Package,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_PackageDetail】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_PackageDetail> Query()
        {
            return _wms_packagedetailRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_PackageDetail】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_PackageDetail> QueryAsNoTracking()
        {
            return _wms_packagedetailRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_PackageDetail】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_PackageDetail> FindByIdAsync(long id)
        {
            var entity = await _wms_packagedetailRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_PackageDetail】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_packagedetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_PackageDetail】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_PackageDetail> CreateAsync(WMS_PackageDetail entity)
        {
            entity.Id = await _wms_packagedetailRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_PackageDetail】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_PackageDetail entity)
        {
            await _wms_packagedetailRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_PackageDetail】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_packagedetailRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_PackageDetail】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_packagedetailRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
