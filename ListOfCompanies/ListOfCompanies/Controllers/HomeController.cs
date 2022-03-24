using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ListOfCompanies.Models;
using ListOfCompanies.Services;
using Microsoft.Ajax.Utilities;
 

namespace ListOfCompanies.Controllers
{
    public class HomeController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string sortOrder)
        {
            var dataRetrieved =  RetrieveData.GetDataList();

            var model = PrepareModel(dataRetrieved);

            SortModel(sortOrder, model);

            return View(model);
        }

        private static void SortModel(string sortOrder, CompaniesModel model)
        {
            switch (sortOrder)
            {
                case "companyName":
                    model.Companies.Sort((p1, p2) => String.Compare(p1.CompanyName, p2.CompanyName, StringComparison.Ordinal));
                    break;
                case "contactName":
                    model.Companies.Sort((p1, p2) => String.Compare(p1.ContactName, p2.ContactName, StringComparison.Ordinal));
                    break;
                case "yearsInBusiness_CompanyName":
                    IComparer<CompanyModel> comparer = new OrderItems();
                    model.Companies.Sort(comparer);
                    break;
            }
        }

        private static CompaniesModel PrepareModel(List<Company> dataRetrieved)
        {
            var model = new CompaniesModel
            {
                Companies = new List<CompanyModel>()
            };
            foreach (var data in dataRetrieved)
            {
                
                 model.Companies.Add(new CompanyModel
                {
                    CompanyName = data.CompanyName?.Trim(),
                    ContactEmail = data.ContactEmail?.Trim(),
                    ContactName = data.ContactName.IsNullOrWhiteSpace()
                        ? data.ContactFirstName?.Trim() + " " + data.ContactLastName?.Trim()
                        : data.ContactName?.Trim(),
                    ContactPhoneNumber = RetrieveData.FormatPhoneNumber(data.ContactPhoneNumber),
                    YearsInBusiness = RetrieveData.FormatYearsInBusiness(data.YearsInBusiness)

                 });
            }

            return model;
        }
    }
}