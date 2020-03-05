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
       
        public static List<RoomType> 搜尋空房資料(訂房條件 qc,List<Orders> order_conditioin)
        {
            dbHotelTest_3_2_2020Entities db = new dbHotelTest_3_2_2020Entities();
            List<RoomType> list = new List<RoomType>();
            var daysearchin = Convert.ToDateTime(qc.date_in);
            var daysearchout = Convert.ToDateTime(qc.date_out);
            var duration = (daysearchout - daysearchin).Days;
            var 標準雙人房數量 = db.RoomInformation.Where(p=>p.RoomTypeID==1).Select(g=>g).Count()-db.Orders.Where(q=>q.RoomTypeID==1 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 標準家庭房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 2).Select(g => g).Count() - db.Orders.Where(q => q.RoomTypeID == 2 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 豪華雙人房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 3).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 3 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 豪華家庭房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 4).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 4 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 總統套房數量 = db.RoomInformation.Where(p => p.RoomTypeID == 5).Select(g => g).Count()- db.Orders.Where(q => q.RoomTypeID == 5 && q.CheckInDate== daysearchin).Select(q => q).Count();
            var 有沒有標準雙人房 = check_having_room(daysearchin, daysearchout, duration, 1);
                       

            if (標準雙人房數量> 0 && Convert.ToInt32(qc.guest) < 3)
            {
               list.Add(db.RoomType.Where(p => p.RoomTypeID == 1).Select(p=>p).First());                 
            }
            //else { Console.WriteLine("無標準雙人房"); }

            if (標準家庭房數量 > 0)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 2).Select(p => p).First());
            }
            //else { Console.WriteLine("無標準家庭房"); }

            if (豪華雙人房數量 > 0 && Convert.ToInt32(qc.guest) < 3)
            {               
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 3).Select(p => p).First()); 
            }
            //else { Console.WriteLine("無豪華雙人房"); }

            if (豪華家庭房數量 > 0)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 4).Select(p => p).First());
            }
            //else { Console.WriteLine("無豪華家庭房"); }

            if (總統套房數量 > 0 && Convert.ToInt32(qc.guest) < 3)
            {              
                    list.Add(db.RoomType.Where(p => p.RoomTypeID == 5).Select(p => p).First());
            }
            //else { Console.WriteLine("總統套房"); }

            return list;
        }

        public static bool check_having_room(DateTime daysearchin, DateTime daysearchout, int duration, int roomtype_id)
        {
            dbHotelTest_3_2_2020Entities db = new dbHotelTest_3_2_2020Entities();
            var Total_qty = db.RoomType.Where(p => p.RoomTypeID == roomtype_id).Select(q => q.RoomQty).FirstOrDefault();
            var Ordered_period = db.Orders.Where(q => q.RoomTypeID == roomtype_id && (q.CheckInDate<=daysearchin||q.CheckOutDate>=daysearchout)).Select(q => new{ q.CheckInDate,q.CheckOutDate }).ToList();
           
            int i,j,k, r = 0;
            for (i = 0; i < duration; i++)
                {

                }
            foreach(var item in Ordered_period)
            {
               
            }

            if (r != 0) { return true; }
            else {  return false;}
           
        }

       
    }
}