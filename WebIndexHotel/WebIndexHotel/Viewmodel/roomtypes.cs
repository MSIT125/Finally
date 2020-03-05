using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebIndexHotel.Model
{
    public class roomtypes
    {
        public int RoomtypeID { get; set; }
        public string RoomTypeNameCN { get; set; }
        public string RoomImg { get; set; }
        public int UnitPrice_Normal { get; set; }
        public int UnitPrice_Holiday { get; set; }
        public int RoomQty { get; set; }
        public ArrayList dateQty { get; set; }
        public int RoomGuests { get; set; }
    }
}