using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class LunchRoomViewModel
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int LunchId { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

    }
}
