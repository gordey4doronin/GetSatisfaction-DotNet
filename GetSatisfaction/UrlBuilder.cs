using System;
using System.Collections.Generic;
using System.Linq;
using GetSatisfaction.OAuth;

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

        internal static String GetUrl(OAuthConsumer consumer, OAuthToken token, String companyName)
        {
            string url = String.Format(CompanyTopicsUrl, companyName);
            return GenerateOAuthUrl(consumer, token, new Dictionary<string, string>(), url);
        }

        internal static String GenerateOAuthUrl(OAuthConsumer consumer, OAuthToken token, Dictionary<String, String> additionalFields, String baseUrl)
        {
            var oauth = new OAuthBase();
            string timestamp = oauth.GenerateTimeStamp();
            string nonce = oauth.GenerateNonce();

            string normUrl;
            string normParms;

            string url = String.Format("{0}?{1}", baseUrl, GetQueryString(additionalFields));
            var uri = new Uri(url);

            var signature = oauth.GenerateSignature(uri, consumer.Key, consumer.Secret, token.Key, token.Secret, "GET", timestamp, nonce, out normUrl, out normParms);

            return String.Format("{0}?{1}&oauth_signature={2}", normUrl, normParms, OAuthBase.UrlEncode(signature));
        }

        private static String GetQueryString(Dictionary<String, String> parms)
        {
            return String.Join("&", parms.Select(x => String.Format(@"{0}={1}", OAuthBase.UrlEncode(x.Key), OAuthBase.UrlEncode(x.Value))));
        }
    }
}
