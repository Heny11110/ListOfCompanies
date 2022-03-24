using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListOfCompanies.Models
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string YearsInBusiness { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string source { get; set; }
    }
}