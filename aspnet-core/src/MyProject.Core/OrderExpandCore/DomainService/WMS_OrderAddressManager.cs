
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.OrderExpandCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_OrderAddressManager :DomainServiceBase, IWMS_OrderAddressManager
    {
		
		private readonly IRepository<WMS_OrderAddress,long> _wms_orderaddressRepository;

		/// <summary>
		/// 【WMS_OrderAddress】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_OrderAddressManager(IRepository<WMS_OrderAddress, long> wms_orderaddressRepository)	{
			_wms_orderaddressRepository =  wms_orderaddressRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_OrderAddress> QueryEntityListAsNoTracking() { 

            var query = _wms_orderaddressRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_OrderAddress
                        {
                           
                            PreOrderId = x.PreOrderId,
                            PreOrderNumber = x.PreOrderNumber,
                            ExternReceiptNumber = x.ExternReceiptNumber,
                            Name = x.Name,
                            Phone = x.Phone,
                            ZipCode = x.ZipCode,
                            Province = x.Province,
                            City = x.City,
                            Country = x.Country,
                            Address = x.Address,
                            ExpressCompany = x.ExpressCompany,
                            ExpressNumber = x.ExpressNumber,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_OrderAddress】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_OrderAddress> Query()
        {
            return _wms_orderaddressRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_OrderAddress】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_OrderAddress> QueryAsNoTracking()
        {
            return _wms_orderaddressRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_OrderAddress】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_OrderAddress> FindByIdAsync(long id)
        {
            var entity = await _wms_orderaddressRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_OrderAddress】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_orderaddressRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_OrderAddress】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_OrderAddress> CreateAsync(WMS_OrderAddress entity)
        {
            entity.Id = await _wms_orderaddressRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_OrderAddress】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_OrderAddress entity)
        {
            await _wms_orderaddressRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_OrderAddress】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderaddressRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_OrderAddress】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderaddressRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
