using OfficeOpenXml;
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
            var range = ws.Cells["A1"].LoadFromCollection(list, true);
            range.AutoFitColumns();

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
