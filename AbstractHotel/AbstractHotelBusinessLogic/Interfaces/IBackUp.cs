using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.Interfaces
{
    public interface IBackUp
    {
        void SaveJsonRequest(string folderName);
        void SaveJsonLunchRoom(string folderName);
        void SaveJsonRequestLunch(string folderName);
        void SaveJsonLunch(string folderName);
        void SaveJsonRoom(string folderName);
        void SaveXmlRequest(string folderName);
        void SaveXmlLunchRooms(string folderName);
        void SaveXmlRequestLunch(string folderName);
        void SaveXmlLunch(string folderName);
        void SaveXmlRoom(string folderName);
    }
}
