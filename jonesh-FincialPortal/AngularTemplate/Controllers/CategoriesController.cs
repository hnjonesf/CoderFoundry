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
    public class ApiCategoriesController : ApiController
    {
        private ICategoryDataAccess db;
      

        public ApiCategoriesController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>
                ().As<ICategoryDataAccess>();
        }

        // GET: api/Category
        [HttpGet]
        [Route("GetCategories")]
        public Task<IList<Category>> GetCategories(string houseHold)
        {
            return db.GetCategoriesByHouseHold(houseHold);
        }   

        [HttpGet]
        [Route("GetCategory")]
        public async Task<Category> GetCategory(int id)
        {
            return await db.SelectCategoryAsync(id);
        }

        // POST: api/Categories/Create
        [HttpPost]
        [Route("CreateCategory")]
        public async Task CreateCategory(Category category)
        {
            await db.InsertCategoryAsync(category);
        }

        // PUT: api/Categories/Edit
        [HttpPut]
        [Route("EditCategory")]
        public async Task EditAccount(Category category)
        {
            await db.UpdateCategoryAsync(category);
        }


        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task DeleteCategory([FromUri] int Id)
        {
            await db.DeleteCategoryAsync(Id);
        }
    }
}
