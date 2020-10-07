using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.Interfaces
{
    public interface IConferenceLogic
    {
        List<СonferenceViewModel> Read(ConferenceBindingModel model);

        void CreateOrUpdate(ConferenceBindingModel model);

        void Delete(ConferenceBindingModel model);
    }
}
