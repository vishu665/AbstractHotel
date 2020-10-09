using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.ViewModels;
using AbstractHotelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractHotelDatabaseImplement.Implements
{
    public class СonferenceLogic : IConferenceLogic
    {
        public void CreateOrUpdate(ConferenceBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Сonference element = model.Id.HasValue ? null : new Сonference();
                        if (model.Id.HasValue)
                        {
                            element = context.Сonferences.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                            element.ClientId = model.ClientId;
                            element.DateCreate = model.DateCreate;
                            element.Price = model.Price;
                            context.SaveChanges();
                        }
                        else
                        {
                            element.ClientId = model.ClientId;
                            element.DateCreate = model.DateCreate;
                            element.Price = model.Price;
                            context.Сonferences.Add(element);
                            context.SaveChanges();
                            var groupCars = model.ConferenceRooms
                               .GroupBy(rec => rec.RoomId)
                               .Select(rec => new
                               {
                                   RoomId = rec.Key,
                                   Count = rec.Sum(r => r.Count)
                               });

                            foreach (var groupCar in groupCars)
                            {
                                context.СonferenceRooms.Add(new СonferenceRoom
                                {
                                    ConferenceId = element.Id,
                                    RoomId = groupCar.RoomId,
                                    Count = groupCar.Count
                                });
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(ConferenceBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                Сonference element = context.Сonferences.FirstOrDefault(rec => rec.Id == model.Id.Value);

                if (element != null)
                {
                    context.Сonferences.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<СonferenceViewModel> Read(ConferenceBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                List<СonferenceViewModel> result = new List<СonferenceViewModel>();

                if (model != null)
                {
                    if ((model.DateTo != null) && (model.DateFrom != null))
                    {
                        result.AddRange(context.Сonferences
                        .Where(rec => (rec.Id == model.Id || rec.ClientId == model.ClientId) && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                        .Select(rec => CreateViewModel(rec)));
                    }
                    else
                    {
                        result.AddRange(context.Сonferences
                        .Where(rec => rec.Id == model.Id || rec.ClientId == model.ClientId)
                        .Select(rec => CreateViewModel(rec)));
                    }
                }
                else
                {
                    result.AddRange(context.Сonferences.Select(rec => CreateViewModel(rec)));
                }
                return result;
            }
        }

        static private СonferenceViewModel CreateViewModel(Сonference Conference)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                var cars = context.СonferenceRooms
                    .Where(rec => rec.ConferenceId == Conference.Id)
                    .Include(rec => rec.Room)
                    .Select(rec => new ConferenceRoomViewModel
                    {
                        Id = rec.Id,
                        ConferenceId = rec.ConferenceId,
                        RoomId = rec.RoomId,
                        RoomType = rec.Room.RoomsType,
                        Count = rec.Count,
                        //&
                        Price = rec.Count

                    }).ToList();

                foreach (var car in cars)
                {
                    var carData = context.Rooms.Where(rec => rec.Id == car.RoomId).FirstOrDefault();

                    if (carData != null)
                    {
                        car.RoomType = carData.RoomsType;
                        car.Price = carData.Price;
                    }
                }

                return new СonferenceViewModel
                {
                    Id = Conference.Id,
                    ClientId = Conference.ClientId,
                    ClientFIO = context.Clients.Where(rec => rec.Id == Conference.ClientId).Select(rec => rec.ClientFIO).FirstOrDefault(),
                    DateCreate = Conference.DateCreate,
                    Price = Conference.Price,
                    ConferenceRooms = cars
                };
            }
        }
    }
}
