using System;
using System.Collections.Generic;

namespace Konfio.API.Models
{
    public partial class Transactions : IEntity
    {
        public Guid Id { get; set; }
        public string Rfc { get; set; }
        public string Uuid { get; set; }
        public string Ccyisocode { get; set; }
        public string Ccyfx { get; set; }
        public string Paymentmethod { get; set; }
        public string Paymenttype { get; set; }
        public double? Subtotal { get; set; }
        public double? Total { get; set; }
        public double? Placegenerated { get; set; }
        public string Date { get; set; }
        public string Receptorrfc { get; set; }
        public string Receptorname { get; set; }
        public string Emisorrfc { get; set; }
        public string Emisorname { get; set; }
        public string Status { get; set; }
        public string Productid { get; set; }
        public double? Quantity { get; set; }
        public double? Cost { get; set; }
    }
}
