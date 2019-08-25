using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class AuthenticateResponseDTO
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        //[JsonProperty("refresh_token")]
        //public Guid RefreshToken { get; set; }

        //[JsonProperty("audience")]
        //public Guid Audience { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        //[JsonProperty(".issued")]
        //public DateTime Issued { get; set; }

        //[JsonProperty(".expires")]
        //public DateTime Expires { get; set; }
    }
}
