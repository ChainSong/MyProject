using MyProject.TableColumns.DomainService;
using MyProject.TableColumns.Interface;
using MyProject.TableColumns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns.Factory
{
    public class ImportExcelFactory
    {

        public static IImportExcelTemplate ImportExcelTemplate(long CustomerId, string TableName , ITable_ColumnsManager _table_ColumnsManager, ITable_ColumnsDetailManager _table_ColumnsDetailManager)
        {
            //string aaa = Enum.GetName(typeof(ASNEnum), ASNEnum.ASNExportDefault);
            switch (CustomerId + TableName)
            {

                default:
                    return new ImportExcelTemplateASNDefault(_table_ColumnsManager, _table_ColumnsDetailManager);
            }
        }
    }
}
