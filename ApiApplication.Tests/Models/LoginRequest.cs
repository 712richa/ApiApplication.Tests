using Newtonsoft.Json;

namespace ApiApplication.Tests.Models
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
