using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject_InsuranceManagementSystem.Controllers
{
    public class SuccessFailureController : Controller
    {
        // GET: SuccessFailure
        
        public ActionResult Failure()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}