using AutoMapper;
using MyProject.ASNCore.Interface;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Strategy
{
    public class ASNExcelDefaultStrategy : IASNExcelInterface
    {


        private readonly ITable_ColumnsManager _table_ColumnsManager;




        public ASNExcelDefaultStrategy(
                     ITable_ColumnsManager table_ColumnsManager

        )
        {
            _table_ColumnsManager = table_ColumnsManager;
        }

        //默认方法不做任何处理
        public Response<DataTable> Strategy(dynamic request, IAbpSessionExtension abpSession)
        {
            Response<DataTable> response = new Response<DataTable>();

            var headerTableColumn = GetColumns("WMS_ASN", abpSession);
            var detailTableColumn = GetColumns("WMS_ASNDetail", abpSession);
            

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
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<DataTable, WMS_ASN>() );
            //var mapper = new Mapper(config);
            //var asnData = mapper.Map<List<WMS_ASN>>(request);

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