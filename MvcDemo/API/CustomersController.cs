using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.ViewModels;
using BLL.Services;

namespace MvcDemo.API
{
    public class CustomersController : ApiController
    {
        private CustomerService service;
        public CustomersController()
        {
            service = new CustomerService();
        }
        // GET api/customers
        public HttpResponseMessage Get()
        {
            try
            {
                var datas = service.Get();
                return Request.CreateResponse(HttpStatusCode.OK, datas);
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
                int TotalRow = 0;
                var datas = service.Get(CurrentPage,PageSize,out TotalRow);
                var Rvl = new { Total = TotalRow, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }

        }       

        // GET api/customers/5
        public HttpResponseMessage Get(string CustomerID)
        {
            try
            {
                var data = service.Get(CustomerID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        // POST api/customers
        public HttpResponseMessage Post(CustomerViewModel model)
        {
            try
            {
                service.AddCustomer(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }
        }

        // PUT api/customers/5
        public HttpResponseMessage Put(CustomerViewModel model)
        {
            try
            {
                service.SaveCustomer(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }
        }

        // DELETE api/customers/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                service.DeleteCustomer(id.ToString());
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }
        }
    }
}
