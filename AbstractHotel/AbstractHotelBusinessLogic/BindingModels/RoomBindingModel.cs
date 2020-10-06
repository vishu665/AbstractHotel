using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    public class RoomBindingModel
    {
        public int? Id { get; set; }
        public string RoomsType { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> LunchRooms { get; set; }

    }
}
