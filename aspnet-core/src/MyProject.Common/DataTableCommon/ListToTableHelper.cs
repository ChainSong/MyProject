using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListToTableHelper<T> where T : new()
    {

        /// <summary>
        /// 实体类集合转table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DataTable ListToTable(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
                return null;
            DataTable dt = CreatTable(modelList[0]);
            foreach (T model in modelList)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    dr[p.Name] = p.GetValue(model, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 根据实体创建table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static DataTable CreatTable(T model)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(p.Name, p.PropertyType));
            }
            return dt;
        }
    }

}