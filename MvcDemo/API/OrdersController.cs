using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace MvcDemo.API
{
    public class OrdersController : ApiController
    {
        
        private OrderService service;
        private OrderDetailService detail_service;
        public OrdersController()
        {
            service = new OrderService();
            detail_service = new OrderDetailService();
        }

        // GET api/orders
        public HttpResponseMessage Get()
        {
            try
            {
                int total = 0;
                var datas = service.Get(out total);
                var Rvl = new { Total = total, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        public HttpResponseMessage Get(int CurrentPage,int PageSize)
        {
            try
            {
                int total = 0;
                var datas = service.Get(CurrentPage,PageSize,out total);
                var Rvl = new { Total = total, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        // GET api/orders/5
        public HttpResponseMessage Get(string DeliveryID)
        {
            try
            {
                int total = 0;
                var datas = detail_service.GetDetail(DeliveryID, out total);
                var Rvl = new { Total = total, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

       
    }
}
