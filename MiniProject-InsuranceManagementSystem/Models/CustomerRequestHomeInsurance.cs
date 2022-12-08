using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProject_InsuranceManagementSystem.Models
{
    public class CustomerRequestHomeInsurance
    {
         public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime PurchasedDate { get; set; }  

        public string MobileNumber { get; set; }

        public int PurchasedId { get; set; }

        public string InsuranceType { get; set; }

        public string SubType { get; set; }

        public int FloorArea { get; set; }   

        public string City { get; set; }    

        public string HouseNumber { get; set; } 

        public long HouseValuation { get; set; }

        public int PlanDuration { get; set; }    



    }
}