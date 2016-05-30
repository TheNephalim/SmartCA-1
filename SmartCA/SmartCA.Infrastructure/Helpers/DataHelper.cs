using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.Transactions;

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

        public static string EntityListToDelimited<T>(IList<T> entities) where T : IEntity
        {
            StringBuilder builder = new StringBuilder(20);
            if (entities != null)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(",");
                    }
                    builder.Append(entities[i].Key);
                }
            }
            return builder.ToString();
        }

        public static string GetSqlValue(object value)
        {
            return value.ToString();
        }


        #region Get Value

        public static decimal GetDecimal(object value)
        {
            decimal decimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decimalValue);
            }
            return decimalValue;
        }

        public static bool GetBoolean(object value)
        {
            bool boolValue = false;
            if (value != null && !Convert.IsDBNull(value))
            {
                bool.TryParse(value.ToString(), out boolValue);
            }
            return boolValue;
        }

        #endregion

        public static byte[] GetByteArrayValue(object value)
        {
            throw new NotImplementedException();
        }

        public static int GetInteger(object value)
        {
            throw new NotImplementedException();
        }

        public static DateTime? GetNullableDateTime(object value)
        {
            throw new NotImplementedException();
        }
    }
}
