using System;
using System.Collections.Generic;
using System.Net;
using GetSatisfaction.Models;
using Newtonsoft.Json;

namespace GetSatisfaction
{
    public class SatisfactionClient
    {
        public IList<Topic> GetTopics(String companyName)
        {
            string response;

            using (var client = new WebClient())
            {
                string url = UrlBuilder.GetUrl(companyName);
                response = client.DownloadString(url);
            }

            // deserialize
            var model = JsonConvert.DeserializeObject<Response<Topic>>(response);
            return model.Data;
        }
    }
}
