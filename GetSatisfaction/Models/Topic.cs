using System;
using Newtonsoft.Json;

namespace GetSatisfaction.Models
{
    public class Topic
    {
        private String _userDefinedCode;

        /// <summary>
        /// URL for the topic page
        /// </summary>
        [JsonProperty("at_sfn")]
        public String AtSfn { get; set; }

        /// <summary>
        /// The number of people following the topic
        /// </summary>
        [JsonProperty("follower_count")]
        public Int32 FollowerCount { get; set; }

        /// <summary>
        /// The date and time topic was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time of last topic activity
        /// </summary>
        [JsonProperty("last_active_at")]
        public DateTime LastActiveAt { get; set; }

        /// <summary>
        /// The topic status
        /// </summary>
        [JsonProperty("status")]
        public TopicStatus? Status { get; set; }

        /// <summary>
        /// The user defined code if there is one. If there isn't one, it returns "false"
        /// </summary>
        [JsonProperty("user_defined_code")]
        public String UserDefinedCode
        {
            get { return _userDefinedCode; }
            set
            {
                _userDefinedCode = Convert.ToBoolean(value) == false ? null : value;
            }
        }

        /// <summary>
        /// The most recent action taken on the topic. Values are "create", "comment", and "follow".
        /// </summary>
        [JsonProperty("most_recent_activity")]
        public TopicAction MostRecentActivity { get; set; }

        /// <summary>
        /// Whether the topic was created by an employee or not. Returns "true" or "false".
        /// </summary>
        [JsonProperty("employee")]
        public Boolean Employee { get; set; }

        /// <summary>
        /// Whether the topic was created by a champion or not. Returns "true" or "false".
        /// </summary>
        [JsonProperty("champion")]
        public Boolean Champion { get; set; }

        /// <summary>
        /// The subject line for the topic
        /// </summary>
        [JsonProperty("subject")]
        public String Subject { get; set; }

        /// <summary>
        /// The id for the company in Get Satisfaction
        /// </summary>
        [JsonProperty("company_id")]
        public Int32 CompanyId { get; set; }

        /// <summary>
        /// Whether the topic has any replies promoted, either through stars or as a company answer. Returns "true" or "false"
        /// </summary>
        [JsonProperty("has_promoted_replies")]
        public Boolean HasPromotedReplies { get; set; }

        /// <summary>
        /// The body of the topic
        /// </summary>
        [JsonProperty("content")]
        public String Content { get; set; }

        /// <summary>
        /// The type of topic: possible values are "question", "problem", "praise", "idea", and "update".
        /// </summary>
        [JsonProperty("style")]
        public TopicStyle Style { get; set; }

        /// <summary>
        /// The API endpoint that returns the topic object
        /// </summary>
        [JsonProperty("url")]
        public String Url { get; set; }

        /// <summary>
        /// The URL slug for the particular topic
        /// </summary>
        [JsonProperty("slug")]
        public String Slug { get; set; }

        /// <summary>
        /// Whether the topic is being followed by the user who is authenticating the API call. Returns "true" or "false"
        /// </summary>
        [JsonProperty("following")]
        public Boolean Following { get; set; }

        [Obsolete]
        [JsonProperty("me_too")]
        public Boolean MeToo { get; set; }

        /// <summary>
        /// The count of people who have clicked the +1 button (including the original poster)
        /// </summary>
        [JsonProperty("me_too_count")]
        public Int32 MeTooCount { get; set; }

        /// <summary>
        /// The topic ID
        /// </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// The number of replies and comments for this topic
        /// </summary>
        [JsonProperty("reply_count")]
        public Int32 ReplyCount { get; set; }

        /// <summary>
        /// The number of replies (but not comments) that are associated with the topic and have not been archived or deleted.
        /// </summary>
        [JsonProperty("active_replies")]
        public Int32 ActiveReplies { get; set; }

        /// <summary>
        /// Boolean to show if the topic has been closed. True if closed, False if not closed.
        /// </summary>
        [JsonProperty("is_closed")]
        public Boolean IsClosed { get; set; }

        /// <summary>
        /// A timestamp of when the topic was closed. This property only exists if "is_closed" is True.
        /// </summary>
        [JsonProperty("closed_at")]
        public DateTime? ClosedAt { get; set; }
    }
}
