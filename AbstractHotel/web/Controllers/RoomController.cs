using AbstractHotelBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomLogic _room;
        public RoomController(IRoomLogic room)
        {
            _room = room;
        }
        public IActionResult Room()
        {
            ViewBag.Rooms = _room.Read(null);
            return View();
        }
    }
}
