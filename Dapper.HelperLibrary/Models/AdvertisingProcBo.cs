using System;

namespace Dapper.HelperLibrary.Models
{
    public class AdvertisingProcBo
    {
        public int AdvertisingId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int GroupTypes { get; set; }
        public bool Enabled { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string RoomTypes { get; set; }
        public string RateTypes { get; set; }
        public string Enhancements { get; set; }
    }
}
