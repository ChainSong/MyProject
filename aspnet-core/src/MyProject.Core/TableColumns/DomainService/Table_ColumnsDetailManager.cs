

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


        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<Table_ColumnsDetail> QueryEntityListAsNoTracking()
        {

            var query = _table_ColumnsDetailRepository.GetAll().AsNoTracking()
                        .Select(x => new Table_ColumnsDetail
                        {
                            Id = x.Id,
                            CodeInt = x.CodeInt,
                            CodeStr = x.CodeStr,
                            Name = x.Name,
                            Type = x.Type,
                            Color = x.Color,
                            Associated = x.Associated,
                            Status = x.Status,
                            Order = x.Order,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            //ASNId = x.ASNId,
                            //ASNNumber = x.ASNNumber,
                            //ExternReceiptNumber = x.ExternReceiptNumber,
                            //CustomerId = x.CustomerId,
                            //CustomerName = x.CustomerName,
                            //WarehouseName = x.WarehouseName,
                            //LineNumber = x.LineNumber,
                            //SKU = x.SKU,
                            //UPC = x.UPC,
                            //GoodsType = x.GoodsType,
                            //GoodsName = x.GoodsName,
                            //BoxCode = x.BoxCode,
                            //TrayCode = x.TrayCode,
                            //BatchCode = x.BatchCode,
                            //ExpectedQty = x.ExpectedQty,
                            //ReceivedQty = x.ReceivedQty,
                            //ReceiptQty = x.ReceiptQty,
                            //UnitCode = x.UnitCode,
                            //Onwer = x.Onwer,
                            //Creator = x.Creator,
                            //CreationTime = x.CreationTime,
                            //Updator = x.Updator,
                            //Str1 = x.Str1,
                            //Str2 = x.Str2,
                            //Str3 = x.Str3,
                            //Str4 = x.Str4,
                            //Str5 = x.Str5,
                            //Str6 = x.Str6,
                            //Str7 = x.Str7,
                            //Str8 = x.Str8,
                            //Str9 = x.Str9,
                            //Str10 = x.Str10,
                            //Str11 = x.Str11,
                            //Str12 = x.Str12,
                            //Str13 = x.Str13,
                            //Str14 = x.Str14,
                            //Str15 = x.Str15,
                            //Str16 = x.Str16,
                            //Str17 = x.Str17,
                            //Str18 = x.Str18,
                            //Str19 = x.Str19,
                            //Str20 = x.Str20
                            //ASN = x.ASN,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_ASNDetail】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Table_ColumnsDetail> Query()
        {
            return _table_ColumnsDetailRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_ASNDetail】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Table_ColumnsDetail> QueryAsNoTracking()
        {
            return _table_ColumnsDetailRepository.GetAll().AsNoTracking();
        }



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
