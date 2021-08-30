using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Library.FormationReport
{
    public class CreateXlsxFile 
    {
        public static void Report(string path, List<string> list)
        {
            //ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls", ds);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);

            SaveExelFile(list, file);
        }

        private static void SaveExelFile(List<string> list, FileInfo file)
        {
            DeleteExists(file);
            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("Report");
           
            //foreach(var l in list)
            //{
            //    var mass = l.Split(";", StringSplitOptions.RemoveEmptyEntries);
                
            //     var range = ws.Cells["A1"].LoadFromCollection(mass, true);
            //    range.AutoFitColumns();
            //}
            ////var range = ws.Cells["A1"].LoadFromCollection(list, true);
            ////range.AutoFitColumns();
           
            for (int i = 1; i <= list.Count; i += 1)
            {
                var mass = list[i-1].Split(";", StringSplitOptions.RemoveEmptyEntries);
      
                for (int j = 1; j <= mass.Length; j++)
                    ws.Cells[i, j].Value = mass[j - 1];
            }
       
            package.Save();
        }

        private static void DeleteExists(FileInfo file)
        {
            if(file.Exists)
            {
                file.Delete();
            }
        }
    }
}
