using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.HelperModels
{
    public class PdfInfoClient
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<RoomViewModel> Rooms { get; set; }

        public List<СonferenceViewModel> Conferences { get; set; }
    }
}
