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
    [RoutePrefix("api/households")]
    public class HouseholdsController : ApiController
    {

        private IHouseholdDataAccess db;
        private ApplicationUserManager um;


        public HouseholdsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IHouseholdDataAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        // GET: api/Households
        [Authorize]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var users = await db.GetUsersForHousehold(user.HouseHold);
            return Ok(users);
        }

        // POST: api/Households
        [Authorize]
        [HttpPut]
        [Route("CreateHousehold")]
        public async Task<bool> CreateHousehold()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            user.HouseHold = Guid.NewGuid().ToString();
            var result = await um.UpdateAsync(user);
            return result.Succeeded;
        }

        // POST: api/Invitations
        [Authorize]
        [HttpPost]
        [Route("CreateInvitation")]
        public async Task<int> CreateInvitation(Invitation invitation)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());

            var newInvitation = new Invitation()
            {
                FromEmail = user.Email,
                ToEmail = invitation.ToEmail,
                HouseHold = user.HouseHold
            };

            return await db.InsertInvitationAsync(newInvitation);
        }

        [Authorize]
        [HttpGet]
        [Route("GetInvitations")]
        public async Task<IHttpActionResult> GetInvitations()
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var invitations = await db.GetInvitationsForUser(user.Email);
            return Ok(invitations);
        }

        [Authorize]
        [HttpPost]
        [Route("EditHousehold")]
        public async Task EditHousehold(Invitation invitation)
        {
            var user = await um.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());

            if(invitation.Accepted == true)
            {
                user.HouseHold = invitation.HouseHold;
                await um.UpdateAsync(user);
            }

            await db.DeleteInvitationAsync(invitation.Id);
        }

    }
}

