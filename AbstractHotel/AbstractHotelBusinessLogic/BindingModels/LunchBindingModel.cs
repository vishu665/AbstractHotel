using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    public class LunchBindingModel
    {
        public int? Id { get; set; }
        public string TypeLunch { get; set; }
        public int Count { get; set; }
    }
}
