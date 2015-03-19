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
        private ITransactionDataAccess db;


        public ApiTransactionsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>
                ().As<ITransactionDataAccess>();
        }

        // GET: api/Transactions
        [HttpGet]
        [Route("GetTransactions")]
        public Task<IList<Transaction>> GetTransactions(int accountId)
        {
            return db.GetTransactionsForAccount(accountId);
        }

        [HttpGet]
        [Route("GetTransaction")]
        public async Task<Transaction> GetTransaction(int id)
        {
            return await db.SelectTransactionAsync(id);
        }

        // POST: api/Transactions/Create
        [HttpPost]
        [Route("CreateTransaction")]
        public async Task CreateTransaction(Transaction transaction)
        {
            await db.InsertTransactionAsync(transaction);
        }

        // PUT: api/Transactions/Edit
        [HttpPut]
        [Route("EditTransaction")]
        public async Task EditAccount(Transaction transaction)
        {
            await db.UpdateTransactionAsync(transaction);
        }


        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task DeleteTransaction([FromUri] int Id)
        {
            await db.DeleteTransactionAsync(Id);
        }
    }
}
