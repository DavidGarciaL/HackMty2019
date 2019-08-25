using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class GetIvaResponseDTO
    {
        public double ChargedIva { get; set; }
        public double Charged { get; set; }
        public double PaidIva { get; set; }
        public double Paid { get; set; }
        public double IvaToPaid { get; set; }
    }
}
