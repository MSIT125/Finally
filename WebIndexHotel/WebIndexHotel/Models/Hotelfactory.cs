using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebIndexHotel.Viewmodel;
using WebIndexHotel.Model;
using System.Collections;

namespace WebIndexHotel.Models
{
    public class Hotelfactory
    {
        dbHotelTest_3_2_2020Entities db = new dbHotelTest_3_2_2020Entities();

        public List<roomtypes> getall()
        {
            List<roomtypes> list = new List<roomtypes>();
            var table = from p in db.RoomType  select p;
            foreach (var item in table)
            {
                roomtypes x = new roomtypes();
                x.RoomtypeID = item.RoomTypeID;
                x.RoomTypeNameCN = item.RoomTypeNameCN.ToString();
                x.UnitPrice_Holiday= (Convert.ToInt32(item.UnitPrice_Holiday));
                x.UnitPrice_Normal = (Convert.ToInt32(item.UnitPrice_Normal));
                list.Add(x);
            }

            return list;
        }

        public roomtypes room (string name)
        {
             roomtypes x = new roomtypes();
             var table = from p in db.RoomType where p.RoomTypeNameCN == name select p;



            ArrayList dateList = new ArrayList();
            int count;
            var date = DateTime.Today;

           
            int roomtypeid = db.RoomType.Where(q => q.RoomTypeNameCN == name).Select(q => q.RoomTypeID).FirstOrDefault();

            for (int i = 0; i < 60; i++)
            {             
                var dates = date.AddDays(i);
                var q = db.Orders.Where(datebetween => ((DateTime.Compare((DateTime)(datebetween.CheckInDate), dates) < 0)
                && (DateTime.Compare((DateTime)(datebetween.CheckOutDate), dates) > 0)
                 || (DateTime.Compare((DateTime)(datebetween.CheckInDate), dates) == 0))
                && datebetween.RoomTypeID == roomtypeid
                ).Select(p => p.CustomerName).ToList();


                var qty = db.RoomType.Where(type => type.RoomTypeNameCN == name).Select(r => r.RoomQty).FirstOrDefault().Value;
                count = qty - q.Count();
               
               
                dateList.Add(count);

            }
            x.dateQty = dateList;

            foreach (var item in table)
            {
                x.RoomtypeID = item.RoomTypeID;
                x.RoomTypeNameCN = item.RoomTypeNameCN.ToString();
                x.UnitPrice_Normal = (Convert.ToInt32(item.UnitPrice_Normal));
                x.UnitPrice_Holiday= (Convert.ToInt32(item.UnitPrice_Holiday));
                x.RoomImg = item.RoomTypeImg;
            }

            return x;
        }

        public int datecheck(string datein,string dateout,int roomid)
        {
            int count;
            int check = 1;
            var Datein = Convert.ToDateTime(datein);
            var Dateout= Convert.ToDateTime(dateout);
           
            var total = new TimeSpan(Dateout.Ticks - Datein.Ticks).TotalDays;
            for (int i = 0; i < total; i++)
            {
                var date = Datein.AddDays(i);
                var q = db.Orders.Where(datebetween => ((DateTime.Compare((DateTime)(datebetween.CheckInDate), date) < 0)
               && (DateTime.Compare((DateTime)(datebetween.CheckOutDate), date) > 0)
                || (DateTime.Compare((DateTime)(datebetween.CheckInDate), date) == 0))
               && datebetween.RoomTypeID == roomid
               ).Select(p => p.CustomerName).ToList();


                var qty = db.RoomType.Where(type => type.RoomTypeID == roomid).Select(r => r.RoomQty).First().Value;
                count = qty - q.Count();
                check = check * count;
            }

            return check;
        }
        public List<Discount> Discounts()
        {
            var date = DateTime.Today;
            List<Discount> discounts = new List<Discount>();

            var table = from p in db.DiscountCode where p.StartTime < date && p.EndTime > date || p.StartTime == date select p;
            foreach (var item in table)
            {
                Discount d = new Discount();
                d.DiscountCode = item.DiscountCode1;
                d.Dollar = Convert.ToDouble(item.Dollar);
                d.StartTime = Convert.ToDateTime(item.StartTime);
                d.EndTime = Convert.ToDateTime(item.EndTime);
                d.Percentage = Convert.ToDouble(item.Percentage);
                d.HotelID = Convert.ToInt32(item.HotelID);

                d.RoomtypeID = Convert.ToInt32(item.RoomTypeID);
                if (Convert.ToInt32(item.RoomTypeID) != 0)
                {
                    d.Roomtypename = item.RoomType.RoomTypeNameCN;
                    d.roomurl = $"/Home/各房型?name={item.RoomType.RoomTypeNameCN}";

                }
                else
                {
                    d.roomurl = "/Home/總房型";
                }
                discounts.Add(d);
            }

            return discounts;
        }


    }
}