using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace MvcDemo.API
{
    public class TenPartitionAnalysisController : ApiController
    {
        private TenPartitionService service;
        public TenPartitionAnalysisController()
        {
            service = new TenPartitionService();
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var datas = service.GetTenPartitionAnalysis();
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
    }
}
