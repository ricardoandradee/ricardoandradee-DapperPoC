using Dapper.HelperLibrary.BusinessObjects;
using Dapper.HelperLibrary.Models;
using SqlDataReaderMapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Dapper.HelperLibrary.Tools;

namespace Dapper.DataAccess
{
    public class AdvertisingDB : BaseDB<AdvertisingProcBo>
    {
        public int Add(List<SqlParameter> paramList)
        {
            return base.Add(AllStoredProcedures.AddAdvertising, AllParams.AdvertisingId, paramList);
        }

        public void Update(List<SqlParameter> paramList)
        {
            base.Update(AllStoredProcedures.UpdateAdvertising, paramList);
        }

        public void UpdateAdvertisingEnabled(List<SqlParameter> paramList)
        {
            base.Update(AllStoredProcedures.UpdateAdvertisingEnabled, paramList);
        }

        public override List<AdvertisingProcBo> GetList(List<SqlParameter> paramList)
        {
            List<AdvertisingProcBo> bos = new List<AdvertisingProcBo>();
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var reader = cnn.ExecuteReader(AllStoredProcedures.GetAdvertisingList, param: paramList.ToDynamicParameters(), commandType: CommandType.StoredProcedure);
                if (reader.Read())
                {
                    bos.Add(new SqlDataReaderMapper<AdvertisingProcBo>(reader)
                     .NameTransformers("_", "")
                     .ForMember("ad_id", "AdvertisingId")
                     .ForMember("cl_id", "ClientId")
                     .ForMember("ad_dateStart", "DateStart")
                     .ForMember("ad_dateEnd", "DateEnd")
                     .ForMember("ad_enabled", "Enabled")
                     .ForMember("ad_created", "Created")
                     .ForMember("ad_groupTypes", "GroupTypes")
                     .ForMember("add_title", "Title")
                     .ForMember("add_content", "Content")
                     .ForMember("roomtypes", "RoomTypes")
                     .ForMember("ratetypes", "RateTypes")
                     .ForMember("enhancements", "Enhancements")
                     .Build());
                }

                return bos;
            }
        }

        public override AdvertisingProcBo GetOne(List<SqlParameter> paramList)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var reader = cnn.ExecuteReader(AllStoredProcedures.GetAdvertising, param: paramList.ToDynamicParameters(), commandType: CommandType.StoredProcedure);
                if (reader.Read())
                {
                    return new SqlDataReaderMapper<AdvertisingProcBo>(reader)
                     .NameTransformers("_", "")
                     .ForMember("cl_id", "ClientId")
                     .ForMember("ad_dateStart", "DateStart")
                     .ForMember("ad_dateEnd", "DateEnd")
                     .ForMember("ad_groupTypes", "GroupTypes")
                     .ForMember("ad_enabled", "Enabled")
                     .ForMember("ad_created", "Created")
                     .Build();
                }

                return new AdvertisingProcBo();
            }
        }

        public void DeleteById(int advertisingId)
        {
            base.DeleteById(AllStoredProcedures.DeleteAdvertising, AllParams.AdvertisingId, advertisingId);
        }

        public int CountByClientId(int clientId)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var param = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = AllParams.ClientId, SqlValue = clientId, DbType = DbType.Int32, Size = 4 },
                    new SqlParameter { ParameterName = AllParams.Output, Direction = ParameterDirection.Output, DbType = DbType.Int32, Size = 4 }
                }.ToDynamicParameters();

                var reader = cnn.ExecuteReader(AllStoredProcedures.GetAdvertisingCount, param: param, commandType: CommandType.StoredProcedure);

                return param.Get<int>(AllParams.Output);
            }
        }
    }
}
