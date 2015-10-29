using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace MvcDemo.Controllers
{
    public class CustomerController : Controller
    {
        XINEntities db;
        //
        // GET: /Customer/
        public CustomerController()
        {
            db = new XINEntities();
        }
        public ActionResult Index()
        {
            var datas = db.Customer;
            return View(datas);
        }

    }
}
