using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.HelperModels;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<ReportRequestsViewModel> GetLunches(ReportBindingModel model)
        {
            List<ReportRequestsViewModel> reportRD = new List<ReportRequestsViewModel>();
            {
                var requests = requestLogic.Read(new RequestBindingModel
                {
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo
                });

                var lunches = lunchLogic.Read(null);             
                foreach (var request in requests)
                {
                    foreach (var lunch in request.RequestLunch)
                    {
                        reportRD.Add(new ReportRequestsViewModel()
                        {
                            DateCreate = request.DateCreate,
                            TypeLunch = lunch.Value.Item1,
                            Count = lunch.Value.Item2,
                            Title = request.RequestName
                        });
                    }
                }
            }
            return reportRD.OrderBy(x => x.DateCreate).ToList();

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
        public void SaveRequestDisciplineToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo()
            {
                FileName = model.FileName,
                Title = "Список заявок и конференций",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                RequestLunches = GetLunches(model)
            });
        }
    }
}
