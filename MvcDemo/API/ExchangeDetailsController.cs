using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;


namespace MvcDemo.API
{
    public class ExchangeDetailsController : ApiController
    {
        private MemberExchangeService service;
        public ExchangeDetailsController()
        {
            service = new MemberExchangeService();
        }
        // GET api/exchangedetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/exchangedetails/5
        public HttpResponseMessage Get(string MemberID, string Txn_SN)
        {
            try
            {
                var datas = service.GetExchangeDetails(MemberID, Txn_SN);
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }            
        }

        // POST api/exchangedetails
        public void Post([FromBody]string value)
        {
        }

        // PUT api/exchangedetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/exchangedetails/5
        public void Delete(int id)
        {
        }
    }
}
