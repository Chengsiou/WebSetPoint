using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace SetPoint.Controllers
{
    public class TestController : ApiController
    {
        // GET api/<controller>
        public async Task<Dictionary<string, string>> Get()
        {
            var uid = "hh4854@gmail.com";
            var result = await DAO.AccountDAO.GetAccountPoint(uid);
            return result;
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}