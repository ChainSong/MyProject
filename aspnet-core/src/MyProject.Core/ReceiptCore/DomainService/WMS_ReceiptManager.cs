
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ReceiptCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_ReceiptManager : DomainServiceBase, IWMS_ReceiptManager
    {

        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        /// 【WMS_Receipt】的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ReceiptManager(IRepository<WMS_Receipt, long> wms_receiptRepository)
        {
            _wms_receiptRepository = wms_receiptRepository;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Receipt> QueryEntityListAsNoTracking()
        {

            var query = _wms_receiptRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Receipt
                        {

                            ASNNumber = x.ASNNumber,
                            ReceiptNumber = x.ReceiptNumber,
                            ExternReceiptNumber = x.ExternReceiptNumber,
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            WarehouseName = x.WarehouseName,
                            ReceiptStatus = x.ReceiptStatus,
                            ReceiptType = x.ReceiptType,
                            Contact = x.Contact,
                            ContactInfo = x.ContactInfo,
                            Remark = x.Remark,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Updator = x.Updator,
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
                            Str20 = x.Str20
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Receipt】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Receipt> Query()
        {
            return _wms_receiptRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Receipt】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Receipt> QueryAsNoTracking()
        {
            return _wms_receiptRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Receipt】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Receipt> FindByIdAsync(long id)
        {
            var entity = await _wms_receiptRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Receipt】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_receiptRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
        /// <summary>
        /// 【WMS_Receipt】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Receipt> CreateAsync(WMS_Receipt entity)
        {
            entity.Id = await _wms_receiptRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Receipt】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Receipt entity)
        {
            await _wms_receiptRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Receipt】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_receiptRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Receipt】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_receiptRepository.DeleteAsync(a => input.Contains(a.Id));
        }
        #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展领域服务接口*/


        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BulkInsert(List<WMS_Receipt> entitys)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //List<WMS_Receipt> list = new List<WMS_Receipt>();
            //for (int i = 0; i < input.Id; i++)
            //{
            //    var entity = new WMS_Receipt();
            //    entity.CateId = 2;
            //    entity.Title = $"BulkInsert娱乐{1}";
            //    list.Add(entity);
            //}

            await _wms_receiptRepository.GetDbContext().BulkInsertAsync(entitys, options => options.IncludeGraph = true);//GetDbContext 需要添加Abp.EntityFrameworkCore.Repositories引用
                                                                               //watch.Stop();

            //string time = watch.ElapsedMilliseconds.ToString();

        }

        #endregion









    }
}
