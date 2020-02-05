using Dapper.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.UnitTest
{
    [TestClass]
    public class DataBaseUnitTest
    {
        [TestMethod]
        public void GetAdvertisingDataDB()
        {
            //    AdvertisingDataDB db = new AdvertisingDataDB();

            //    var advertisingDataDB = db.GetOne(new List<SqlParameter>
            //    {
            //        new SqlParameter { ParameterName = AllParams.AdvertisingId, SqlValue = 57, DbType = DbType.Int32, Size = 4 },
            //        new SqlParameter { ParameterName = AllParams.LanguageId, SqlValue = 1, DbType = DbType.Int32, Size = 4 }
            //    });

            //dataDb.UpdateAdvertisingData(new List<SqlParameter>
            //{
            //    new SqlParameter { ParameterName = AllParams.AdvertisingId, SqlValue = advertisingDataDB.AdvertisingId, DbType = DbType.Int32, Size = 4 },
            //    new SqlParameter { ParameterName = AllParams.LanguageId, SqlValue = advertisingDataDB.LanguageId, DbType = DbType.Int32, Size = 4 },
            //    new SqlParameter { ParameterName = AllParams.Title, SqlValue = advertisingDataDB.Title, DbType = DbType.String, Size = 300 },
            //    new SqlParameter { ParameterName = AllParams.Content, SqlValue = advertisingDataDB.Content, DbType = DbType.String, Size = -1 }
            //});

            //var result = db.AddAdvertisingData(new List<SqlParameter>
            //{
            //    new SqlParameter { ParameterName = AllParams.AdvertisingId, SqlValue = 57, DbType = DbType.Int32, Size = 4 },
            //    new SqlParameter { ParameterName = AllParams.LanguageId, SqlValue = 3, DbType = DbType.Int32, Size = 4 },
            //    new SqlParameter { ParameterName = AllParams.Title, SqlValue = "Ricardo", DbType = DbType.String, Size = 300 },
            //    new SqlParameter { ParameterName = AllParams.Content, SqlValue = "Ricardo", DbType = DbType.String, Size = -1 },
            //    new SqlParameter { ParameterName = AllParams.AdvertisingDataId, Direction = ParameterDirection.Output, DbType = DbType.Int32, Size = 4 }
            //});

        }

        [TestMethod]
        public void GetAdvertisingDB()
        {
            AdvertisingBusiness db = new AdvertisingBusiness();
            var advertisingList = db.GetAdvertisingList(147, 1, false);

        }
    }
}
