using MiniProject_InsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject_InsuranceManagementSystem.Controllers
{
    public class VisitorController : Controller
    {

        InsuranceManagementSystemDbEntities1 entities;

        public VisitorController()
        {
            entities = new InsuranceManagementSystemDbEntities1();

        }


        [HttpGet]
        public ActionResult Index()
        {
            var insurances = entities.Insurances.Where(x => (x.InsuranceType != "Pension Plans")).OrderByDescending(x => x.ReleaseDate).ToList();

            return View(insurances);
        }

        [HttpPost]
        public ActionResult Index(string userChoice)
        {

            var allInsurances = entities.Insurances.Where(x => (x.InsuranceType != "Pension Plans")).ToList();

            string[] keywords = userChoice.ToLower().Split(' ');

            foreach (string keyword in keywords)
            {

                allInsurances = allInsurances.Where(p => (p.SubType.ToLower().Contains(keyword))
                                              || (p.InsuranceType.ToLower().Contains(keyword))
                                              || (p.InsuranceProvider.ToLower().Contains(keyword))).ToList();
            }

            ViewBag.insuranceSearched = userChoice;

            return View(allInsurances);



        }

        public ActionResult VisitorDashboard()
        {
            return View();

        }

    }
}