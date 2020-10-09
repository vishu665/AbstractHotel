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
        private readonly IRoomLogic roomLogic;

        private readonly IConferenceLogic confLogic;

        public ReportLogic(IRequestLogic requestLogic, IRoomLogic roomLogic, IConferenceLogic confLogic, ILunchLogic lunchLogic)
        {
            this.requestLogic = requestLogic;
            this.lunchLogic = lunchLogic;
            this.confLogic = confLogic;
            this.roomLogic = roomLogic;

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
                var conferences = confLogic.Read(null);
                var rooms = roomLogic.Read(null);

                foreach (var conference in conferences)
                {
                    foreach (var confRoom in conference.ConferenceRooms)
                    {
                        foreach (var lunch in rooms.Where(x => x.Id == confRoom.RoomId).First().LunchRoom)

                            reportRD.Add(new ReportRequestsViewModel()
                            {
                                DateCreate = conference.DateCreate,
                                TypeLunch = lunch.Value.Item1,
                                Count = (int)confRoom.Count,
                                Title = "Конференция " + conference.ClientId.ToString()
                            });
                    }
                }
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
