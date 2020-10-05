using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractHotelDatabaseImplement.Models
{
    public class Lunch
    {
        public int Id { get; set; }
        [Required]
        public string TypeLunch { get; set; }
        [Required]
        public int Count { get; set; }
        [ForeignKey("LunchId")]
        public virtual List<LunchRoom> LunchRoom { get; set; }

        [ForeignKey("LunchId")]
        public virtual List<RequestLunch> RequestLunch { get; set; }

    }
}
