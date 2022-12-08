using MiniProject_InsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject_InsuranceManagementSystem.Controllers
{
    public class AgentController : Controller
    {
        
        InsuranceManagementSystemDbEntities1 entities;

        public AgentController()
        {
            entities = new InsuranceManagementSystemDbEntities1();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgentProfilePage()
        {

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                ViewBag.FirstName = Session["FirstName"];
                ViewBag.LastName = Session["LastName"];
                ViewBag.Username = Session["Username"];
                return View();

            }

            return RedirectToAction("AccessDenied", "SuccessFailure");
        }

        public ActionResult AddInsurance()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                Insurance insurance = new Insurance();
                return View(insurance);
            }
            return RedirectToAction("AccessDenied", "SuccessFailure");
             
        }

        [HttpPost]
        public ActionResult AddInsurance(Insurance insurance)
        {
            try
            {
                insurance.InsuranceType = Request.Form["insurances"].ToString();
                insurance.UserId = Convert.ToInt32(Session["CurrentUserId"]);
                insurance.ReleaseDate = DateTime.Now;

                if(insurance.InsuranceType.Equals("Pension Plans"))
                {
                    insurance.Amount = 0;
                    insurance.YearlyPremium = 0;
                }

                entities.Insurances.Add(insurance);
                entities.SaveChanges();

                return RedirectToAction("SuccessfullyAddedPolicyAlert");
            }
            catch
            {
                return RedirectToAction("Failure", "SuccessFailure");
            }
            
            
        }

        public ActionResult SuccessfullyAddedPolicyAlert()
        {
            return View();
        }

        public ActionResult YourPolicies()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {

                int currentAgentID = Convert.ToInt32(Session["CurrentUserId"]);

                var listOfPolicies = (from ins in entities.Insurances where ins.UserId == currentAgentID select ins).ToList();

                return View(listOfPolicies);
            }
            return RedirectToAction("AccessDenied", "SuccessFailure");
        }
    }
}