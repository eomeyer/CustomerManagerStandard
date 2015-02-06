using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace CustomerManagerStandard.Controllers
{
    public class DataServiceController : ApiController
    {
        Repository.CustomerRepository _repository;

        public DataServiceController()
        {
            _repository = new Repository.CustomerRepository();
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage Customers()
        {
            var customers = _repository.GetCustomers();
            var totalRecords = customers.Count();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

    }
}