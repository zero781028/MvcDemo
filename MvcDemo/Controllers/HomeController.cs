using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private OrderService service;
        public HomeController()
        {
            service = new OrderService();
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int TotalRow = 0;
            var datas = service.Get(out TotalRow);
            ViewData["TotalRow"] = TotalRow;
            return View();
        }

    }
}
