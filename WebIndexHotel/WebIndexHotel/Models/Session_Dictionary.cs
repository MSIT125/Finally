using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.Models
{
    public class Session_Dictionary
    {
        public static readonly string qcin = "qcin";//入住日期(預設日期Today)
        public static readonly string qcout = "qcout";//退房日期(預設日期Tomorrow)
        public static readonly string customer = "customer";//入住人數
        public static readonly string od_type = "od_type";//預定房型
        public static readonly string od_qty = "od_qty";//訂房數量
        public static readonly string memberID = "memberID";//會員ID
        public static readonly string orderDate = "orderDate";//訂單日期
        public static readonly string hotelID = "hotelID";//分館編號
        public static readonly string duration = "duration";//天數
        public static readonly string Normalprice = "Normalprice";//平日價格
        public static readonly string Holidayprice = "Holidayprice";//假日價格
        public static readonly string offerBreakfast = "offerBreakfast";//早餐數量(預設同入住人數)
        public static readonly string addBed = "addBed";//加床(預設0)
        public static readonly string Roomtypeid = "Roomtypeid";//房型ID
        public static readonly string finalPrice = "finalPrice";//訂單頁面價格
        public static readonly string login = "login";//登入用

    }
}