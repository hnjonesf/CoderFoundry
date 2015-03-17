using AngularTemplate.InsightUserStore;
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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private ICategoryDataAccess db;
        private ApplicationUserManager um;

        public CategoryController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>
                ().As<ICategoryDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        //// GET: api/Category
        //[Authorize]
        //[HttpGet]
        //[Route("GetCategories")]
        //public async Task<IList<Category>> GetCategories()
        //{
        //    //var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
        //    //var Categories = await db.GetCategoriesForHousehold(user.Household);
        //    //return Ok(Categories);
        //}

        // GET: api/Category/5
        [Authorize]
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<int> CreateCategory(Category category, string name)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());

            var newCategory = new Category()
            {
                HouseHold = user.HouseHold,
                Name = name
            };

            return await db.InsertCategoryAsync(newCategory);

        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
