using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    [DataContract]
    public class ConferenceBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }

        public List<ConferenceRoomBindingModel> ConferenceRooms { get; set; }
    }
}
