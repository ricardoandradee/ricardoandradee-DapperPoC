using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Dapper.HelperLibrary.Tools;

namespace Dapper.DataAccess
{
    public abstract class BaseDB<T>
    {
        protected int Add(string procedureName, string outputParamName, List<SqlParameter> paramList)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var dynamicParams = paramList.ToDynamicParameters();
                cnn.Execute(procedureName, param: dynamicParams, commandType: CommandType.StoredProcedure);
                return dynamicParams.Get<int>(outputParamName);
            }
        }

        protected void Update(string procedureName, List<SqlParameter> paramList)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(procedureName, param: paramList.ToDynamicParameters(), commandType: CommandType.StoredProcedure);
            }
        }

        protected void DeleteById(string procedureName, string idName, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add(idName, id, DbType.Int32, ParameterDirection.Input, size: 4);

                cnn.Execute(procedureName, param: dp, commandType: CommandType.StoredProcedure);
            }
        }

        public abstract T GetOne(List<SqlParameter> paramList);
        public abstract List<T> GetList(List<SqlParameter> paramList);
    }
}
