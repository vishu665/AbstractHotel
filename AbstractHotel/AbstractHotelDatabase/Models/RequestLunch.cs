using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelDatabase.Models
{
    public class RequestLunch
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int LunchId { get; set; }

        public int Count { get; set; }

        public virtual Request Request { get; set; }

        public virtual Lunch Lunch { get; set; }
    }
}
