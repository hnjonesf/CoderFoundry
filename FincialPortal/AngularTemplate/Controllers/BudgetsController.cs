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
    [RoutePrefix("api/budgets")]
    public class ApiBudgetsController : ApiController
    {
        private IBudgetDataAccess db;


        public ApiBudgetsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>
                ().As<IBudgetDataAccess>();
        }

        // GET: api/Budgets
        [HttpGet]
        [Route("GetBudgets")]
        public Task<IList<Budget>> GetBudget(string houseHold)
        {
            return db.GetBudgetsForHouseHold(houseHold);
        }

        [HttpGet]
        [Route("GetBudget")]
        public async Task<Budget> GetBudget(int id)
        {
            return await db.SelectBudgetAsync(id);
        }

        // POST: api/Budgets/Create
        [HttpPost]
        [Route("CreateBudget")]
        public async Task CreateBudget(Budget budget)
        {
            await db.InsertBudgetAsync(budget);
        }

        // PUT: api/Budgets/Edit
        [HttpPut]
        [Route("EditBudget")]
        public async Task EditAccount(Budget budget)
        {
            await db.UpdateBudgetAsync(budget);
        }


        [HttpDelete]
        [Route("DeleteBudget")]
        public async Task DeleteBudgetItems([FromUri] int Id)
        {
            await db.DeleteBudgetAsync(Id);
        }
    }
}
