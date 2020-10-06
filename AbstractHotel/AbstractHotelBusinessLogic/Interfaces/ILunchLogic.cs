using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace AbstractHotelBusinessLogic.Interfaces
{
    public interface ILunchLogic
    {
        List<LunchViewModel> Read(LunchBindingModel model);

        void CreateOrUpdate(LunchBindingModel model);

        void Delete(LunchBindingModel model);
        void LunchRefill(RequestLunchBindingModel model);

    }
}
