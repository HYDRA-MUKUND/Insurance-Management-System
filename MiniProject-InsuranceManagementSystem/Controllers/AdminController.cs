using MiniProject_InsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject_InsuranceManagementSystem.Controllers
{
    public class AdminController : Controller
    {

        InsuranceManagementSystemDbEntities1 entities;

        public AdminController()
        {
            entities = new InsuranceManagementSystemDbEntities1();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminProfilePage()
        {
            int RoleId = Convert.ToInt32(Session["RoleIdOfAuthenticatedUser"]);

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"] && RoleId==1)
            {
                ViewBag.FirstName = Session["FirstName"];
                ViewBag.LastName = Session["LastName"];
                ViewBag.Username = Session["Username"];
                return View();
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");


        }

        public ActionResult AutomobileInsurancePendingRequests()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {

                var pendingRequestsForAutomobileInsurance = entities.sp_getAutomobileInsurancePendingRequests();

                return View(pendingRequestsForAutomobileInsurance);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }


        public ActionResult TravelInsurancePendingRequests()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {

                var pendingRequestsForTravelInsurance = entities.sp_getTravelInsurancePendingRequest();

                return View(pendingRequestsForTravelInsurance);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }


        public ActionResult HomeInsurancePendingRequests()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                var pendingRequestsForHomeInsurance = entities.sp_getHomeInsurancePendingRequests();

                return View(pendingRequestsForHomeInsurance);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }


        public ActionResult HealthInsurancePendingRequests()
        {

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {

                var pendingRequestsForHealthInsurance = entities.sp_getHealthInsurancePendingRequest();

                return View(pendingRequestsForHealthInsurance);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }


        public ActionResult PensionPlanPendingRequests()
        {

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {

                var pendingRequestsForPensionPlan = entities.sp_getPensionPlanPendingRequest();

                return View(pendingRequestsForPensionPlan);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }


        public ActionResult VerifyRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyRequest(string PurchasedId, string ApprovalStatus)
        {
            try
            {
                int purchasedId = Convert.ToInt32(PurchasedId);

                var currentRequest = (from p in entities.Purchaseds where p.PurchaseId == purchasedId select p).SingleOrDefault();

                currentRequest.ApprovalStatus = ApprovalStatus;

                entities.SaveChanges();

                return RedirectToAction("ApprovedAlertDialog");

            }
            catch
            {
                return RedirectToAction("Failure", "SuccessFailure");
            }
        }


        public ActionResult ChooseInsuranceType()
        {
            return View();
        }

        public ActionResult ApprovedAlertDialog()
        {
            return View();
        }

        public ActionResult AllVerifiedRequests()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                var listOfVerifiedRequests = entities.sp_getAllVerifiedRequests();

                return View(listOfVerifiedRequests);
            }

            return RedirectToAction("AccessDenied", "SuccessFailure");

        }
    }
}