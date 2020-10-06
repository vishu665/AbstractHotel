using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class LunchViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип обеда")]
        public string TypeLunch { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public int Count { get; set; }

    }
}
