

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
    public class Table_ColumnsManager : MyProjectDomainServiceBase, ITable_ColumnsManager
    {

        private readonly IRepository<Table_Columns, long> _table_ColumnsRepository;

        //private readonly IRepository<Table_ColumnsDetail, long> _table_ColumnsDetailRepository;


        /// <summary>
        /// Table_Columns的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public Table_ColumnsManager(IRepository<Table_Columns, long> table_ColumnsRepository)//, IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository
        {
            _table_ColumnsRepository = table_ColumnsRepository;
            //_table_ColumnsDetailRepository = table_ColumnsDetailRepository;
        }

        #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_Columns> QueryTable_Columnss()
        {
            return _table_ColumnsRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_Columns> QueryTable_ColumnssAsNoTracking()
        {
            return _table_ColumnsRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Table_Columns> FindByIdAsync(long id)
        {
            var entity = await _table_ColumnsRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _table_ColumnsRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion



        public async Task<Table_Columns> CreateAsync(Table_Columns entity)
        {
            entity.Id = await _table_ColumnsRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Table_Columns entity)
        {
            await _table_ColumnsRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        //// custom codes 
        //// custom codes 
        
        //// custom codes end

    }
}
