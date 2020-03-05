using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.Models
{
    public class LOrders
    {

        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int HotelID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomTypeID { get; set; }
        public string Payment { get; set; }
        public decimal Price { get; set; }
        public double DiscountCode { get; set; }
        public string OrderState { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int Duration { get; set; }
        public int OfferBreakfast { get; set; }
        public int AddBed { get; set; }
        public int RoomID { get; set; }
        public int PayInfoID { get; set; }



    }
}