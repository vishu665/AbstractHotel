using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class СonferenceViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Сумма")]
        public int Price { get; set; }

        [DataMember]
        [DisplayName("Дата создания конференции")]
        public DateTime DateCreate { get; set; }

        public List<ConferenceRoomViewModel> ConferenceRooms { get; set; }
    }
}
