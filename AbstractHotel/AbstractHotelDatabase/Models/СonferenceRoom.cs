using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelDatabaseImplement.Models
{
    public class СonferenceRoom
    {
        public int Id { get; set; }

        public int ConferenceId { get; set; }

        public int RoomId { get; set; }

        public int Count { get; set; }

        public string RoomsType { get; set; }

        public virtual Сonference Conference { get; set; }

        public virtual Room Room { get; set; }
    }
}
