using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using web.Models;
using System.Threading.Tasks;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.BuisnessLogic;
using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.ViewModels;

namespace web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IConferenceLogic _conLogic;
        private readonly IRoomLogic _roomLogic;
        private readonly ILunchLogic _lunchLogic;
        private readonly ReportLogic _reportLogic;

        public OrderController(IConferenceLogic conferenceLogic, IRoomLogic roomLogic, ILunchLogic lunchLogic, ReportLogic reportLogic)
        { 
            _conLogic = conferenceLogic;
            _roomLogic = roomLogic;
            _lunchLogic = lunchLogic;
            _reportLogic = reportLogic;
        }

        public IActionResult Order()
        {
            ViewBag.Orders = _conLogic.Read(new ConferenceBindingModel
            {
                ClientId = Program.Client.Id
            });
            return View();
        }
        [HttpPost]
        public IActionResult Order(ReportModel model)
        {
            var carList = new List<RoomViewModel>();
            var orders = _conLogic.Read(new ConferenceBindingModel
            {
                ClientId = Program.Client.Id,
                DateFrom = model.From,
                DateTo = model.To
            });
            var cars = _roomLogic.Read(null);
            foreach (var order in orders)
            {
                foreach (var car in cars)
                {
                        carList.Add(car);
                }
            }
            ViewBag.Cars = carList;
            ViewBag.Orders = orders;
            string fileName = "pdfreport.pdf";
            if (model.SendMail)
            {
               // _reportLogic.SaveCarsDetailsToPdfFile(fileName, Program.Client.Id, Program.Client.Mail);
            }
            return View();
        }

        public IActionResult CreateOrder()
        {
            ViewBag.OrderCars = _roomLogic.Read(null);
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateConfModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.OrderCars = _roomLogic.Read(null);
                return View(model);
            }

            if (model.ConferenceRooms == null)
            {
                ViewBag.OrderCars = _roomLogic.Read(null);
                ModelState.AddModelError("", "Выберите комнату");
                return View(model);
            }
            var orderCars = new List<ConferenceRoomBindingModel>();
            foreach (var car in model.ConferenceRooms)
            {
                if (car.Value > 0)
                {
                    var cart = _roomLogic.Read(new RoomBindingModel { Id = car.Key }).FirstOrDefault();
                    foreach(var det in cart.LunchRoom)
                    {
                        var detcount = _lunchLogic.Read(new LunchBindingModel { Id = det.Key }).FirstOrDefault();
                        if((det.Value.Item2 * car.Value) > detcount.Count)
                        {
                            //вывести пользователю
                            ModelState.AddModelError("", "МАЛО ДЕТАЛЕЙ");
                            int raznica = (det.Value.Item2 * car.Value) - detcount.Count;
                        }
                        else
                        {
                            _lunchLogic.CreateOrUpdate(new LunchBindingModel
                            {
                                Id = detcount.Id,
                                TypeLunch = detcount.TypeLunch,
                                Price = detcount.Price,
                                Count = detcount.Count - (det.Value.Item2 * car.Value)
                            });
                        }
                    }
                    orderCars.Add(new ConferenceRoomBindingModel
                    {
                        RoomId = car.Key,
                        Count = car.Value
                    });
                }
            }
                _conLogic.CreateOrUpdate(new ConferenceBindingModel
                {
                    ClientId = Program.Client.Id,
                    DateCreate = DateTime.Now,
                    Price = CalculateSum(orderCars),
                    ConferenceRooms = orderCars
                });
            return RedirectToAction("Order");
        }

        private int CalculateSum(List<ConferenceRoomBindingModel> orderCars)
        {
            int sum = 0;

            foreach (var car in orderCars)
            {
                var carData = _roomLogic.Read(new RoomBindingModel { Id = car.RoomId }).FirstOrDefault();

                if (carData != null)
                {
                    for (int i = 0; i < car.Count; i++)
                        sum += (int)carData.Price;
                }
            }
            return sum;
        }

        public IActionResult SendWordReport(int id)
        {
            var order = _conLogic.Read(new ConferenceBindingModel { Id = id }).FirstOrDefault();
            string fileName = "Список номеров" + order.Id + ".docx";
            //_reportLogic.SaveOrderToWordFile(fileName, order, Program.Client.Mail);
            return RedirectToAction("Order");
        }

        public IActionResult SendExcelReport(int id)
        {
            var order = _conLogic.Read(new ConferenceBindingModel { Id = id }).FirstOrDefault();
            string fileName = "Список номеров" + order.Id + ".xlsx";
           // _reportLogic.SaveOrderToExcelFile(fileName, order, Program.Client.Mail);
            return RedirectToAction("Order");
        }
    }
}
