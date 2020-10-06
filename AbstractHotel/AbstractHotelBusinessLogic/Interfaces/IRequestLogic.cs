using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.Interfaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);

        void CreateOrUpdate(RequestBindingModel model);

        void Delete(RequestBindingModel model);
        void AddPlace(RequestLunchBindingModel model);
    }
}
