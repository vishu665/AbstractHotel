using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BuisnessLogic
{
    public class MainLogic
    {
        private readonly IRequestLogic requestLogic;
        public MainLogic(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }
        public void CreateRequest(RequestLunchBindingModel model)
        {
            requestLogic.AddPlace(model);
        }
    }
}
