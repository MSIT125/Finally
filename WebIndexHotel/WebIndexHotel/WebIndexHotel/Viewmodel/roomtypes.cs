using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.Model
{
    public class roomtypes
    {
        public string RoomTypeNameCN { get; set; }
        public string RoomImg { get; set; }
        public int UnitPrice_Normal { get; set; }
        public int UnitPrice_Holiday { get; set; }
    }
}