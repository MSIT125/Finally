using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebIndexHotel.ViewModels;
using WebIndexHotel.Models;

namespace WebIndexHotel.Models
{
    public class 訂房搜尋引擎
    {
       public static dbHotelTest_2020_03_03Entities db = new dbHotelTest_2020_03_03Entities();
        
           
        public static List<RoomType> 搜尋空房資料(訂房條件 qc, List<Orders> order_conditioin)
        {
            //dbHotelEntities db = new dbHotelEntities();
            List<RoomType> list = new List<RoomType>();
            var daysearchin = Convert.ToDateTime(qc.date_in);
            var daysearchout = Convert.ToDateTime(qc.date_out);
            var duration = (daysearchout - daysearchin).Days;
            //var 標準雙人房數量 = db.RoomInformation.Where(p=>p.RoomTypeID==1).Select(g=>g).Count()-db.Orders.Where(q=>q.RoomTypeID==1 && q.CheckInDate== daysearchin).Select(q => q).Count();
            //var 標準家庭房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 2).Select(g => g).Count() - db.Orders.Where(q => q.RoomTypeID == 2 && q.CheckInDate== daysearchin).Select(q => q).Count();
            //var 豪華雙人房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 3).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 3 && q.CheckInDate== daysearchin).Select(q => q).Count();
            //var 豪華家庭房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 4).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 4 && q.CheckInDate== daysearchin).Select(q => q).Count();
            //var 總統套房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 5).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 5 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 標準雙人房 = check_having_room(daysearchin, daysearchout, 1);
            var 標準家庭房 = check_having_room(daysearchin, daysearchout, 2);
            var 豪華雙人房 = check_having_room(daysearchin, daysearchout, 3);
            var 豪華家庭房 = check_having_room(daysearchin, daysearchout, 4);
            var 總統套房 = check_having_room(daysearchin, daysearchout, 5);

            if (標準雙人房 && Convert.ToInt32(qc.guest) < 3)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 1).Select(p => p).First());
            }
            //else { Console.WriteLine("無標準雙人房"); }

            if (標準家庭房)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 2).Select(p => p).First());
            }
            //else { Console.WriteLine("無標準家庭房"); }

            if (豪華雙人房 && Convert.ToInt32(qc.guest) < 3)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 3).Select(p => p).First());
            }
            //else { Console.WriteLine("無豪華雙人房"); }

            if (豪華家庭房)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 4).Select(p => p).First());
            }
            //else { Console.WriteLine("無豪華家庭房"); }

            if (總統套房 && Convert.ToInt32(qc.guest) < 3)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 5).Select(p => p).First());
            }
            //else { Console.WriteLine("總統套房"); }

            return list;
        }

        public static bool check_having_room(DateTime daysearchin, DateTime daysearchout, int roomtype_id)
        {

            int count;
            Double check = 1;

            //var total = new TimeSpan(daysearchout.Ticks - daysearchin.Ticks).TotalDays;
            var total = (daysearchout - daysearchin).Days;
            for (int i = 0; i < total; i++)
            {
                var date = daysearchin.AddDays(i);
                var q = db.Orders.Where(datebetween => (
                (DateTime.Compare((DateTime)datebetween.CheckInDate, date) < 0)
                &&
                (DateTime.Compare((DateTime)datebetween.CheckOutDate, date) > 0)
                ||
                (DateTime.Compare((DateTime)datebetween.CheckInDate, date) == 0))
                && datebetween.RoomTypeID == roomtype_id
                ).Select(p => p.CustomerName).ToList();


                var qty = db.RoomType.Where(type => type.RoomTypeID == roomtype_id).Select(r => r.RoomQty).First().Value;
                count = qty - q.Count();
                check = check * count;
            }

            if (check != 0) { return true; }
            else { return false; }

        }


    }
}