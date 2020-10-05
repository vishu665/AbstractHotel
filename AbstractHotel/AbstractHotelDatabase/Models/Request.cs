using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractHotelDatabase.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string RequestName { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }

        public virtual List<RequestLunch> RequestLunch { get; set; }
    }
}
