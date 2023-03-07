using Magicodes.ExporterAndImporter.Core.Filters;
using Magicodes.ExporterAndImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns.ExcelHelper
{
    public class ImportHeaderFilterSelect : IImportHeaderFilter
    {
        public List<ImporterHeaderInfo> Filter(List<ImporterHeaderInfo> importerHeaderInfos)
        {
            //foreach (var item in importerHeaderInfos)
            //{
            //    if (item.PropertyName == "Name")
            //    {
            //        item.Header.Name = "Student";
            //    }
            //    else if (item.PropertyName == "Gender")
            //    {
            //        item.MappingValues = new Dictionary<string, dynamic>()
            //    {
            //        {"男",0 },
            //        {"女",1 }
            //    };
            //    }
            //}
            return importerHeaderInfos;
        }
    }
}
