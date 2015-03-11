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
    [RoutePrefix("api/transactions")]
    public class TransactionsController : ApiController
    {
        private ITransactionDataAccess db;
        private ApplicationUserManager um;

        public TransactionsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<ITransactionDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        // GET: api/Transactions
        [Authorize]
        [HttpGet]
        [Route("GetTransactions")]
        public async Task<IHttpActionResult> GetTransactions([FromUri] int accountId)
        {

            var Transactions = await db.GetTransactionsForAccount(accountId);
            return Ok(Transactions);
        }

        // POST: api/Transactions
        [Authorize]
        [HttpPost]
        [Route("CreateTransaction")]
        public async Task<int> CreateTransaction(Transaction transaction)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());

            var newTransaction = new Transaction()
            {
                AccountId = transaction.AccountId,
                Description = transaction.Description,
                Household = user.HouseHold,
                Amount = transaction.Amount,
                Reconciled = transaction.Reconciled,
                Date = transaction.Date,
                Updated = System.DateTime.Now,
                UpdatedByUserId = user.Id,
                Category = transaction.Category

            };
            var newTransactionId = await db.InsertTransactionAsync(newTransaction);
            await db.SumTransactionsByAccount(transaction.AccountId, user.HouseHold);
            return newTransactionId;
            
        }


        [Authorize]
        [HttpPut]
        [Route("EditTransaction")]
        public async Task EditTransaction(Transaction transaction)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            await db.UpdateTransactionAsync(transaction);
            await db.SumTransactionsByAccount(transaction.AccountId, user.HouseHold);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task DeleteTransaction([FromUri]int Id, [FromUri] int accountId)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            await db.DeleteTransactionAsync(Id);
            await db.SumTransactionsByAccount(accountId, user.HouseHold);
        }
    }
}

