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
using AngularTemplate.InsightUserStore.DataAccess;


namespace AngularTemplate.Controllers
{
    [RoutePrefix("api/budgets")]
    public class BudgetsController : ApiController
    {

        private IBudgetDataAccess db;
        private ApplicationUserManager um;


        public BudgetsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IBudgetDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        // GET: api/Budgets
        [Authorize]
        [HttpGet]
        [Route("GetBudgets")]
        public async Task<IHttpActionResult> GetBudgets()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var Budget = await db.GetBudgetForHouseHold(user.Household);
            if (Budget == null)
            {
                Budget = new Budget()
                {
                    HouseHold = user.Household,
                    Apparel = 0,
                    Food = 0,
                    HealthCare = 0,
                    Housing = 0,
                    Income = 0,
                    Investments = 0,
                    Other = 0,
                    Transportation = 0,
                    Utilities = 0,
                };
                Budget.Id = await db.InsertBudgetAsync(Budget);
            }

            return Ok(Budget);
        }


        [Authorize]
        [HttpPut]
        [Route("EditBudget")]
        public async Task EditBudget(Budget budget)
        {

            await db.UpdateBudgetAsync(budget);
        }

    }
}

