using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace MvcDemo.API
{
    public class MembersController : ApiController
    {
        private MemberService service;
        public MembersController()
        {
            service = new MemberService();
        }
        // GET api/members
        public HttpResponseMessage Get()
        {
            try
            {
                var datas = service.GetMemberList();
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }

        }

        // GET api/members/5
        public HttpResponseMessage Get(string MemberID)
        {
            try
            {
                var datas = service.GetMemberInfo(MemberID);                
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());

            }

        }    

        // POST api/members
        public void Post([FromBody]string value)
        {
        }

        // PUT api/members/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/members/5
        public void Delete(int id)
        {
        }
    }
}
