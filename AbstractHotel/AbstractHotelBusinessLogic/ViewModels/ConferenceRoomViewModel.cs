using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class ConferenceRoomViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public int? ConferenceId { get; set; }

        [DataMember]
        public string RoomType { get; set; }

        [DataMember]
        public decimal Price { get; set; }
        public decimal Count { get; set; }
    }
}
