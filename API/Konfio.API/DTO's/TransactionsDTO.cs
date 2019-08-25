using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class TransactionsDTO
    {
        public Guid Id { get; set; }
        public string Rfc { get; set; }
        public string Uuid { get; set; }
        public string Ccyisocode { get; set; }
        public string Ccyfx { get; set; }
        public double? Paymentmethod { get; set; }
        public string Paymenttype { get; set; }
        public double? Subtotal { get; set; }
        public string Total { get; set; }
        public double? Placegenerated { get; set; }
        public string Date { get; set; }
        public string Receptorrfc { get; set; }
        public string Receptorname { get; set; }
        public string Emisorrfc { get; set; }
        public string Emisorname { get; set; }
        public string Status { get; set; }
        public double? Productid { get; set; }
        public double? Quantity { get; set; }
        public double? Cost { get; set; }
    }
}
