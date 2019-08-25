using Konfio.API.DTO_s;
using Konfio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Konfio.API.Services
{
    public interface ITransactionService : IService<Transactions>
    {
        GetIvaResponseDTO GetIva(string userRfc, DateTime limit);

        GetPeriodSalesResponseDTO GetPeriodSales(string userRfc, DateTime limit);

        GetPeriodSalesResponseDTO GetExpenses(string userRfc, DateTime limit);

        GetVisualizationResponseDTO GetVisualization(string userRfc, DateTime limit);

        IEnumerable<BestClientResponseDTO> GetBestClients(string userRfc, int top);

        IEnumerable<GetClientDetailResponseDTO> GetClientDetail(string userRfc, string clientRfc);
    }
}
