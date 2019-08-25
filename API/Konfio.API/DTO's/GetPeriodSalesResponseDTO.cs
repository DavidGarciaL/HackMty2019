using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class GetPeriodSalesResponseDTO
    {
        public int NumCustomers { get; set; }
        public double BiggestSale { get; set; }
        public string BiggestSaleName { get; set; }
        public double BiggestCustomer { get; set; }
        public string BiggestCustomerName { get; set; }

        public IList<BiggestInvoice> biggestInvoices { get; set; }
    }

    public class BiggestInvoice
    {
        public DateTime Date { get; set; }
        public string Rfc { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
    }
}
