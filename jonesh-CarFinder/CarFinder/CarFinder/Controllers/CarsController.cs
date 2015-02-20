using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarFinder.Controllers
{
    public class CarsController : ApiController
    {
        //Project is to write five procedures here for Year, Make, Model, Trim, and Car:

        // GET: api/Years
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Makes
        public IEnumerable<string> Get(string year)
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Models
        public IEnumerable<string> Get(string year, string make)
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Trim
        public IEnumerable<string> Get(string year, string make, string model)
        {

            return new string[] { "value1", "value2" };
        }

    }
}
