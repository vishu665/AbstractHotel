using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractHotelDatabase.Models
{
    public class LunchRoom
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int LunchId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Room Room { get; set; }

        public virtual Lunch Lunch { get; set; }
    }
}
