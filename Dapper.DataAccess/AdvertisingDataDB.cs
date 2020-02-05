using Dapper.HelperLibrary.BusinessObjects;
using Dapper.HelperLibrary.Models;
using SqlDataReaderMapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Dapper.HelperLibrary.Tools;

namespace Dapper.DataAccess
{
    public class AdvertisingDataDB : BaseDB<AdvertisingDataProcBo>
    {
        public static void UpdateAdvertisingData(List<SqlParameter> paramList)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var numberOfRowsAffected = cnn.Execute(AllStoredProcedures.UpdateAdvertisingData, param: paramList.ToDynamicParameters(), commandType: CommandType.StoredProcedure);
            }
        }

        public int AddAdvertisingData(List<SqlParameter> paramList)
        {
            return base.Add(AllStoredProcedures.AddAdvertisingData, AllParams.AdvertisingDataId, paramList);
        }

        public override List<AdvertisingDataProcBo> GetList(List<SqlParameter> paramList)
        {
            throw new System.NotImplementedException();
        }

        public override AdvertisingDataProcBo GetOne(List<SqlParameter> paramList)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var reader = cnn.ExecuteReader(AllStoredProcedures.GetAdvertisingData, param: paramList.ToDynamicParameters(), commandType: CommandType.StoredProcedure);
                if (reader.Read())
                {
                    return new SqlDataReaderMapper<AdvertisingDataProcBo>(reader)
                     .NameTransformers("_", "")
                     .ForMember("ad_id", "AdvertisingId")
                     .ForMember("la_id", "LanguageId")
                     .ForMember("add_title", "Title")
                     .ForMember("add_content", "Content")
                     .Build();
                }

                return new AdvertisingDataProcBo();
            }
        }
    }
}
