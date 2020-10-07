using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractHotelBusinessLogic.BindingModels
{
    [DataContract]
    public class ConferenceRoomBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
