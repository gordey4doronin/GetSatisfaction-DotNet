using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetSatisfaction
{
    internal class UrlBuilder
    {
        private const String BaseUrl = "https://api.getsatisfaction.com/";
        private const String CompanyTopicsUrl = "https://api.getsatisfaction.com/companies/{0}/topics.json";

        internal static String GetUrl(String companyName)
        {
            return String.Format(CompanyTopicsUrl, companyName);
        }
    }
}
