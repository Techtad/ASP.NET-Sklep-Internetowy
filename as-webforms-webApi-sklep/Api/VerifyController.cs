using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace f3b_store.Api
{
    public class VerificationController : ApiController
    {
        // GET: api/Verification
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Verification/5
        public string Get(int id)
        {
            string url = "https://translate.google.pl/#en|pl|";
            Redirect(url);
            return "https://translate.google.pl/#en|pl|";
        }

        // POST: api/Verification
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Verification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Verification/5
        public void Delete(int id)
        {
        }
    }
}
