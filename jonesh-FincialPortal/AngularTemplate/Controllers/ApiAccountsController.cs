﻿using Microsoft.AspNet.Identity.Owin;
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
using Insight.Database;
using AngularTemplate.InsightUserStore.DataAccess;
using AngularTemplate.Models.Interfaces;
using FinalTemplate.Models.DataModels;

namespace AngularTemplate.Controllers
{
    [RoutePrefix("api/accounts")]
    public class ApiAccountsController : ApiController
    {
        private IAccountDataAccess db;
        private ApplicationUserManager um;

        public ApiAccountsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>
                ().As<IAccountDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        // GET: api/Accounts
        [Authorize]
        [HttpGet]
        [Route("GetAccounts")]
        public async Task<IHttpActionResult> GetAccounts()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var Accounts = await db.GetAccountsForHouseHold(user.Household);
            return Ok(Accounts);
        }

        // POST: api/Accounts
        [Authorize]
        [HttpPost]
        [Route("CreateAccount")]
        public async Task<int> CreateAccount(Account account)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());

            var newAccount = new Account()
            {
                HouseHold = user.Household,
                Name = account.Name,
                Balance = 0,
                ReconciledBalance = 0
            };

            return await db.InsertAccountAsync(newAccount);
        }


        [Authorize]
        [HttpPut]
        [Route("EditAccount")]
        public async Task EditAccount(Account account)
        {

            await db.UpdateAccountAsync(account);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task DeleteAccount([FromUri] int Id)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            await db.DeleteAccountAsync(Id);
            await db.SumTransactionsByAccount(Id, user.Household);
        }

    }
}
