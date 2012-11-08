using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using GetSatisfaction.Models;
using GetSatisfaction.OAuth;
using Newtonsoft.Json;

namespace GetSatisfaction
{
    public class SatisfactionClient
    {
        private const string RequestTokenEndpoint = "https://getsatisfaction.com/api/request_token";
        private const string UserAuthorizationEndpoint = "https://getsatisfaction.com/api/authorize";
        private const string AccessTokenEndpoint = "https://getsatisfaction.com/api/access_token";

        private readonly OAuthConsumer _consumer;
        private readonly OAuthToken _accessToken;

        public SatisfactionClient() { }

        public SatisfactionClient(String consumerKey, String consumerSecret, String accessKey, String accessSecret)
        {
            _consumer = new OAuthConsumer { Key = consumerKey, Secret = consumerSecret };

            _accessToken = new OAuthToken
            {
                Key = accessKey,
                Secret = accessSecret,
                TokenType = OAuthTokenType.AccessToken
            };
        }

        public IList<Topic> GetTopics(String companyName)
        {
            string response;

            using (var client = new WebClient())
            {
                string url;
                if (_consumer == null && _accessToken == null)
                    url = UrlBuilder.GetUrl(companyName);
                else
                    url = UrlBuilder.GetUrl(_consumer, _accessToken, companyName);

                try
                {
                    response = client.DownloadString(url);
                }
                catch (WebException exception)
                {
                    Debug.WriteLine(exception);
                    return null;
                }
            }

            // deserialize
            var model = JsonConvert.DeserializeObject<Response<Topic>>(response);
            return model.Data;
        }

        public void Initialize()
        {
            if (_consumer == null)
                throw new Exception();

            using (var client = new WebClient())
            {
                string requestTokenUrl = UrlBuilder.GenerateOAuthUrl(_consumer, OAuthToken.Empty, new Dictionary<string, string>(), RequestTokenEndpoint);
                string[] requestTokenResponse = client.DownloadString(requestTokenUrl).Split(new[] { '=', '&' });

                var requestToken = new OAuthToken
                {
                    Key = requestTokenResponse[1],
                    Secret = requestTokenResponse[3],
                    TokenType = OAuthTokenType.RequestToken
                };
                Debug.WriteLine(requestToken);

                string authorizeUrl = String.Format("{0}?oauth_token={1}", UserAuthorizationEndpoint, requestToken.Key);
                Debug.WriteLine(authorizeUrl);

                string accessTokenUrl = UrlBuilder.GenerateOAuthUrl(_consumer, requestToken, new Dictionary<string, string>(), AccessTokenEndpoint);
                string[] accessTokenResponse = client.DownloadString(accessTokenUrl).Split(new[] { '=', '&' });

                var accessToken = new OAuthToken
                {
                    Key = accessTokenResponse[1],
                    Secret = accessTokenResponse[3],
                    TokenType = OAuthTokenType.AccessToken
                };
                Debug.WriteLine(accessToken);
            }
        }
    }
}
