using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dapper.DataAccess
{
    public static class Extensions
    {
        public static DynamicParameters ToDynamicParameters(this List<SqlParameter> paramList)
        {
            DynamicParameters dp = new DynamicParameters();

            if (paramList != null)
            {
                foreach (SqlParameter sp in paramList)
                    dp.Add(sp.ParameterName, sp.SqlValue, sp.DbType, direction: sp.Direction, size: sp.Size);
            }

            return dp;
        }
    }
}
