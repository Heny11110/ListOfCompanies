using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListOfCompanies.Models;

namespace ListOfCompanies.Services
{
    public class OrderItems : IComparer<CompanyModel>
    {
        public int Compare(CompanyModel x, CompanyModel y)
        {
            int yearCompare = x.YearsInBusiness.CompareTo(y.YearsInBusiness);
            if (yearCompare == 0)
            {
                return x.CompanyName.CompareTo(y.CompanyName);
            }
            return yearCompare;
        }
    }
    
}