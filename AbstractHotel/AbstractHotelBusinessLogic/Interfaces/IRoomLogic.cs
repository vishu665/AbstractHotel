using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.Interfaces
{
    public interface IRoomLogic
    {
        List<RoomViewModel> Read(RoomBindingModel model);
        void Delete(RoomBindingModel model);
        void CreateOrUpdate(RoomBindingModel disciplineBindingModel);

    }
}
