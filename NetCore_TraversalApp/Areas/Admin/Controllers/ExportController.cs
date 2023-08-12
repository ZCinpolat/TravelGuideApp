using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrate;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NetCore_TraversalApp.Models.ExportModel;
using OfficeOpenXml;
using System.Composition;
using System.Text.RegularExpressions;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;
using PageSize = iTextSharp.text.PageSize;
using Paragraph = iTextSharp.text.Paragraph;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    public class ExportController : Controller
    {
        //private readonly IDestinationService _destinationService;
        //public ExportController(IDestinationService destinationService)
        //{
        //   _destinationService = destinationService;   
        //}
        public IActionResult Index()
        {
            return View();
        }


        public List<DestinationExportModel> GetDestinationExportDatas()
        {
            var result = new List<DestinationExportModel>();
            using (var c = new Context())
            {
                result = c.Destinations.Select(x => new DestinationExportModel
                {
                    Capacity = x.Capacity,
                    City = x.City,
                    DayNight = x.DayNight,
                    Description = x.Description,
                    Price = x.Price,
                }).ToList();
            }
            return result;
        }

        public IActionResult DestinationListExportWithExcel()
        {

            var destinationList = GetDestinationExportDatas();
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.AddWorksheet("Destination");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "DayNight";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Description";
                workSheet.Cell(1, 5).Value = "Capacity";
                var rowNumber = 2;
                foreach (var item in destinationList)
                {
                    workSheet.Cell(rowNumber, 1).Value = item.City;
                    workSheet.Cell(rowNumber, 2).Value = item.DayNight;
                    workSheet.Cell(rowNumber, 3).Value = item.Price;
                    workSheet.Cell(rowNumber, 4).Value = item.Description;
                    workSheet.Cell(rowNumber, 5).Value = item.Capacity;
                    rowNumber++;
                }

                using (var ms = new MemoryStream())
                {

                    workbook.SaveAs(ms);
                    var content = ms.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Destinations.xlsx");
                }

            }

        }

        public IActionResult DestinationListExportWithPDF()
        {
            int rowNumber = 1;
            var destinationList = GetDestinationExportDatas();


            string path = Path.Combine((Directory.GetCurrentDirectory()), "wwwroot/reports/pdf/test1.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

         
            Font titleFont = FontFactory.GetFont("Arial", 32);
            Font regularFont = FontFactory.GetFont("Arial", 36);
            Paragraph title;
            title = new Paragraph("Destination List", titleFont);
            title.Alignment = Element.ALIGN_CENTER;


            PdfPTable table = new PdfPTable(6);
            table.AddCell("##");
            table.AddCell("City");
            table.AddCell("DayNight");
            table.AddCell("Price");
            table.AddCell("Description");
            table.AddCell("Capacity");

            foreach (var item in destinationList)
            {
                table.AddCell(rowNumber.ToString());
                table.AddCell(item.City);
                table.AddCell(item.DayNight);
                table.AddCell(item.Price.ToString());
                table.AddCell(item.Description);
                table.AddCell(item.Capacity.ToString());
                rowNumber++;
            }

            document.Add(title);
            document.Add(table);
            document.Close();
            return File("/reports/pdf/test1.pdf","application/pdf","test1.pdf");

        }

    }
}
