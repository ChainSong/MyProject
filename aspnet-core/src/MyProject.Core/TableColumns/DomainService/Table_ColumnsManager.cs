

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_Columns> QueryEntityListAsNoTracking()
        {

            var query = _table_ColumnsRepository.GetAll().AsNoTracking()
                        .Select(x => new Table_Columns
                        {
                            Id = x.Id,
                            TenantId = x.TenantId,
                            ProjectId = x.ProjectId,
                            RoleName = x.RoleName,
                            CustomerId = x.CustomerId,
                            TableName = x.TableName,
                            TableNameCH = x.TableNameCH,
                            DisplayName = x.DisplayName,
                            DbColumnName = x.DbColumnName,
                            IsKey = x.IsKey,
                            IsSearchCondition = x.IsSearchCondition,
                            IsHide = x.IsHide,
                            IsReadOnly = x.IsReadOnly,
                            IsShowInList = x.IsShowInList,
                            IsImportColumn = x.IsImportColumn,
                            IsDropDownList = x.IsDropDownList,
                            IsCreate = x.IsCreate,
                            IsUpdate = x.IsUpdate,
                            SearchConditionOrder = x.SearchConditionOrder,
                            Validation = x.Validation,
                            Group = x.Group,
                            Type = x.Type,
                            Characteristic = x.Characteristic,
                            Order = x.Order,
                            Associated = x.Associated,
                            Precision = x.Precision,
                            Step = x.Step,
                            Max = x.Max,
                            Min = x.Min,
                            Default = x.Default,
                            Link = x.Link,
                            RelationDBColumn = x.RelationDBColumn,
                            ForView = x.ForView,
                            CreationTime = x.CreationTime,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_ASNDetail】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Table_Columns> Query()
        {
            return _table_ColumnsRepository.GetAll();
        }


        /// <summary>
        /// 【WMS_ASNDetail】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Table_Columns> QueryAsNoTracking()
        {
            return _table_ColumnsRepository.GetAll().AsNoTracking();
        }


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

        /// <summary>
        /// 【WMS_ASNDetail】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Table_Columns> Query(params Expression<Func<Table_Columns, object>>[] table)
        {
            return _table_ColumnsRepository.GetAll();
        }




        //// custom codes 



        //// custom codes end







    }
}
