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
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.RequestName == model.RequestName && rec.Id != model.Id);
                if (model.Id.HasValue)
                {
                    element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Request();
                    context.Requests.Add(element);
                }

                element.RequestName = model.RequestName;
                element.DateCreate = model.DateCreate;

                context.SaveChanges();
            }
        }

        public void Delete(RequestBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RequestLunches.RemoveRange(context.RequestLunches.Where(rec => rec.RequestId == model.Id));
                        Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.Requests.Remove(element);
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

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                return context.Requests
                .Where(rec => model == null || rec.Id == model.Id || rec.DateCreate > model.DateFrom && rec.DateCreate < model.DateTo)
                .ToList()
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    RequestName = rec.RequestName,
                    DateCreate = rec.DateCreate,
                    RequestLunch = context.RequestLunches
                                                .Include(recWC => recWC.Lunch)
                                                .Where(recWC => recWC.RequestId == rec.Id)
                                                .ToDictionary(recWC => recWC.LunchId, recWC => (
                                                    recWC.Lunch?.TypeLunch, recWC.Count
                                                ))
                })
                .ToList();
            }
        }

        public void AddPlace(RequestLunchBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                RequestLunch element =
                    context.RequestLunches.FirstOrDefault(rec => rec.RequestId == model.RequestId && rec.LunchId == model.LunchId);

                if (element != null)
                {
                    element.Count += model.Count;
                }
                else
                {

                    element = new RequestLunch();
                    context.RequestLunches.Add(element);
                    element.RequestId = model.RequestId;
                    element.LunchId = model.LunchId;
                    element.Count = model.Count;
                }
                context.SaveChanges();
            }
        }
    }
}
