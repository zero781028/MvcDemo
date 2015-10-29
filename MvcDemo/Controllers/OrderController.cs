using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace MvcDemo.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private OrderService serivce;
        public OrderController()
        {
            serivce = new OrderService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Export(string type)
        {
            LocalReport lr = new LocalReport();
            int TotalRow;
            string path = Path.Combine(Server.MapPath("~/Rdlc"), "rdlcOrders.rdlc");
            lr.ReportPath = path;
            var list = serivce.Get(out TotalRow);

            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            lr.DataSources.Add(rd);

            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo;

            deviceInfo = "<DeviceInfo>" +
            "  <OutputFormat>" + type + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] stream;
            byte[] renderBytes;

            renderBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out stream, out warnings);

            return File(renderBytes, mimeType, "Report");
        }

    }
}
