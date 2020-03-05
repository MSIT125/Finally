using System;
using System.Collections.Generic;
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
       
        public static List<WebIndexHotel.Models.RoomType> 搜尋空房資料(訂房條件 qc,List<Orders> order_conditioin)
        {
            dbHotelEntities db = new dbHotelEntities();
            List<RoomType> list = new List<RoomType>();
            var 標準雙人房數量 = /*db.RoomInformation.Where(p=>p.RoomTypeID==1).Select(g=>g).Count()*/8-db.Orders.Where(q=>q.RoomTypeID==1 && ((DateTime)q.CheckInDate).ToString() == qc.date_in).Select(q => q).Count();
            var 標準家庭房數量 = /*db.RoomInformation.Where(p => p.RoomTypeID == 2).Select(g => g).Count()*/4 - db.Orders.Where(q => q.RoomTypeID == 2 && ((DateTime)q.CheckInDate).ToString()==qc.date_in).Select(q => q).Count();
            var 豪華雙人房數量 = /*db.RoomInformation.Where(p => p.RoomTypeID == 3).Select(g => g).Count()*/8 - db.Orders.Where(q => q.RoomTypeID == 3 && ((DateTime)q.CheckInDate).ToString() == qc.date_in).Select(q => q).Count();
            var 豪華家庭房數量 = /*db.RoomInformation.Where(p => p.RoomTypeID == 4).Select(g => g).Count()*/4 - db.Orders.Where(q => q.RoomTypeID == 4 && ((DateTime)q.CheckInDate).ToString() == qc.date_in).Select(q => q).Count();
            var 總統套房數量 = /*db.RoomInformation.Where(p => p.RoomTypeID == 5).Select(g => g).Count()*/ 2- db.Orders.Where(q => q.RoomTypeID == 5 && ((DateTime)q.CheckInDate).ToString() == qc.date_in).Select(q => q).Count();

            if(標準雙人房數量> 0 && Convert.ToInt32(qc.guest) < 3)
            {
               list.Add(db.RoomType.Where(p => p.RoomTypeID == 1).First()); 
                
            }
            //else { Console.WriteLine("無標準雙人房"); }

            if (標準家庭房數量 > 0)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 2).First());
            }
            //else { Console.WriteLine("無標準家庭房"); }

            if (豪華雙人房數量 > 0 && Convert.ToInt32(qc.guest) < 3)
            {
               
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 3).First()); 
            }
            //else { Console.WriteLine("無豪華雙人房"); }

            if (豪華家庭房數量 > 0)
            {
                list.Add(db.RoomType.Where(p => p.RoomTypeID == 4).First());
            }
            //else { Console.WriteLine("無豪華家庭房"); }

            if (總統套房數量 > 0 && Convert.ToInt32(qc.guest) < 3)
            {              
                    list.Add(db.RoomType.Where(p => p.RoomTypeID == 5).First());
            }
            //else { Console.WriteLine("總統套房"); }

            return list;
        }

       
    }
}