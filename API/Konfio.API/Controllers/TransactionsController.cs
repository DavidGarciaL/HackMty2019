using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Konfio.API.DTO_s;
using Konfio.API.Models;
using Konfio.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Konfio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller<Transactions, TransactionsDTO>
    {
        public TransactionsController(ITransactionService service, IMapper mapper) : base(service, mapper)
        {
        }

        [Authorize]
        [HttpPost("GetIva")]
        public GetIvaResponseDTO GetIva([FromBody] GetVisualizationRequestDTO request)
        {
            var result = ((ITransactionService)_service).GetIva(SignedRfc, request.Limit);

            return result;
        }

        [Authorize]
        [HttpPost("GetPeriodSales")]
        public GetPeriodSalesResponseDTO GetPeriodSales([FromBody] GetVisualizationRequestDTO request)
        {
            var result = ((ITransactionService)_service).GetPeriodSales(SignedRfc, request.Limit);
            return result;
        }

        [Authorize]
        [HttpPost("GetExpenses")]
        public GetPeriodSalesResponseDTO GetExpenses([FromBody] GetVisualizationRequestDTO request)
        {
            var result = ((ITransactionService)_service).GetExpenses(SignedRfc, request.Limit);
            return result;
        }

        [Authorize]
        [HttpPost("GetVisualization")]
        public GetVisualizationResponseDTO GetVisualization([FromBody]GetVisualizationRequestDTO request)
        {
            var h = SignedUserId;
            var result = ((ITransactionService)_service).GetVisualization(SignedRfc ,request.Limit);
            return result;
        }

        [Authorize]
        [HttpPost("GetBestClients")]
        public IEnumerable<BestClientResponseDTO> GetBestClients([FromBody]BestClientRequestDTO request)
        {
            var result = ((ITransactionService)_service).GetBestClients(SignedRfc, request.Top);
            return result;
        }

        [Authorize]
        [HttpPost("GetClientDetail")]
        public IEnumerable<GetClientDetailResponseDTO> GetClientDetail([FromBody]GetClientDetailRequestDTO request)
        {
            var result = ((ITransactionService)_service).GetClientDetail(SignedRfc, request.EmisorRFC);
            return result;
        }
    }
}
