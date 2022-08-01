using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns
{
    public class Table_ColumnsDetail : Entity<long>, IHasCreationTime
    {
        public int CodeInt { get; set; }
        public string CodeStr { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string Associated { get; set; }
        public string Creator { get; set; }
        public DateTime CreationTime { get; set; } = new DateTime();

        public virtual Table_Columns Table_Columns { get; set; }
    }
}
