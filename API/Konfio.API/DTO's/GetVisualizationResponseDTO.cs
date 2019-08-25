using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.DTO_s
{
    public class GetVisualizationResponseDTO
    {
        public double Sales { get; set; }
        public double Expenses { get; set; }
        public double Earnings { get; set; }
        public List<MonthModel> IncomeList { get; set; }
        public List<MonthModel> OutcomeList { get; set; }

    }

    public class MonthModel
    {
        public string Date { get; set; }
        public double Total { get; set; }
    }
}
