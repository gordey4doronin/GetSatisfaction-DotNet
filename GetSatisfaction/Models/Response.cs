using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetSatisfaction.Models
{
    public class Response<T> where T : class
    {
        [JsonProperty("data")]
        public IList<T> Data { get; set; }
    }
}
