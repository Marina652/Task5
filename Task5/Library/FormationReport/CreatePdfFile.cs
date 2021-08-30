using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

namespace Library.FormationReport
{
    /// <summary>
    /// Class for create pdf file
    /// </summary>
    public class CreatePdfFile
    {
        /// <summary>
        /// Create report
        /// </summary>
        /// <param name="path">File to save the report</param>
        /// <param name="list">List of data to save</param>
        public static void Report(string path, List<string> list)
        {
            var document = new iTextSharp.text.Document();
            using (var writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create)))
            {
                document.Open();
                var timesRoman = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14);
                var timesRomanBase = timesRoman.GetCalculatedBaseFont(false);
                writer.DirectContent.BeginText();
                writer.DirectContent.SetFontAndSize(timesRomanBase, 14f);
                int y = 766;
                foreach (var str in list)
                {
                    writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, str, 35, y, 0);
                    y += 20;
                }
                writer.DirectContent.EndText();

                document.Close();
                writer.Close();
            }
        }
    }
}
