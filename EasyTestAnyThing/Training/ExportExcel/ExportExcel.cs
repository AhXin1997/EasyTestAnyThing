using EasyTestAnyThing.Training.Data;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace EasyTestAnyThing.Training.ExportExcel
{
    public class ExportExcel
    {
        private readonly IData _data;

        public ExportExcel(IData data)
        {
            _data = data;
        }

        public void Export(ExportExcelRequest request)
        {
            var directoryInfo = Directory.CreateDirectory("ExcelTest");
            var filePath = $"{directoryInfo.FullName}\\{DateTime.Now:yyyy-MM-dd-hhmm}.xlsx";

            var propertyType = typeof(IData).GetProperties().First().PropertyType;
            var type = propertyType.GenericTypeArguments.First();
            var sheetName = type.Name;
            var colNames = string.Join(";", type.GetProperties().Select(s => s.Name)).Split(';');

            //ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var p = new ExcelPackage())
            {
                //add sheet
                var sheet = p.Workbook.Worksheets.Add(sheetName);

                foreach (var col in colNames.Select((value, i) => new { i, value }))
                {
                    //add colName
                    sheet.Cells[1, col.i + 1].Value = col.value;
                    //add Value   (直,橫)
                    foreach (var item in _data.Videos.Select((value, i) => new { i, value }))
                    {
                        sheet.Cells[item.i + 2, col.i + 1].Value = item.value
                            .GetType()
                            .GetProperties()
                            .Where(s => s.Name == col.value)
                            .Select(s => s.GetValue(item.value).ToString());
                    }
                }

                //寫入檔案
                p.SaveAs(new FileInfo(filePath));
            }
        }
    }
}