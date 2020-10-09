using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace AbstractHotelDatabaseImplement.Implements
{
   public class BackUpLogicc : IBackUp
    {
        public void SaveJsonLunch(string folderName)
        {
            string fileName = $"{folderName}\\Lunch.json";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Lunch>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Lunches);
                }
            }
        }

        public void SaveJsonLunchRoom(string folderName)
        {
            string fileName = $"{folderName}\\LunchRoom.json";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<LunchRoom>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.LunchRooms);
                }
            }
        }

        public void SaveJsonRequest(string folderName)
        {
            string fileName = $"{folderName}\\Request.json";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Request>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Requests);
                }
            }
        }

        public void SaveJsonRequestLunch(string folderName)
        {
            string fileName = $"{folderName}\\RequestLunch.json";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<RequestLunch>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.RequestLunches);
                }
            }
        }

        public void SaveJsonRoom(string folderName)
        {
            string fileName = $"{folderName}\\Room.json";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Room>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Rooms);
                }
            }
        }

        public void SaveXmlLunch(string folderName)
        {
            string fileNameDop = $"{folderName}\\Lunch.xml";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Lunch>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Lunches);
                }
            }
        }

        public void SaveXmlLunchRooms(string folderName)
        {
            string fileNameDop = $"{folderName}\\LunchRoom.xml";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<LunchRoom>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.LunchRooms);
                }
            }
        }

        public void SaveXmlRequest(string folderName)
        {
            string fileNameDop = $"{folderName}\\Request.xml";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Request>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Requests);
                }
            }
        }

        public void SaveXmlRequestLunch(string folderName)
        {
            string fileNameDop = $"{folderName}\\RequestLunch.xml";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<RequestLunch>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.RequestLunches);
                }
            }
        }

        public void SaveXmlRoom(string folderName)
        {
            string fileNameDop = $"{folderName}\\Room.xml";
            using (var context = new AbstractHotelDatabaseImplement())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Room>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Rooms);
                }
            }
        }
    }
}
