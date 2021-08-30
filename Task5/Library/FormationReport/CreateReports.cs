namespace Library.FormationReport
{
    /// <summary>
    /// Class for create reports
    /// </summary>
    public class CreateReports
    {
        /// <summary>
        /// Delegate for creating reports
        /// </summary>
        public delegate void DelegateForCreating();

        /// <summary>
        /// Event for creating reports
        /// </summary>
        public event DelegateForCreating CreatingEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateReports()
        {
            CreatingEvent += CreateTxtReport;
            CreatingEvent += CreatePdfReport;
            CreatingEvent += CreateXlsxReport;
        }

        /// <summary>
        /// Event trigger method
        /// </summary>
        public void Create()
        {
            CreatingEvent?.Invoke();
        }

        /// <summary>
        /// Create txt report
        /// </summary>
        private void CreateTxtReport()
        {
            ProcessingDataInCollections processing = new();
            CreateTxtFile.Report("../../../ReportTxt.txt", processing.CountOfBooks());
        }

        /// <summary>
        /// Create pdf report
        /// </summary>
        private void CreatePdfReport()
        {
            ProcessingDataInCollections processing = new();
            CreatePdfFile.Report("../../../ReportPdf.pdf", processing.CountOfBooks());
        }

        /// <summary>
        /// Create xlsx report
        /// </summary>
        private void CreateXlsxReport()
        {
            ProcessingDataInCollections processing = new();
            CreateXlsxFile.Report("../../../ReportXlsx.xlsx", processing.CountOfBooks());
        }
    }
}
