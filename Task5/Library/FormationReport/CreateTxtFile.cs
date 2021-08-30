using System;
using System.Collections.Generic;
using System.IO;

namespace Library.FormationReport
{
    /// <summary>
    /// Class for create txt report
    /// </summary>
    public class CreateTxtFile
    {
        /// <summary>
        /// Creare report
        /// </summary>
        /// <param name="path">File to save</param>
        /// <param name="list">List of data to save</param>
        public static void Report(string path,List<string> list)
        {
            try
            {
                using (StreamWriter sw = new(path, false, System.Text.Encoding.Default))
                {
                   foreach(var i in list)
                        sw.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
