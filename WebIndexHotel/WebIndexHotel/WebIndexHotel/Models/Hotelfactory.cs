using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebIndexHotel.Viewmodel;
using WebIndexHotel.Model;
namespace WebIndexHotel.Models
{
    public class Hotelfactory
    {
        dbHotelEntities db = new dbHotelEntities();

        public List<roomtypes> getall()
        {
            List<roomtypes> list = new List<roomtypes>();
            var table = from p in db.RoomType  select p;
            foreach (var item in table)
            {
                roomtypes x = new roomtypes();
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

            foreach (var item in table)
            {
               
                x.RoomTypeNameCN = item.RoomTypeNameCN.ToString();
                x.UnitPrice_Normal = (Convert.ToInt32(item.UnitPrice_Normal));
                x.UnitPrice_Holiday= (Convert.ToInt32(item.UnitPrice_Holiday));
            }

            return x;
        }

    }
}