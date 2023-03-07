using Abp.Domain.Repositories;
using AutoMapper;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
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
    public class ReceiptReceivingExcelDefaultStrategy : IReceiptReceivingExcelInterface
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        //private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

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


        public ReceiptReceivingExcelDefaultStrategy(

                     ITable_ColumnsManager table_ColumnsManager

        )
        {

            _table_ColumnsManager = table_ColumnsManager;
        }

        //默认方法不做任何处理
        public Response<DataTable> Strategy(dynamic request, IAbpSessionExtension abpSession)
        {
            Response<DataTable> response = new Response<DataTable>();

            var headerTableColumn = GetColumns("WMS_Receipt", abpSession);
            var detailTableColumn = GetColumns("WMS_ReceiptReceiving", abpSession);
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn();

            ////1，构建主表需要的信息
            //headerTableColumn.ForEach(a =>
            //{
            //    if (a.IsImportColumn == 1)
            //    {
            //        dc = dt.Columns.Add(a.DisplayName, typeof(string));
            //    }
            //});
            ////2.构建明细需要的信息
            //detailTableColumn.ForEach(a =>
            //{
            //    if (a.IsImportColumn == 1 && !dt.Columns.Contains(a.DisplayName))
            //    {
            //        dc = dt.Columns.Add(a.DisplayName, typeof(string));
            //    }
            //});

            //循环datatable
            for (int i = 0; i < request.Columns.Count; i++)
            {
                //获取datatable的标头
                var s = request.Columns[i].ColumnName;
                var Column = headerTableColumn.Where(a => a.DisplayName == s).FirstOrDefault();
                if (Column == null)
                {
                    Column = detailTableColumn.Where(a => a.DisplayName == s).FirstOrDefault();
                }

                if (Column == null)
                {
                    continue;
                }
                //判断标头与key是否相等
                if (s.Equals(Column.DisplayName))
                {
                    //相等替换掉原来的表头
                    request.Columns[i].ColumnName = Column.DbColumnName;
                }

            }
            response.Data = request;
            response.Code = StatusCode.success;
            //throw new NotImplementedException();
            return response;
        }



        private List<Table_Columns> GetColumns(string TableName, IAbpSessionExtension abpSession)
        {
            return _table_ColumnsManager.Query()
               .Where(a => a.TableName == TableName &&
                 a.RoleName == abpSession.RoleName &&
                 a.IsImportColumn == 1
               )
              .Select(a => new Table_Columns
              {
                  DisplayName = a.DisplayName,
                  //由于框架约定大于配置， 数据库的字段首字母小写
                  //DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
                  DbColumnName = a.DbColumnName,
                  IsImportColumn = a.IsImportColumn

              }).ToList();
        }
    }
}