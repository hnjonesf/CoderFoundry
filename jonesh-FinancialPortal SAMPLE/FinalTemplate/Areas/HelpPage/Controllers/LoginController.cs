using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTemplate.Areas.HelpPage.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /HelpPage/Login/
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult UserCheck()//string _userName, string _password
        {

            User User = new User();
            var model = "";// (from a in User.Email where User.UserName == _userName && User.PasswordHash == _password select a).ToList();
            //   ent.GetLoginsForUser();

            // country1.CountryName = model.FirstOrDefault().CountryName;
            // country1.CountryCode = model.FirstOrDefault().CountryCode;

            return Json(model, JsonRequestBehavior.AllowGet);
        }
	}
}