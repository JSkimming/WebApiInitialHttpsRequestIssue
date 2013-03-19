using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;

namespace WebApiInitialHttpsRequestIssue.Controllers
{
    public class TestController : ApiController
    {
        // GET api/test
        public IEnumerable<string> Get()
        {
            MvcApplication.LogFormat("GET request to '{0}'.", Request.RequestUri);
            return new[] { "value1", "value2" };
        }

        // GET api/test/5
        public string Get(int id)
        {
            MvcApplication.LogFormat("GET request to '{0}'.", Request.RequestUri);
            return "value";
        }

        // POST api/test
        public string Post([FromBody]string value)
        {
            MvcApplication.LogFormat("POST request to '{0}' with value '{1}'.", Request.RequestUri, value);
            return string.Format("Here's what you posted '{0}'.", value ?? "you didn't post anything");
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
            MvcApplication.LogFormat("PUT request to '{0}' with value '{1}'.", Request.RequestUri, value);
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
            MvcApplication.LogFormat("DELETE request to '{0}'.", Request.RequestUri);
        }
    }
}
