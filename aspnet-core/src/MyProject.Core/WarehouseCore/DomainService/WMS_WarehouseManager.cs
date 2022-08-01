
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.WarehouseCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_WarehouseManager :DomainServiceBase, IWMS_WarehouseManager
    {
		
		private readonly IRepository<WMS_Warehouse,long> _wms_warehouseRepository;

		/// <summary>
		/// 【WMS_Warehouse】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_WarehouseManager(IRepository<WMS_Warehouse, long> wms_warehouseRepository)	{
			_wms_warehouseRepository =  wms_warehouseRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Warehouse> QueryEntityListAsNoTracking() { 

            var query = _wms_warehouseRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Warehouse
                        {
                           
                            Id = x.Id,
                            ProjectId = x.ProjectId,
                            WarehouseName = x.WarehouseName,
                            WarehouseStatus = x.WarehouseStatus,
                            WarehouseType = x.WarehouseType,
                            Description = x.Description,
                            Company = x.Company,
                            Address = x.Address,
                            Province = x.Province,
                            City = x.City,
                            Contractor = x.Contractor,
                            ContractorAddress = x.ContractorAddress,
                            Mobile = x.Mobile,
                            Phone = x.Phone,
                            Fax = x.Fax,
                            Email = x.Email,
                            Remark = x.Remark,
                            Creator = x.Creator,
                            Updator = x.Updator,
                            CreationTime = x.CreationTime,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Warehouse】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Warehouse> Query()
        {
            return _wms_warehouseRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Warehouse】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Warehouse> QueryAsNoTracking()
        {
            return _wms_warehouseRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Warehouse】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Warehouse> FindByIdAsync(long id)
        {
            var entity = await _wms_warehouseRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Warehouse】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_warehouseRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Warehouse】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Warehouse> CreateAsync(WMS_Warehouse entity)
        {
            entity.Id = await _wms_warehouseRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Warehouse】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Warehouse entity)
        {
            await _wms_warehouseRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Warehouse】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_warehouseRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Warehouse】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_warehouseRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
