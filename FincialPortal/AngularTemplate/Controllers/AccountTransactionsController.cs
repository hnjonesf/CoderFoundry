using AngularTemplate.InsightUserStore.DataAccess;
using AngularTemplate.Models.DataModels;
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

        // GET: api/Transactions for PagedList

        [HttpGet]
        [Route("GetTransactionsPagedList")]
        public PagedList GetTransactions(string searchtext, int page = 1, int pageSize = 10, string sortBy = "Date", string sortDirection = "asc")
        {
            var pagedRecord = new PagedList();
            //Hugh help with account Id below...plugged with 1 to build.04-08-2015
            //pagedRecord.Content = db.GetAccountTransactionsForAccount(1)
            //            //.Where(x => searchtext == null ||
            //            //        ((x.Amount.Contains(searchtext)) ||
            //            //        (x.Description.Contains(searchtext))
            //            //    ))
            //            .OrderBy(sortBy + " " + sortDirection)
            //            .Skip((page - 1) * pageSize)
            //            .Take(pageSize)
            //            .ToList();

            // Count
            //pagedRecord.TotalRecords = db.GetAccountTransactionsForAccount(1)
            //            .Where(x => searchtext == null ||
            //                    ((x.Amount.Contains(searchtext)) ||
            //                    (x.Description.Contains(searchtext))
            //                )).Count();

            //pagedRecord.CurrentPage = page;
            //pagedRecord.PageSize = pageSize;

            return pagedRecord;
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
            accounttransaction.UpdatedByUserId = User.Identity.GetUserId<int>();
            accounttransaction.Updated = System.DateTimeOffset.Now;
            await db.InsertAccountTransactionAsync(accounttransaction);
        }

        // PUT: api/Transactions/Edit
        [HttpPut]
        [Route("EditTransaction")]
        public async Task EditAccountAccount(AccountTransaction accounttransaction)
        {
            accounttransaction.UpdatedByUserId = User.Identity.GetUserId<int>();
            accounttransaction.Updated = System.DateTimeOffset.Now;
            await db.UpdateAccountTransactionAsync(accounttransaction);
        }


        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task DeleteAccountTransaction([FromUri] int Id)
        {
            await db.DeleteAccountTransactionAsync(Id);
        }


        //why does return error out?  Hugh
        // GET: api/GetAcctTransCount
        [HttpGet]
        [Route("GetAcctTransCount")]
        public async Task GetAcctTransCount(int accountId)
        {
            int transCount = 0;
            await db.GetAcctTransCount(transCount);
        }


    }
}
