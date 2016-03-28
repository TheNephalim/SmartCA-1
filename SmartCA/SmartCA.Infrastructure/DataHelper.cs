using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure
{
    public class DataHelper
    {
        public static bool ReaderContainsColumnName(DataTable schemaTable, string columnName)
        {
            bool containsColumnName = false;
            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["ColumnName"].ToString() == columnName)
                {
                    containsColumnName = true;
                    break;
                }
            }
            return containsColumnName;
        }
    }
}
