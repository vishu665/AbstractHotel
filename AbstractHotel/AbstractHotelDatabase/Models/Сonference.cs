using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace AbstractHotelDatabase.Models
{
   public class Сonference
    {
        public int Id { get; set; }
        public string СonferenceName { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }
        [Required]
        public bool isReserved { get; set; }
        public virtual List<RoomСonference> RoomsСonferences { get; set; }
        public virtual Client Client { get; set; }
    }
}
