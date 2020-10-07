using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }

    }
}
