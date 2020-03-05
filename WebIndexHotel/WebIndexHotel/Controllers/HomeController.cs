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
    [RequireHttps]
    public class HomeController : Controller
    {

        dbHotelTest_3_2_2020Entities db = new dbHotelTest_3_2_2020Entities();
        OrderFactory of =new OrderFactory();

       
        public ActionResult Index()
        {
            var table = from p in db.RoomType select p;
            List<roomtypes> x = new List<roomtypes>();
            Hotelfactory hf = new Hotelfactory();
            ViewBag.discount = hf.Discounts();
            foreach (var item in table)
            {roomtypes r = new roomtypes();
                r.RoomTypeNameCN = item.RoomTypeNameCN;
                r.RoomtypeID = item.RoomTypeID;
                r.RoomImg = item.RoomTypeImg;
                r.UnitPrice_Holiday = Convert.ToInt32(item.UnitPrice_Holiday);
                r.UnitPrice_Normal = Convert.ToInt32(item.UnitPrice_Normal);
                r.RoomGuests = item.RoomGuests;
                x.Add(r);
            }

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="1",Value="1"},
                new SelectListItem(){ Text="2",Value="2"},
                new SelectListItem(){ Text="3",Value="3"},
                new SelectListItem(){ Text="4",Value="4"}

            };
            ViewBag.guestselect = items;

            List<SelectListItem> items2 = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="1",Value="1"},
                new SelectListItem(){ Text="2",Value="2"}


            };
            ViewBag.roomselect = items2;
            Session["qcin"] = DateTime.Today.ToString("yyyy-MM-dd");
            Session["qcout"] = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            Session["customer"] = 2;
            ViewBag.roomtype = x;
            return View();
        }

        [HttpPost]
        public ActionResult Index(訂房條件 qc)
        {
            if (qc != null)
            {
                Session["qcin"] = qc.date_in;
                Session["qcout"] = qc.date_out;

                Session["customer"] = Convert.ToInt32(qc.guest);
                
                var daysearchin = Convert.ToDateTime(qc.date_in);
                var order_condition = (from p in db.Orders where p.OrderDate == daysearchin select p).ToList();
                var result_room = 訂房搜尋引擎.搜尋空房資料(qc, order_condition);

                return View("訂房搜尋", result_room);
            }
            else
            {
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
            Hotelfactory hf = new Hotelfactory();
            return View(hf.Discounts());
        }
       
        public ActionResult 各房型(string name)
        {
            
            roomtypes r = new Hotelfactory().room(name);
            if (r == null)
                return RedirectToAction("總房型");
            Session["od_type"] = name;
          
            return View(r);
        }

        [HttpPost]
        public ActionResult 各房型(訂單資料 orders_data)
        {
            
            var D_in = Convert.ToDateTime(orders_data.date_in);
            var D_out = Convert.ToDateTime(orders_data.date_out);
            var selected_Type = Session["od_type"].ToString();
            var q = db.RoomType.Where(p => p.RoomTypeNameCN == selected_Type).Select(p => p).First();
            //if (Session["login"] != null)
            //{
            Session["qcin"] = orders_data.date_in;
            Session["qcout"] = orders_data.date_out;
            Session["od_qty"] = orders_data.room_qty;
            Session["memberID"] = 1;
            Session["orderDate"] = DateTime.Now.ToString();
            Session["hotelID"] = 1;
            Session["duration"] = (D_out - D_in).Days;
            Session["Normalprice"] = q.UnitPrice_Normal;
            Session["Holidayprice"] = q.UnitPrice_Holiday;
            Session["offerBreakfast"] = Session["customer"];
            Session["addBed"] = 0;
            var roomid=db.RoomType.Where(p => p.RoomTypeID == q.RoomTypeID).Select(p=>p.RoomTypeID).First();
            Session["Roomtypeid"] = roomid;
       
              return View("訂房頁面");
         
            //TODO訂購流程
            //}
            //else { return RedirectToAction("Login"); }
        }

        public ActionResult 房型清單()
        {
            return PartialView(db.RoomType.ToList());
        }

        public ActionResult 訂房搜尋(List<RoomType> result_input)
        {
            return View(result_input);
        }
       
        public ActionResult 訂房頁面(LOrders data)
        {
          
         
            return View();
        }


        //  訂房頁面POST
        [HttpPost]
        public ActionResult 訂房頁面(int MemberID, DateTime OrderDate, int HotelID, string RoomTypeNameCN, DateTime CheckInDate, DateTime CheckOutDate,
            int Duration, decimal Price, string CustomerName, string CustomerEmail, string PhoneNumber, string Payment, string CardOwner, string CreditCardNumber,
            string CreditCardCode, int OfferBreakfast, int AddBed)
        {
            of.CreateOrderData(MemberID, HotelID, RoomTypeNameCN, CheckInDate, CheckOutDate, Duration, Price, CustomerName, CustomerEmail,
                PhoneNumber, Payment, CardOwner, CreditCardNumber, CreditCardCode, OfferBreakfast, AddBed);

            var OrderDetail = of.GetOrderID(MemberID);

            return View("檢視訂單結果", OrderDetail);
        }

        //用AJAX同步會員資料==========================
        public ActionResult 撈會員資料(int MemberID)
        {
           
            var memberData = db.Members.Where(num => num.MemberID == MemberID).Select(m => new
            {
                m.MemberID,
                m.FirstName,
                m.LastName,
                m.Email,
                m.PhoneNumber,
                m.PersonalIDNumber
            });
            return Json(memberData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult 驗證訂單折扣碼(string DiscountCode1)
        {
            string dcVertify = DiscountCode1;

            var codeVerify = db.DiscountCode.Where(date => date.StartTime < DateTime.Now && date.EndTime > DateTime.Now && date.DiscountCode1 == dcVertify).Select(c => new
            {
                c.DiscountID,
                c.DiscountCode1,
                c.HotelID,
                c.Dollar,
                c.Percentage
            });

            return Json(codeVerify, JsonRequestBehavior.AllowGet);

        }

        public ActionResult 訂房結算金額(int MONEY, int DCASH, double DPERCENT)
        {
            var m = Convert.ToInt32(MONEY);
            var d = Convert.ToInt32(DCASH);
            var p = Convert.ToDouble(DPERCENT);
            return Content(((m - d) * p).ToString());
        }

        public ActionResult 檢視訂單結果(Orders data)
        {
            //var OrderDetail = of.GetOrderID(MemberID);
            return RedirectToAction("訂房頁面");
        }

        public ActionResult 檢查日期(DateTime datein, DateTime dateout, int roomid)
        {
            int count;
            Double check = 1;
            var Datein = Convert.ToDateTime(datein);
            var Dateout = Convert.ToDateTime(dateout);

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

            return Json(check, JsonRequestBehavior.AllowGet); 
        }


    }
}