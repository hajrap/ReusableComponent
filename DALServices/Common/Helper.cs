using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EFDBContextExample.Common
{
    public class Helper
    {
        public static object ToDBNull(object value)
        {
            if (value != null)
            {
                return value;
            }
            return DBNull.Value;
        }

        public static SqlParameter SqlOutputParam(string name, SqlDbType sqlType, int? size = null)
        {
            SqlParameter output = new SqlParameter(name, sqlType);
            output.Direction = ParameterDirection.Output;

            if (size.HasValue)
            {
                output.Size = size.Value;
            }

            return output;
        }

        public static SqlParameter SqlInputParam(string name, object value, SqlDbType sqlType)
        {
            SqlParameter input = new SqlParameter(name, ToDBNull(value));
            input.SqlDbType = sqlType;
            input.Direction = ParameterDirection.Input;

            return input;
        }
    }
}