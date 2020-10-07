using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractHotelDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string ClientFIO { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual List<Сonference> Сonferences { get; set; }
    }
}
