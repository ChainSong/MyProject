
using System;
using System.Collections.Generic;
using Abp.Application.Services;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;

//using MyProject.DataExporting.Excel.Epplus;
//using MyProject.DataFileObjects.DataTempCache;
using MyProject.ASNCore.Dtos;


namespace MyProject.ASNCore.Exporting
{
    /// <summary>
    /// 的视图模型根据业务需要可以导出为Excel文件
    /// </summary>
	//[RemoteService(IsEnabled = false)]
   // public class WMS_ASNListExcelExporter : EpplusExcelExporterBase, IWMS_ASNListExcelExporter
   // {       
   //     /// <summary>
   //     /// 构造函数，需要继承父类
   //     /// </summary>
   //     /// <param name="dataTempFileCacheManager"></param>
   //     public WMS_ASNListExcelExporter(IDataTempFileCacheManager dataTempFileCacheManager):base(dataTempFileCacheManager)
   //     {

   //     }
   //     public FileDto ExportToExcelFile(List<WMS_ASNListDto> wMS_ASNListDtos)
   //     {

   // var fileExportName = L("WMS_ASNList") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

   //         var excel =
   //              CreateExcelPackage(fileExportName, excelpackage =>
   //            {
   //                var sheet = excelpackage.Workbook.Worksheets.Add(L("WMS_ASNs"));

   //                sheet.OutLineApplyStyle = true;

   //         AddObject(sheet, 2, wMS_ASNListDtos
   //          ,ex => ex.ExtensionGUID 
   //          ,ex => ex.ASNNumber 
   //          ,ex => ex.ExternReceiptNumber 
   //          ,ex => ex.CustomerID 
   //          ,ex => ex.CustomerName 
   //          ,ex => ex.WarehouseID 
   //          ,ex => ex.WarehouseName 
   //          ,ex => ex.ExpectDate 
   //          ,ex => ex.ASNStatus 
   //          ,ex => ex.ASNType 
   //          ,ex => ex.PO 
   //          ,ex => ex.Contact 
   //          ,ex => ex.ContactInfo 
   //          ,ex => ex.CompleteDate 
   //          ,ex => ex.Remark 
   //          ,ex => ex.Creator 
   //          ,ex => ex.CreationTime 
   //          ,ex => ex.Updator 
   //          ,ex => ex.UpdateTime 
   //          ,ex => ex.Str1 
   //          ,ex => ex.Str2 
   //          ,ex => ex.Str3 
   //          ,ex => ex.Str4 
   //          ,ex => ex.Str5 
   //          ,ex => ex.Str6 
   //          ,ex => ex.Str7 
   //          ,ex => ex.Str8 
   //          ,ex => ex.Str9 
   //          ,ex => ex.Str10 
   //          ,ex => ex.Str11 
   //          ,ex => ex.Str12 
   //          ,ex => ex.Str13 
   //          ,ex => ex.Str14 
   //          ,ex => ex.Str15 
   //          ,ex => ex.Str16 
   //          ,ex => ex.Str17 
   //          ,ex => ex.Str18 
   //          ,ex => ex.Str19 
   //          ,ex => ex.Str20 
   //          ,ex => ex.DateTime1 
   //          ,ex => ex.DateTime2 
   //          ,ex => ex.DateTime3 
   //          ,ex => ex.DateTime4 
   //          ,ex => ex.DateTime5 
   //          ,ex => ex.Int1 
   //          ,ex => ex.Int2 
   //          ,ex => ex.Int3 
   //          ,ex => ex.Int4 
   //          ,ex => ex.Int5 
   //          ,ex => ex.WMS_ASNDetails 
   //                );
   //         sheet.Column(17).Style.Numberformat.Format = "yyyy-mm-dd";              

			//				//// custom codes
									
							

			//				//// custom codes end
	  //});
   // return excel;
   //     }
   // }
}