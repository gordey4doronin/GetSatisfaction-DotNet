using System;

namespace GetSatisfaction.OAuth
{
    internal class OAuthToken
    {
        public static readonly OAuthToken Empty = new OAuthToken();

        #region [ Properties ]

        public String Key { get; set; }
        public String Secret { get; set; }
        public OAuthTokenType TokenType { get; set; }

        #endregion // [ Properties ]

        public override String ToString()
        {
            return String.Format("Key = {0}\nSecret = {1}\nType = {2}", Key, Secret, TokenType);
        }
    }
}
