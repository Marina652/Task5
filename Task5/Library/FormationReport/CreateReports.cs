using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.FormationReport
{
    public class CreateReports
    {
        public delegate void DelegateForCreating();
        public event DelegateForCreating CreatingEvent;

        public CreateReports()
        {
            CreatingEvent += CreateTxtReport;
            CreatingEvent += CreatePdfReport;
            CreatingEvent += CreateXlsxReport;
        }

        public void CreateTxtReport()
        {
            ProcessingDataInCollections processing = new();
            CreateTxtFile.Report("../../../ReportTxt.txt", processing.CountOfBooks());
        }

        private void CreatePdfReport()
        {
            ProcessingDataInCollections processing = new();
            CreatePdfFile.Report("../../../ReportPdf.pdf", processing.CountOfBooks());
        }

        private void CreateXlsxReport()
        {
            ProcessingDataInCollections processing = new();
            CreateXlsxFile.Report("../../../ReportXlsx.xlsx", processing.CountOfBooks());
        }


    }
}
