using System;
using System.Collections.Generic;

namespace Konfio.API.Models
{
    public partial class User : IEntity
    {
        public Guid Id { get; set; }
        public string Rfc { get; set; }
        public string Password { get; set; }
    }
}
