using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class tstController : ApiController
    {
        private Iaaa _srv;
        public Ibbb s2 { get; set;}

        public tstController(Iaaa srv)
        {
            _srv = srv;
        }
        public string get(string id)
        {
            return _srv.hello(id);
        }

        public string get()
        {
            return s2.curtime;
        }
    }
}
