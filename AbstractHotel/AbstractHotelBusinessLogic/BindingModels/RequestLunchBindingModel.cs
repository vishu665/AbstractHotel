using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    public class RequestLunchBindingModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int LunchId { get; set; }
        public int Count { get; set; }

    }
}
