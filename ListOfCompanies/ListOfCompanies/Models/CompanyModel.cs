using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListOfCompanies.Models
{
    public class CompanyModel
    {
        public virtual string CompanyName { get; set; }
        public virtual int YearsInBusiness { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactPhoneNumber { get; set; }
        public virtual string ContactEmail { get; set; }
 
    }
}