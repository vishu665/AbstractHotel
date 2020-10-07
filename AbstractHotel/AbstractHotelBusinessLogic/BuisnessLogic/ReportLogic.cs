using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.HelperModels;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelBusinessLogic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IRequestLogic requestLogic;
        private readonly ILunchLogic lunchLogic;

        public ReportLogic(IRequestLogic requestLogic, ILunchLogic lunchLogic)
        {
            this.requestLogic = requestLogic;
            this.lunchLogic = lunchLogic;
        }

        public List<ReportRequestLunchesViewModel> GetRequestLunches()
        {
            var lunches = lunchLogic.Read(null);
            var requests = requestLogic.Read(null);
            var list = new List<ReportRequestLunchesViewModel>();
            foreach (var request in requests)
            {
                var record = new ReportRequestLunchesViewModel
                {
                    RequestName = request.RequestName,
                    Lunches = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var lunch in lunches)
                {
                    if (request.RequestLunch.ContainsKey(lunch.Id))
                    {
                        record.Lunches.Add(new Tuple<string, int>(lunch.TypeLunch,
                       request.RequestLunch[lunch.Id].Item2));
                        record.TotalCount +=
                       request.RequestLunch[lunch.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                RequestLunches = GetRequestLunches()
            });
        }
        public void SaveRequestPlaceToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                RequestLunches = GetRequestLunches()
            });
        }
    }
}
