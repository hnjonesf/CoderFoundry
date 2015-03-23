using AngularTemplate.InsightUserStore.DataAccess;
using AngularTemplate.Models.Interfaces;
using FinalTemplate.Models.DataModels;
using Insight.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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

namespace AngularTemplate.Controllers
{
    [RoutePrefix("api/transactions")]
    public class ApiTransactionsController : ApiController
    {
        private IAccountTransactionDataAccess db;


        public ApiTransactionsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IAccountTransactionDataAccess>();
        }

        // GET: api/Transactions
        [HttpGet]
        [Route("GetTransactions")]
        public Task<IList<AccountTransaction>> GetTransactions(int accountId)
        {
            return db.GetAccountTransactionsForAccount(accountId);
        }

        [HttpGet]
        [Route("GetTransaction")]
        public async Task<AccountTransaction> GetTransaction(int id)
        {
            return await db.SelectAccountTransactionAsync(id);
        }

        // POST: api/Transactions/Create
        [HttpPost]
        [Route("CreateTransaction")]
        public async Task CreateAccountTransaction(AccountTransaction accounttransaction)
        {
            await db.InsertAccountTransactionAsync(accounttransaction);
        }

        // PUT: api/Transactions/Edit
        [HttpPut]
        [Route("EditTransaction")]
        public async Task EditAccountAccount(AccountTransaction accounttransaction)
        {
            await db.UpdateAccountTransactionAsync(accounttransaction);
        }


        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task DeleteAccountTransaction([FromUri] int Id)
        {
            await db.DeleteAccountTransactionAsync(Id);
        }
    }
}
