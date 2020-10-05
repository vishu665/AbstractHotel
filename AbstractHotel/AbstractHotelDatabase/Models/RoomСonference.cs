using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractHotelDatabase.Models
{
    public class RoomСonference
    {
        public int Id { get; set; }

        public int СonferenceId { get; set; }

        public int RoomId { get; set; }

        public int Count { get; set; }

        public string RoomsType { get; set; }

        public virtual Сonference Сonference { get; set; }

        public virtual Room Room { get; set; }
    }
}
