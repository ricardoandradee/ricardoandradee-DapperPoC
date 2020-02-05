using Dapper.DataAccess;
using Dapper.HelperLibrary.BusinessObjects;
using Dapper.HelperLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Business
{
    public class AdvertisingBusiness
    {
        private AdvertisingDB _db;

        public AdvertisingBusiness()
        {
            _db = new AdvertisingDB();
        }

        public List<AdvertisingProcBo> GetAdvertisingList(int clientId, int languageId, bool filterDisabledRows)
        {
            var advertisingList = _db.GetList(new List<SqlParameter>
            {
                new SqlParameter { ParameterName = AllParams.ClientId, SqlValue = clientId, DbType = DbType.Int32, Size = 4 },
                new SqlParameter { ParameterName = AllParams.LanguageId, SqlValue = languageId, DbType = DbType.Int32, Size = 4 },
                new SqlParameter { ParameterName = AllParams.FilterDisabledRows, SqlValue = filterDisabledRows, DbType = DbType.Boolean, Size = 1 }
            });

            return advertisingList;
        }

    }
}
