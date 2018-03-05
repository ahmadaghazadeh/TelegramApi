using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telegram.Bot;

namespace TelegramBot.Controllers
{
    public class HomeController : Controller
    {
        private  static readonly  TelegramBotClient Bot=new TelegramBotClient("504837523:AAFdBl2L67i_4x_xEgDownwxyH0YpYmdSUg");
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}