using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractHotelDatabase.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string RoomsType { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<RoomСonference> RoomСonference { get; set; }
        public virtual List<LunchRoom> LunchRoom { get; set; }

    }
}
