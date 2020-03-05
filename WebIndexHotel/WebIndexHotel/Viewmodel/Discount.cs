using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.Viewmodel
{
    public class Discount
    {
        public string DiscountCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Double Dollar { get; set; }
        public Double Percentage { get; set; }
        public int HotelID { get; set; }
        public int RoomtypeID { get; set; }
        public string Roomtypename { get; set; }
        public string roomurl { get; set; }
    }
}