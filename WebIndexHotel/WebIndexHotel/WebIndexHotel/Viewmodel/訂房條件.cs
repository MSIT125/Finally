using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIndexHotel.ViewModels
{
    public class 訂房條件
    {
        public string date_in{ get; set; }
        public string date_out { get; set; }
        public string guest { get; set; }
        public string room { get; set; }
    }
}