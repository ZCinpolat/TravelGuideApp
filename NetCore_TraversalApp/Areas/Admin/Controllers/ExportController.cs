using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrate;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NetCore_TraversalApp.Models.ExportModel;
using OfficeOpenXml;
using System.Composition;
using System.Text.RegularExpressions;

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

        public IActionResult DestinationListExport()
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

    }
}
