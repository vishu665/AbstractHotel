using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractHotelBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название заявки")]
        public string RequestName { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> RequestLunch { get; set; }
    }
}
