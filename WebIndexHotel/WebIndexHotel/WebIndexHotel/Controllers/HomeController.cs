using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIndexHotel.Model;
using WebIndexHotel.Models;
using WebIndexHotel.Viewmodel;
using WebIndexHotel.ViewModels;

namespace WebIndexHotel.Controllers
{
    public class HomeController : Controller
    {

        dbHotelEntities db = new dbHotelEntities();

        public ActionResult Index()
        {
            var table = from p in db.RoomType select p;
            return View(table);
        }

        [HttpPost]
        public ActionResult Index(訂房條件 qc)
        {
            if (qc != null)
            {
                dbHotelEntities db = new dbHotelEntities();
                var daysearchin = Convert.ToDateTime(qc.date_in);
                var order_condition = (from p in db.Orders where p.OrderDate == daysearchin select p).ToList();
                var result_room = 訂房搜尋引擎.搜尋空房資料(qc, order_condition);

                return View(qc, order_condition);

            }
            else {               
return RedirectToAction("Index");
            }
                
        }

        public ActionResult 關於我們()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult 總房型()
        {
            Hotelfactory hf = new Hotelfactory();
            return View(hf.getall());
        }

        
       
        public ActionResult 最新優惠()
        {
            return View();
        }

        public ActionResult 各房型(string name)
        {
            roomtypes r = new Hotelfactory().room(name);
            if (r == null)
                return RedirectToAction("總房型");
            return View(r);
        }

        public ActionResult 房型清單()
        {
            return PartialView(db.RoomType.ToList());
        }

        public ActionResult 訂房搜尋(List<RoomType> rr)
        {
            return View(rr);
        }
    }
}