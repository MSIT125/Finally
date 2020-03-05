using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebIndexHotel.Models
{
    public class OrderFactory
    {

        private dbHotelTest_2020_03_03Entities db;

        public OrderFactory()
        {
            db = new dbHotelTest_2020_03_03Entities();
        }

        //create ORDERS
        public void CreateOrderData(int MemberID, int HotelID, string RoomTypeNameCN, DateTime CheckInDate, DateTime CheckOutDate,
            int Duration, decimal Price, string CustomerName, string CustomerEmail, string PhoneNumber, string Payment, string CardOwner,
            string CreditCardNumber, string CreditCardCode, int OfferBreakfast, int AddBed, string DiscountCode, decimal money)
        {
            Orders o = new Orders();
            PayInfo p = new PayInfo();

            o.MemberID = MemberID;
            o.OrderDate = DateTime.Now;
            o.HotelID = HotelID;
            //o.RoomTypeID = RoomTypeID;
            o.RoomTypeID = GetRoomTypeName(RoomTypeNameCN);
            o.CheckInDate = CheckInDate;
            o.CheckOutDate = CheckOutDate;
            o.Duration = Duration;
            o.Price = money;
            o.CustomerName = CustomerName;
            o.CustomerEmail = CustomerEmail;
            o.CustomerPhone = PhoneNumber;
            o.Payment = Payment;
            o.OfferBreakfast = OfferBreakfast;
            o.AddBed = AddBed;
            o.DiscountCode = DiscountCode;
           

            p.CardOwner = CardOwner;
            p.CreditCardNumber = CreditCardNumber;
            p.CreditCardCode = CreditCardCode;
            p.CardExp = DateTime.Now;

            o.PayInfoID = p.PayInfoID;

            db.Orders.Add(o);
            db.PayInfo.Add(p);

            db.SaveChanges();
        }

        //顯示房名
        public int GetRoomTypeName(string roomTypeNameCN)
        {

            var RoomName = db.RoomType.Where(r => r.RoomTypeNameCN == roomTypeNameCN).FirstOrDefault();

            return RoomName.RoomTypeID;
        }

        //撈訂單編號-用於"檢視訂單結果"
        public Orders GetOrderID(int memberID)
        {
            var odID = db.Orders.Where(o => o.MemberID == memberID)
                .OrderByDescending(o => o.OrderDate)
                .ToList().FirstOrDefault();
            return odID;
        }

        //撈discountCode-驗證折扣碼用

    }
}