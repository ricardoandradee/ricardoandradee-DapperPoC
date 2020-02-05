using System.Configuration;

namespace Dapper.HelperLibrary
{
    public static class Tools
    {
        public static string GetConnectionString(string name = "connectionString")
        {
            var conn = ConfigurationManager.ConnectionStrings[name];
            return string.IsNullOrWhiteSpace(conn?.ConnectionString) ? ConfigurationManager.AppSettings["connectionString"] : conn.ConnectionString;
        }
    }
}
