using Abp.Domain.Repositories;
using AutoMapper;
using EFCore.BulkExtensions;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ReceiptReceivingCore.Interface;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptReceivingCore.Strategy
{
    public class ReceiptReceivingReturnDefaultStrategy : IReceiptReceivingReturnInterface
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>

        private IWMS_ReceiptManager _wms_receiptManager;

        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        /// <summary>
        ///【WMS_ReceiptDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;



        public ReceiptReceivingReturnDefaultStrategy(
        IRepository<WMS_Receipt, long> wms_receiptRepository,
        IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
        IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository
    )
        {
            _wms_receiptRepository = wms_receiptRepository;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;


        }

        //默认方法不做任何处理
        public Task<Response<List<OrderStatusDto>>> Strategy(IAbpSessionExtension abpSession, params long[] request)
        {
            return Task.Run(() =>
            {
                Response<List<OrderStatusDto>> response = new Response<List<OrderStatusDto>>();
                response.Data = new List<OrderStatusDto>();
                //先判断状态是否正常 是否允许回退
                var receipt = _wms_receiptRepository.GetAll().Where(a => request.Contains(a.Id));
                receipt.ToList().ForEach(a =>
                {
                    if (a.ReceiptStatus == (int)ReceiptStatusEnum.完成)
                    {
                        response.Data.Add(new OrderStatusDto()
                        {
                            ExternOrder = a.ExternReceiptNumber,
                            SystemOrder = a.ReceiptNumber,
                            Type = a.ReceiptType,
                            StatusCode = StatusCode.warning,
                            Msg = "状态异常"
                        });
                    }
                });
                if (response.Data.Count > 0)
                {
                    return response;
                }
                //先处理上架=>入库单
                //先处理上架表的数据，然后修改入库单中的数据 
                _wms_receiptreceivingRepository.Delete(a => request.Contains(a.ReceiptId));
                _wms_receiptRepository.GetAll().Where(a => request.Contains(a.Id)).BatchUpdate(new WMS_Receipt { ReceiptStatus = (int)ReceiptStatusEnum.新增 });
                //_wms_receiptRepository.GetAll().Where(a => request.Contains(a.Id)).ToList().ForEach(c =>
                //{
                //    c.ReceiptStatus = (int)ReceiptStatusEnum.新增;
                //    _wms_receiptRepository.Update(c);
                //});

                //.BatchUpdate(new WMS_Receipt { ReceiptStatus = (int)ReceiptStatusEnum.新增 });

                receipt.ToList().ForEach(a =>
                {

                    response.Data.Add(new OrderStatusDto()
                    {
                        ExternOrder = a.ExternReceiptNumber,
                        SystemOrder = a.ReceiptNumber,
                        Type = a.ReceiptType,
                        StatusCode = StatusCode.success,
                        Msg = "操作成功"
                    });

                });
                //_wms_receiptRepository.Update(a => new WMS_Receipt {  ReceiptStatus== ReceiptStatusEnum.新增 } );
                response.Code = StatusCode.success;
                //throw new NotImplementedException();
                return response;
            });
        }



        //private List<Table_Columns> GetColumns(string TableName, IAbpSessionExtension abpSession)
        //{
        //    return _table_ColumnsManager.Query()
        //       .Where(a => a.TableName == TableName &&
        //         a.RoleName == abpSession.RoleName &&
        //         a.IsImportColumn == 1
        //       )
        //      .Select(a => new Table_Columns
        //      {
        //          DisplayName = a.DisplayName,
        //          //由于框架约定大于配置， 数据库的字段首字母小写
        //          //DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
        //          DbColumnName = a.DbColumnName,
        //          IsImportColumn = a.IsImportColumn
        //      }).ToList();
        //}
    }
}