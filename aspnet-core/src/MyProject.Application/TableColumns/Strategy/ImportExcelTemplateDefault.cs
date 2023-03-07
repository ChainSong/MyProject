using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.TableColumns.DomainService;
using MyProject.TableColumns.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns.Strategy
{
    public class ImportExcelTemplateASNDefault : MyProjectAppServiceBase, IImportExcelTemplate
    {


        private readonly ITable_ColumnsManager _table_ColumnsManager;

        private readonly ITable_ColumnsDetailManager _table_ColumnsDetailManager;


        public ImportExcelTemplateASNDefault(
               ITable_ColumnsManager table_ColumnsManager,
                     ITable_ColumnsDetailManager table_ColumnsDetailManager
            )
        {
            _table_ColumnsManager = table_ColumnsManager;
            _table_ColumnsDetailManager = table_ColumnsDetailManager;
        }


        public Response<DataTable> Strategy(long CustomerId, string RoleName)
        {


            Response<DataTable> response = new Response<DataTable>();

            var header = _table_ColumnsManager.Query()
            .Where(a => a.TableName == "WMS_ASN" &&
              a.RoleName == RoleName &&
              a.IsImportColumn == 1
            )
           .Select(a => new Table_Columns
           {
               DisplayName = a.DisplayName,
               //由于框架约定大于配置， 数据库的字段首字母小写
               //DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
               DbColumnName = a.DbColumnName,
               IsImportColumn = a.IsImportColumn
           });
            var detail = _table_ColumnsManager.Query().Where(a => a.TableName == "WMS_ASNDetail" &&
              a.RoleName == RoleName &&
              a.IsImportColumn == 1
            )
           .Select(a => new Table_Columns
           {
               DisplayName = a.DisplayName,
               //由于框架约定大于配置， 数据库的字段首字母小写
               //DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
               DbColumnName = a.DbColumnName,
               IsImportColumn = a.IsImportColumn
           });
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            //1，构建主表需要的信息
            foreach (var item in header)
            {
                if (item.IsImportColumn == 1)
                {
                    dc = dt.Columns.Add(item.DisplayName, typeof(string));
                }
            }
            //2.构建明细需要的信息
            foreach (var item in detail)
            {
                if (item.IsImportColumn == 1 && !dt.Columns.Contains(item.DisplayName))
                {
                    dc = dt.Columns.Add(item.DisplayName, typeof(string));
                }
            }
            response.Code = StatusCode.success;
            response.Data = dt;
            return response;

        }
    }
}
