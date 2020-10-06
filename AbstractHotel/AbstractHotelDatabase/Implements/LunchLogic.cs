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
    public class LunchLogic : ILunchLogic
    {
        public void CreateOrUpdate(LunchBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                Lunch element = context.Lunches.FirstOrDefault(rec => rec.TypeLunch == model.TypeLunch && rec.Id != model.Id);

                if (element != null)
                {
                    throw new Exception("Уже есть место с таким типом");
                }

                if (model.Id.HasValue)
                {
                    element = context.Lunches.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Lunch();
                    context.Lunches.Add(element);
                }

                element.TypeLunch = model.TypeLunch;
                element.Count = model.Count;
                element.Price = model.Price;
                context.SaveChanges();
            }
        }

        public void Delete(LunchBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                Lunch element = context.Lunches.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Lunches.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void LunchRefill(RequestLunchBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                RequestLunch element = context.RequestLunches.FirstOrDefault(rec => rec.RequestId == model.RequestId && rec.LunchId == model.LunchId);

                if (element != null)
                {
                    element.Count += model.Count;
                }
                else
                {
                    context.RequestLunches.Add(new RequestLunch
                    {
                        LunchId = model.LunchId,
                        RequestId = model.RequestId,
                        Count = model.Count
                    });
                }
                context.Lunches.FirstOrDefault(res => res.Id == model.LunchId).Count += model.Count;
                context.SaveChanges();
            }
        }

        public List<LunchViewModel> Read(LunchBindingModel model)
        {
            using (var context = new AbstractHotelDatabaseImplement())
            {
                return context.Lunches
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new LunchViewModel
                {
                    Id = rec.Id,
                    TypeLunch = rec.TypeLunch,
                    Count = rec.Count,
                    Price = rec.Price
                })
                .ToList();
            }
        }
    }
}
