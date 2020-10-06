using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип комнаты")]
        public string RoomsType { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> LunchRoom { get; set; }

    }
}
