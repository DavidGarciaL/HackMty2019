using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class AuthenticateRequestDTO
    {
        [Required]
        [JsonProperty("rfc")]
        public string Rfc { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
