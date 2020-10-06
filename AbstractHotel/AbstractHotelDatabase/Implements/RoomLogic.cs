using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.ViewModels;
using AbstractHotelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AbstractHotelDatabaseImplement.Implements
{
    public class RoomLogic : IRoomLogic

    {
        public void CreateOrUpdate(RoomBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Room element = context.Rooms.FirstOrDefault(rec =>
                       rec.RoomsType == model.RoomsType && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Rooms.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Room();
                            context.Rooms.Add(element);
                        }
                        element.RoomsType = model.RoomsType;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var lunchRoom = context.LunchesRooms.Where(rec
                           => rec.RoomId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.LunchesRooms.RemoveRange(lunchRoom.Where(rec =>
                            !model.LunchRooms.ContainsKey(rec.LunchId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateRoom in lunchRoom)
                            {
                                updateRoom.Count =
                               model.LunchRooms[updateRoom.LunchId].Item2;

                                model.LunchRooms.Remove(updateRoom.LunchId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.LunchRooms)
                        {
                            context.LunchesRooms.Add(new LunchRoom
                            {
                                RoomId = element.Id,
                                LunchId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
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

        public void Delete(RoomBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LunchesRooms.RemoveRange(context.LunchesRooms.Where(rec =>
                        rec.RoomId == model.Id));
                        Room element = context.Rooms.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Rooms.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
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

        public List<RoomViewModel> Read(RoomBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                return context.Rooms
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new RoomViewModel
               {
                   Id = rec.Id,
                   RoomsType = rec.RoomsType,

                   Price = rec.Price,
                   LunchRoom = context.LunchesRooms
                .Include(recPC => recPC.Lunch)
               .Where(recPC => recPC.RoomId == rec.Id)
               .ToDictionary(recPC => recPC.RoomId, recPC =>
                (recPC.Room?.RoomsType, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
