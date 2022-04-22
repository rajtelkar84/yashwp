using Newtonsoft.Json;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public class Token
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
        [JsonProperty("ext_expires_in")]
        public int ExtExpiresIn { get; set; }
        [JsonProperty("expires_on")]
        public string ExpiresOn { get; set; }
        [JsonProperty("not_before")]
        public string NotBefore { get; set; }
        [JsonProperty("resource")]
        public string Resource { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        
    }
}