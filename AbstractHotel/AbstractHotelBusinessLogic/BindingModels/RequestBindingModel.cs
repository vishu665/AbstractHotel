using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public string RequestName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
