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
    public class MemberExchangesController : ApiController
    {
        private MemberExchangeService service;
        public MemberExchangesController()
        {
            service = new MemberExchangeService();
        }

        // GET api/memberexchanges
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public HttpResponseMessage Get(int CurrentPage, int PageSize, string stdt, string eddt)
        {
            try
            {
                int TotalRow = 0;
                var datas = service.Get(CurrentPage, PageSize, out TotalRow, stdt, eddt);

                var Rvl = new { Total = TotalRow, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }

        }

        public HttpResponseMessage Get(int CurrentPage, int PageSize,string stdt,string eddt,string MemberID)
        {
            try
            {
                int TotalRow = 0;
                var datas = service.Get(CurrentPage, PageSize, out TotalRow,stdt,eddt,MemberID);
                                    
                var Rvl = new { Total = TotalRow, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }

        }

        // POST api/memberexchanges
        public void Post([FromBody]string value)
        {
        }

        // PUT api/memberexchanges/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/memberexchanges/5
        public void Delete(int id)
        {
        }
    }
}
