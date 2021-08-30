using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.FormationReport
{
    /// <summary>
    /// Class for create xlsx report
    /// </summary>
    public class CreateXlsxFile 
    {
        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="path">File to save the report</param>
        /// <param name="list">List of data to save</param>
        public static void Report(string path, List<string> list)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);
            SaveExelFile(list, file);
        }

        /// <summary>
        /// Save exel file
        /// </summary>
        /// <param name="list">List of data to save</param>
        /// <param name="file">File to save</param>
        private static void SaveExelFile(List<string> list, FileInfo file)
        {
            DeleteExists(file);
            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("Report");   
            for (int i = 1; i <= list.Count; i += 1)
            {
                var mass = list[i-1].Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j <= mass.Length; j++)
                    ws.Cells[i, j].Value = mass[j - 1];
            }
            package.Save();
        }

        /// <summary>
        /// delete exists
        /// </summary>
        /// <param name="file">file</param>
        private static void DeleteExists(FileInfo file)
        {
            if(file.Exists)
                file.Delete();
        }
    }
}
