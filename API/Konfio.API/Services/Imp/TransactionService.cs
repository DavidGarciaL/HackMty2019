using Konfio.API.DTO_s;
using Konfio.API.Models;
using Konfio.API.Repositories;
using Konfio.API.Services.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Services.Imp
{
    public class TransactionService : Service<Transactions>, ITransactionService
    {
        public TransactionService(IRepository<Transactions> repository) : base(repository)
        {
        }

        public GetIvaResponseDTO GetIva(string userRfc, DateTime limit)
        {
            var charged = _repository.FindBy(t => t.Rfc == userRfc && t.Receptorrfc == userRfc && DateTime.Parse(t.Date) >= limit)
                .Select(t => t.Subtotal).Sum();

            var chargedIva = charged * .16;
            charged += chargedIva;

            var paid = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc == userRfc && DateTime.Parse(t.Date) >= limit)
                .Select(t => t.Subtotal).Sum();

            var paidIva = paid * .16;
            paid += paidIva;

            var ivaToPaid = chargedIva - paidIva;

            return new GetIvaResponseDTO
            {
                Charged = Convert.ToDouble(charged),
                ChargedIva = Convert.ToDouble(chargedIva),
                Paid = Convert.ToDouble(paid),
                PaidIva = Convert.ToDouble(paidIva),
                IvaToPaid = Convert.ToDouble(ivaToPaid)
            };
        }

        public GetPeriodSalesResponseDTO GetPeriodSales(string userRfc, DateTime limit)
        {
            var numCustomers = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .GroupBy(t => t.Emisorname);

            var bigSale = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .OrderByDescending(t => t.Total)
                .FirstOrDefault();

            var bigCustomer = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .GroupBy(t => new { emisorname = t.Emisorname.ToUpper() })
                .Select(t => new GetPeriodSalesResponseDTO
                {
                    BiggestCustomerName = t.Key.emisorname,
                    BiggestCustomer = t.Sum(s => (double)s.Total)
                })
                .OrderByDescending(t => t.BiggestCustomer)
                .FirstOrDefault();

            var biggestInvoices = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .Select(t => new BiggestInvoice
                {
                    Date = DateTime.Parse(t.Date),
                    Name = t.Emisorname,
                    Rfc = t.Emisorrfc,
                    Total = (double)t.Total
                })
                .OrderByDescending(t => t.Total)
                .Take(5);


            return new GetPeriodSalesResponseDTO
            {
                NumCustomers = numCustomers.Count(),
                BiggestSaleName = bigSale.Emisorname,
                BiggestSale = Convert.ToDouble(bigSale.Total),
                BiggestCustomerName = bigCustomer.BiggestCustomerName, 
                BiggestCustomer = bigCustomer.BiggestCustomer,
                biggestInvoices = biggestInvoices.ToList()
            };
        }

        public GetPeriodSalesResponseDTO GetExpenses(string userRfc, DateTime limit)
        {
            var numProviders = _repository.FindBy(t => t.Rfc == userRfc && t.Receptorrfc.ToUpper() != userRfc && DateTime.Parse(t.Date) >= limit)
                .GroupBy(t => t.Receptorname);

            var bigSale = _repository.FindBy(t => t.Rfc == userRfc && t.Receptorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .OrderByDescending(t => t.Total)
                .FirstOrDefault();

            var bigCustomer = _repository.FindBy(t => t.Rfc == userRfc && t.Emisorrfc == userRfc && DateTime.Parse(t.Date) >= limit)
                .GroupBy(t => new { emisorname = t.Emisorname.ToUpper() })
                .Select(t => new GetPeriodSalesResponseDTO
                {
                    BiggestCustomerName = t.Key.emisorname,
                    BiggestCustomer = t.Sum(s => (double)s.Total)
                })
                .OrderByDescending(t => t.BiggestCustomer)
                .FirstOrDefault();

            var biggestInvoices = _repository.FindBy(t => t.Rfc == userRfc && t.Receptorrfc != userRfc && DateTime.Parse(t.Date) >= limit)
                .Select(t => new BiggestInvoice
                {
                    Date = DateTime.Parse(t.Date),
                    Name = t.Receptorname,
                    Rfc = t.Receptorrfc,
                    Total = (double)t.Total
                })
                .OrderByDescending(t => t.Total)
                .Take(5);


            return new GetPeriodSalesResponseDTO
            {
                NumCustomers = numProviders.Count(),
                BiggestSaleName = bigSale.Emisorname,
                BiggestSale = Convert.ToDouble(bigSale.Total),
                BiggestCustomerName = bigCustomer.BiggestCustomerName, 
                BiggestCustomer = bigCustomer.BiggestCustomer,
                biggestInvoices = biggestInvoices.ToList()
            };
        }

        public GetVisualizationResponseDTO GetVisualization(string userRfc, DateTime limit)
        {
            var transactions = _repository.FindBy(t => DateTime.Parse(t.Date) >= limit && t.Rfc == userRfc);
            double sales = (double)transactions.Where(t => t.Rfc == t.Receptorrfc).Sum(t => t.Total);
            double expenses = (double)transactions.Where(t => t.Rfc == t.Emisorrfc).Sum(t => t.Total);
            double earning = sales - expenses;

            var incomeList = transactions.Where(t => t.Rfc == t.Receptorrfc)
                                         .GroupBy(t => new { dt = String.Format("{0}/{1}", DateTime.Parse(t.Date).Month, DateTime.Parse(t.Date).Year) })
                                         .Select(n => new MonthModel
                                         {
                                             Date = n.Key.dt,
                                             Total = n.Sum(x => (double)x.Total)
                                         }).ToList();

            var outcomeList = transactions.Where(t => t.Rfc == t.Emisorrfc)
                                         .GroupBy(t => new { dt = String.Format("{0}/{1}", DateTime.Parse(t.Date).Month, DateTime.Parse(t.Date).Year) })
                                         .Select(n => new MonthModel
                                         {
                                             Date = n.Key.dt,
                                             Total = n.Sum(x => (double)x.Total)
                                         }).ToList();

            GetVisualizationResponseDTO response = new GetVisualizationResponseDTO
            {
                Sales = sales,
                Expenses = expenses,
                Earnings = earning,
                IncomeList = incomeList,
                OutcomeList = outcomeList
            };

            return response;
        }

        public IEnumerable<BestClientResponseDTO> GetBestClients(string userRfc, int top)
        {
            var result = _repository.FindBy(t => t.Rfc == userRfc && t.Rfc == t.Receptorrfc)
                                    .GroupBy(t => new { rfc = t.Emisorrfc, name = t.Emisorname.ToUpper() })
                                    .Select(n => new BestClientResponseDTO
                                    {
                                        EmisorRFC = n.Key.rfc,
                                        EmisorName = n.Key.name,
                                        Total = n.Sum(x => (double)x.Total)
                                    })
                                    .OrderByDescending(x => x.Total)
                                    .Take(top);

            return result;
        }

        public IEnumerable<GetClientDetailResponseDTO> GetClientDetail(string userRfc, string clientRfc)
        {
            var result = _repository.FindBy(t => t.Emisorrfc == clientRfc && t.Rfc == userRfc)
                                    .Select(t => new GetClientDetailResponseDTO
                                    {
                                        Date = t.Date,
                                        PaymentType = t.Paymenttype,
                                        Status = t.Status,
                                        Total = (double)t.Total
                                    })
                                    .OrderByDescending(t => t.Total)
                                    .Take(10);
                                      
            return result;
        }
    }
}
