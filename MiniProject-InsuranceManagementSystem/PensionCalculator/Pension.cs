using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProject_InsuranceManagementSystem.PensionCalculator
{
    public static class Pension
    {
        public static long CalculatePension(long monthlyIncome,DateTime pensionStartsFrom)
        {
            long PensionAmount=0;

            var TotalServiceRemainingInYears= pensionStartsFrom.Year - DateTime.Now.Year;

            PensionAmount = (monthlyIncome * TotalServiceRemainingInYears)/70;
            
            return PensionAmount;
        }
    }
}