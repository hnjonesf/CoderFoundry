using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class LoadandDisplayCustomerController : Controller
    {
        // GET: LoadandDisplayCustomer
        public ActionResult Index()
        {
            Customer myCustomer = new Customer();
            myCustomer.ID = 001;
            myCustomer.CustomerCode = "C001";
            myCustomer.Amount = 6546.44;
            return View(myCustomer);
        }
    }
}