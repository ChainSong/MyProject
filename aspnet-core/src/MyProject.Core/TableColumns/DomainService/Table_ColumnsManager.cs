

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.TableColumns.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class Table_ColumnsManager : MyProjectDomainServiceBase, ITable_ColumnsManager//AbpDomainService<Table_ColumnsDetail,long>, ITable_ColumnsDetailManager
    {
        private readonly IRepository<Table_Columns, long> _table_ColumnsRepository;

        //public Table_ColumnsDetailManager(IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository)
        //{
        //    _table_ColumnsDetailRepository = table_ColumnsDetailRepository;
        //}
        /// <summary>
        /// Table_Columns的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public Table_ColumnsManager(IRepository<Table_Columns, long> table_ColumnsRepository)
        {
            _table_ColumnsRepository = table_ColumnsRepository;
        }
        //      public Table_ColumnsManager(IServiceProvider serviceProvider) : base(serviceProvider)	
        //      {

        //}




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

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _table_ColumnsRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        //// custom codes






        //// custom codes 



        //// custom codes end







    }
}
