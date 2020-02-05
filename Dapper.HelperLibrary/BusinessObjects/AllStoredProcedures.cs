namespace Dapper.HelperLibrary.BusinessObjects
{
    public static class AllStoredProcedures
    {
        //AdvertisingDataDB
        public const string GetAdvertisingData = "dbo.GetAdvertisingdata";
        public const string UpdateAdvertisingData = "dbo.UpdateAdvertisingdata";
        public const string AddAdvertisingData = "dbo.AddAdvertisingdata";

        //AdvertisingsDB
        public const string AddAdvertising = "dbo.AddAdvertising";
        public const string GetAdvertising = "dbo.GetAdvertising";
        public const string UpdateAdvertising = "dbo.UpdateAdvertising";
        public const string UpdateAdvertisingEnabled = "dbo.UpdateAdvertisingEnabled";
        public const string DeleteAdvertising = "dbo.DeleteAdvertising";
        public const string GetAdvertisingCount = "dbo.GetAdvertisingCount";
        public const string GetAdvertisingList = "dbo.GetAdvertisingList";

    }
}
