
using System;
using System.Collections.Generic;
using Abp.Application.Services;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;

//using MyProject.DataExporting.Excel.Epplus;
//using MyProject.DataFileObjects.DataTempCache;
using MyProject.TableColumns.Dtos;


namespace MyProject.TableColumns.Exporting
{
 //   /// <summary>
 //   /// 的视图模型根据业务需要可以导出为Excel文件
 //   /// </summary>
	//[RemoteService(IsEnabled = false)]
 //   public class Table_ColumnsListExcelExporter : EpplusExcelExporterBase, ITable_ColumnsListExcelExporter
 //   {
 //       /// <summary>
 //       /// 构造函数，需要继承父类
 //       /// </summary>
 //       /// <param name="dataTempFileCacheManager"></param>
 //       public Table_ColumnsListExcelExporter(IDataTempFileCacheManager dataTempFileCacheManager) : base(dataTempFileCacheManager)
 //       {

 //       }
 //       public FileDto ExportToExcelFile(List<Table_ColumnsListDto> table_ColumnsListDtos)
 //       {

 //           var fileExportName = L("Table_ColumnsList") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

 //           var excel = CreateExcelPackage(fileExportName, excelpackage =>
 //            {
 //                var sheet = excelpackage.Workbook.Worksheets.Add(L("Table_Columnss"));

 //                sheet.OutLineApplyStyle = true;

 //                AddHeader(sheet, L("ProjectID"), L("Table_ColumnsRoleName"), L("CustomerID"), L("Table_ColumnsTableName"), L("Table_ColumnsTableNameCH"), L("Table_ColumnsDisplayName"), L("Table_ColumnsDbColumnName"), L("IsKey"), L("IsSearchCondition"), L("IsHide"), L("IsReadOnly"), L("IsShowInList"), L("IsImportColumn"), L("IsDropDownList"), L("IsCreate"), L("IsUpdate"), L("SearchConditionOrder"), L("Table_ColumnsGroup"), L("Table_ColumnsType"), L("Order"), L("ForView"), L("CreationTime"), L("TableID"));
 //                AddObject(sheet, 2, table_ColumnsListDtos
 //                 , ex => ex.ProjectID
 //                 , ex => ex.RoleName
 //                 , ex => ex.CustomerID
 //                 , ex => ex.TableName
 //                 , ex => ex.TableNameCH
 //                 , ex => ex.DisplayName
 //                 , ex => ex.DbColumnName
 //                 , ex => ex.IsKey
 //                 , ex => ex.IsSearchCondition
 //                 , ex => ex.IsHide
 //                 , ex => ex.IsReadOnly
 //                 , ex => ex.IsShowInList
 //                 , ex => ex.IsImportColumn
 //                 , ex => ex.IsDropDownList
 //                 , ex => ex.IsCreate
 //                 , ex => ex.IsUpdate
 //                 , ex => ex.SearchConditionOrder
 //                 , ex => ex.Group
 //                 , ex => ex.Type
 //                 , ex => ex.Order
 //                 , ex => ex.ForView
 //                 , ex => ex.CreationTime
 //                 , ex => ex.TableID
 //                       );
 //                sheet.Column(22).Style.Numberformat.Format = "yyyy-mm-dd";

 //                  //// custom codes



 //                  //// custom codes end
 //              });
 //           return excel;
 //       }
 //   }
}
