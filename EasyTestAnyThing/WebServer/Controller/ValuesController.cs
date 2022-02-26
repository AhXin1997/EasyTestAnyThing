using System.Collections.Generic;
using System.Web.Http;

namespace EasyTestAnyThing.WebServer.Controller
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Test()
        {
            return "555";
        }
        [HttpGet]
        public string Test01()
        {
            return "555666";
        }
    }
}