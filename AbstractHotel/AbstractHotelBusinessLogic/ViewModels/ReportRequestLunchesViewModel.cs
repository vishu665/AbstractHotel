using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class ReportRequestLunchesViewModel
    {
        public string RequestName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Lunches { get; set; }

    }
}
