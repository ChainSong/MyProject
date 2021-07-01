

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.TableColumns.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class Table_ColumnsDetailManager :MyProjectDomainServiceBase, ITable_ColumnsDetailManager
    {
		
		private readonly IRepository<Table_ColumnsDetail,long> _table_ColumnsDetailRepository;

		/// <summary>
		/// Table_ColumnsDetail的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public Table_ColumnsDetailManager(IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository)	{
			_table_ColumnsDetailRepository =  table_ColumnsDetailRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_ColumnsDetail> QueryTable_ColumnsDetails()
        {
            return _table_ColumnsDetailRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_ColumnsDetail> QueryTable_ColumnsDetailsAsNoTracking()
        {
            return _table_ColumnsDetailRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Table_ColumnsDetail> FindByIdAsync(long id)
        {
            var entity = await _table_ColumnsDetailRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _table_ColumnsDetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<Table_ColumnsDetail> CreateAsync(Table_ColumnsDetail entity)
        {
            entity.Id = await _table_ColumnsDetailRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Table_ColumnsDetail entity)
        {
            await _table_ColumnsDetailRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsDetailRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsDetailRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
