using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class GetClientDetailResponseDTO
    {
        public string Date { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
    }
}
