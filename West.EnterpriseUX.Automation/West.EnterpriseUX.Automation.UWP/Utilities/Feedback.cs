using Newtonsoft.Json;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public class Feedback
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("persona")]
        public object Persona { get; set; }

        [JsonProperty("optionalReceipients")]
        public string OptionalReceipients { get; set; }

        [JsonProperty("queueName")]
        public object QueueName { get; set; }

        [JsonProperty("imageURL")]
        public string ImageUrl { get; set; }
        [JsonProperty("applicationName")]
        public string ApplicationName { get; set; }

        [JsonProperty("appEnvironment")]
        public string AppEnvironment { get; set; }

        [JsonProperty("applicationVersion")]
        public string ApplicationVersion { get; set; }

        [JsonProperty("applicationPlatform")]
        public object ApplicationPlatform { get; set; }
        [JsonProperty("DeviceOSVersion")]
        public object DeviceOSVersion { get; set; }
    }
}
