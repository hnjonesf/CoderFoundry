using FinalTemplate.Models.DataModels;
using FinalTemplate.Models;
using Insight.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace AngularTemplate.Controllers
{
    [Authorize]
    [RoutePrefix("api/authentication")]
    public class AuthorizationController : ApiController
    {
        private ApplicationUserManager _userManager;
        private IUserDataAccess _userData;

        public AuthorizationController()
        {
            _userData = _userData ?? HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IUserDataAccess>();
        }

        public AuthorizationController(ApplicationUserManager userManager)
            : this()
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> Register(UserRegistration newUser)
        {
            var user = new AppUser()
            {
                UserName = newUser.UserName,
                Name = newUser.Name,
                PhoneNumber = newUser.PhoneNumber,
                Email = newUser.Email,
                HouseHold = Guid.NewGuid().ToString(),
                IsLockedOut = false,
                IsDeleted = false
            };

            var result = await UserManager.CreateAsync(user, newUser.Password);

            //var u = await _userData.SelectUserAsync(2);
            //user.PasswordHash = "uhh";

            return result.Succeeded;
        }

        [Route("EditUser")]
        [HttpPut]
        public async Task<bool> ChangeEmail(UserRegistration User)
        {
            var user = await UserManager.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            user.Email = User.Email;
            user.UserName = User.UserName;
            var result = await UserManager.UpdateAsync(user);
            UserManager.ChangePassword(user.Id, User.Password, User.Password);
            return result.Succeeded;
        }

        [Route("GetUser")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUser()
        {
            var user = await UserManager.FindByIdAsync(HttpContext.Current.User.Identity.GetUserId<int>());
            var retUser = new UserRegistration();
            retUser.Email = user.Email;
            retUser.Name = user.Name;
            retUser.UserName = user.UserName;
            return Ok(retUser);
        }
    }
}