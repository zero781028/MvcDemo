using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.ViewModels;
using BLL.Services;

namespace MvcDemo.Controllers
{
    public class MemberExchangeController : Controller
    {
        
        private StoreService storeSerivce;
        private MemberExchangeService exchangeService;
        public MemberExchangeController()
        {
            storeSerivce = new StoreService();
            exchangeService = new MemberExchangeService();
        }

        //
        // GET: /MemberExchange/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductExchange()
        {
            var storeList = storeSerivce.GetStoreList();
            
            storeList.Add(new StoreViewModel()
            {
                STNID=string.Empty,
                STNNAME="全選"
            });
            storeList = storeList.OrderBy(s => s.STNID).ToList();
            SelectList selectList = new SelectList(storeList, "STNID", "STNNAME","");
            ViewBag.StoreSelectList = selectList;
            return View();
        }

        [HttpPost]
        public ActionResult ProductExchange(string STNID, string stdate, string eddate)
        {
            var storeList = storeSerivce.GetStoreList();            
            var model = exchangeService.GetProductExchangeList(STNID, stdate, eddate);

            
            storeList.Add(new StoreViewModel()
            {
                STNID = string.Empty,
                STNNAME = "全選"
            });
            storeList = storeList.OrderBy(s => s.STNID).ToList();
            SelectList selectList = new SelectList(storeList, "STNID", "STNNAME", STNID);
            ViewBag.StoreSelectList = selectList;
            
            return View(model);            
        }
    }
}
