using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.HelperModels
{
    public class ExcelInfoClient
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<RoomViewModel> Rooms { get; set; }
    }
}
