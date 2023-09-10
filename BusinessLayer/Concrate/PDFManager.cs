using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.Ink;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrate;
using BusinessLayer.ExportModel;

namespace BusinessLayer.Concrate
{
    public class PDFManager : IPdfService
    {
        public string GetDestinationPDFReport(List<DestinationExportModel> destinationList)  
        {
            int rowNumber = 1;
            string path = Path.Combine((Directory.GetCurrentDirectory()), "wwwroot/reports/pdf/test1.pdf");
            var stream = new FileStream(path, FileMode.Create);
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

            return "/reports/pdf/test1.pdf";

        }

    }
}
