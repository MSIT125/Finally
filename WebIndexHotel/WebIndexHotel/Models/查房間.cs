using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.Models
{
    public class 查房間
    {
        public string RoomTypeID{get;set;}
        public string RoomTypeNameEN { get; set; }
        public string RoomTypeNameCN { get; set; }
        public string RoomGuests { get; set; }
        public string UnitPrice_Normal { get; set; }
        public string UnitPrice_Holiday { get; set; }
        public string RoomQty { get; set; }
        public string RegisterDate { get; set; }
        public string CanAddBed { get; set; }
        public string OfferBreakfast { get; set; }
        public string IsLocking { get; set; }


    }
}