

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
    public class Table_ColumnsDetailManager : MyProjectDomainServiceBase, ITable_ColumnsDetailManager//AbpDomainService<Table_ColumnsDetail,long>, ITable_ColumnsDetailManager
    {
        private readonly IRepository<Table_ColumnsDetail, long> _table_ColumnsDetailRepository;

        //public Table_ColumnsDetailManager(IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository)
        //{
        //    _table_ColumnsDetailRepository = table_ColumnsDetailRepository;
        //}

        /// <summary>
        /// Table_ColumnsDetail的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public Table_ColumnsDetailManager(IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository)
        {
            _table_ColumnsDetailRepository = table_ColumnsDetailRepository;
        }
        //      public Table_ColumnsDetailManager(IServiceProvider serviceProvider) : base(serviceProvider)	
        //      {

        //}




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

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _table_ColumnsDetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        //// custom codes



        //// custom codes end







    }
}
