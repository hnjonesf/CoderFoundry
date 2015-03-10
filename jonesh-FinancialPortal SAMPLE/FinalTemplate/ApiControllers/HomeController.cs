using CoderFoundry.InsightUserStore.DataAccess;
using CoderFoundry.InsightUserStore.DataAccess;
using FinalTemplate.Models.DataModels;
using Insight.Database;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace FinalTemplate.ApiControllers
{
    [RoutePrefix("api/home")]
    public class HomesController : ApiController
    {

        private IHomeDataAccess db;
        private ApplicationUserManager um;

        public HomesController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IHomeDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        // GET: api/Homes
        [Authorize]
        [HttpGet]
        [Route("GetAccounts")]
        public async Task<IHttpActionResult> GetAccounts()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var Accounts = await db.GetAccountsForHouseHold(user.HouseHold);
            return Ok(Accounts);
        }

        [Authorize]
        [HttpGet]
        [Route("GetTransactions")]
        public async Task<IHttpActionResult> GetTransactions()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var Transactions = await db.GetTransactionsForHouseHold(user.HouseHold);
            return Ok(Transactions);
        }




    }
}

