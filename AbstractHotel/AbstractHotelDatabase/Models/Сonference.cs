using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace AbstractHotelDatabaseImplement.Models
{
   public class Сonference
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("СonferenceId")]
        public virtual List<СonferenceRoom> СonferenceRooms { get; set; }

        public virtual Client Client { get; set; }
    }
}
