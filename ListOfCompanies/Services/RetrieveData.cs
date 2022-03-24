using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ListOfCompanies.Models;

namespace ListOfCompanies.Services
{
    public class RetrieveData
    {
         
        public static List<Company> GetDataList()
        {
             
            var dataRetrieved = new List<Company>();
            
            var comma = GetResources.Get("comma.txt"); 
            foreach (var data in comma)
            {
                dataRetrieved.Add(FromFile(data, ','));
            }
            var hash = GetResources.Get("hash.txt"); 
            foreach (var data in hash)
            {
                dataRetrieved.Add(FromFile(data, '#'));
            }

            var hyphen = GetResources.Get("hyphen.txt");
                 
            foreach (var data in hyphen)
            {
                dataRetrieved.Add(FromFile(data, '-'));
            }
            return dataRetrieved;

        }

        public static int FormatYearsInBusiness(string yearInBusiness)
        {
            if (yearInBusiness.Length > 3)
            {
                Int32.TryParse(yearInBusiness?.Trim(), out int yearsInBusinessInt);

                return DateTime.Now.Year- yearsInBusinessInt;
            }
            else
            {
                Int32.TryParse(yearInBusiness?.Trim(), out int yearsInBusinessInt);
                return yearsInBusinessInt;
            }
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            StringBuilder formattedNumber = new StringBuilder();
            foreach (char c in phoneNumber)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    formattedNumber.Append(c);
                }
            }
            if(formattedNumber.Length>10)
            { formattedNumber = formattedNumber.Remove(0, 1); }

            return $"{formattedNumber.ToString():(###) ###-####}";
        }

        public static Company FromFile(string csvLine, char delimiter)
        {
            if (delimiter <= 0) throw new ArgumentOutOfRangeException(nameof(delimiter));
            string[] values = csvLine.Split(delimiter);
            var comp = new Company
            {
                CompanyName = values[0]
            };
            switch (delimiter)
            {
                case ',':
                    comp.ContactName = values[1];
                    comp.ContactPhoneNumber = values[2];
                    comp.YearsInBusiness = values[3];
                    comp.ContactEmail = values[4];
                    break;
                case '#':
                    comp.ContactName = values[2];
                    comp.ContactPhoneNumber = values[3];
                    comp.YearsInBusiness = values[1];
                    break;
                case '-':
                    comp.ContactPhoneNumber = values[2];
                    comp.YearsInBusiness = values[1];
                    comp.ContactEmail = values[3];
                    comp.ContactFirstName = values[4];
                    comp.ContactLastName = values[5];
                    break;
            }
            return comp;
        }
    }
}