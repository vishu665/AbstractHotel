using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System.Text;
using AbstractHotelBusinessLogic.HelperModels;

namespace AbstractHotelBusinessLogic.BuisnessLogic
{
    public class SaveToPdf
    {
        public static void CreateDoc(PdfInfo info)
        {
            Document document = new Document();
            DefineStyles(document);

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по { info.DateTo.ToShortDateString()}");
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";

            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "4cm", "4cm", "4cm", "4cm" };

            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }

            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Дата создания", "Название", "Количество", "Тип обеда" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });

            if (info.RequestLunches != null)
            {
                foreach (var rp in info.RequestLunches)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = table,
                        Texts = new List<string>
                    {
                        rp.DateCreate.ToShortDateString(),
                        rp.Title.ToString(),
                        rp.Count.ToString(),
                        rp.TypeLunch.ToString()
                    },

                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
            }           
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        public static void CreateDoc(PdfInfoClient info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            foreach (var order in info.Conferences)
            {
                var orderLabel = section.AddParagraph("Конференция №" + order.Id + "от" + order.DateCreate);
                orderLabel.Style = "NormalTitle";
                var CarLabel = section.AddParagraph("Номера с обедами:");
                CarLabel.Style = "NormalTitle";

                foreach (var cars in order.ConferenceRooms)
                {
                    var CarTable = document.LastSection.AddTable();
                    List<string> headerWidths2 = new List<string> { "1cm", "3cm", "3cm", "3cm" };
                    foreach (var elem in headerWidths2)
                    {
                        CarTable.AddColumn(elem);
                    }
                    CreateRow(new PdfRowParameters
                    {
                        Table = CarTable,
                        Texts = new List<string> { "№", "Тип номера", "Количество", "Цена" },
                        Style = "NormalTitle",
                        ParagraphAlignment = ParagraphAlignment.Center
                    });
                    CreateRow(new PdfRowParameters
                    {
                        Table = CarTable,
                        Texts = new List<string> { cars.RoomId.ToString(), cars.RoomType, cars.Count.ToString(), cars.Price.ToString() },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                    foreach (var car in info.Rooms)
                    {
                        if (car.Id != cars.RoomId)
                        {
                            continue;
                        }

                        var detailTable = document.LastSection.AddTable();
                        List<string> headerWidths3 = new List<string> { "1cm", "3cm", "3cm" };
                        foreach (var elem in headerWidths3)
                        {
                            detailTable.AddColumn(elem);
                        }
                        CreateRow(new PdfRowParameters
                        {
                            Table = detailTable,
                            Texts = new List<string> { "№", "Тип ланча", "Количество" },
                            Style = "NormalTitle",
                            ParagraphAlignment = ParagraphAlignment.Center
                        });

                        foreach (var det in car.LunchRoom)
                        {
                            CreateRow(new PdfRowParameters
                            {
                                Table = detailTable,
                                Texts = new List<string> { det.Key.ToString(), det.Value.Item1, det.Value.Item2.ToString() },
                                Style = "Normal",
                                ParagraphAlignment = ParagraphAlignment.Left
                            });

                        }
                        section.AddParagraph();
                    }
                }
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        /// <summary>
        /// Создание стилей для документа
        /// </summary>
        /// <param name="document"></param>
        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }
        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }
        /// <summary>
        /// Заполнение ячейки
        /// </summary>
        /// <param name="cellParameters"></param>
        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
