using BusinessLayer.Abstract;
using OfficeOpenXml;
using OfficeOpenXml.ExternalReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace BusinessLayer.Concrate
{
    public class ExcelManager : IExcelService
    {
        public byte[] GetExcelList<T>(List<T> t) where T : class
        {

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Page1");
            worksheet.Cells["A1"].LoadFromCollection(t,true,OfficeOpenXml.Table.TableStyles.Light11);
            return excel.GetAsByteArray(); 
        }
    }
}
