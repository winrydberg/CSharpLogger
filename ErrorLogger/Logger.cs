using System;
using System.IO;

namespace ErrorLogger
{
    public class Logger
    {
        public static void LogError(string message, LogType type)
        {
            DateTime date = DateTime.Now;

            int Month = date.Month;
            int Year = date.Year;
            int Day = date.Day;
            var fileName = "";
            switch (type)
            {
                case LogType.Info:
                     fileName = "INFO-"+Year + "-" + Month + "-" + Day;
                    break;
                case LogType.Debug:
                     fileName = "DEBUG-" + Year + "-" + Month + "-" + Day;
                    break;
                case LogType.Error:
                     fileName = "ERROR-" + Year + "-" + Month + "-" + Day;
                    break;
                default:
                    fileName = "ERROR-" + Year + "-" + Month + "-" + Day;
                    break;
            }

            saveToTxt(fileName, message);
        }

        private static Boolean saveToTxt(string date, string message)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (!File.Exists(path+"\\"+date+".txt"))
                {
                    // Create a file to write to.
                    using (TextWriter outFile = File.AppendText(path + "\\" + date + ".txt"))
                    {

                        outFile.WriteLine("==================================" + date + "==================================");
                        outFile.WriteLine();
                        outFile.WriteLine(message);
                        outFile.WriteLine();
                        outFile.WriteLine("==================================" + date + "==================================");
                    }
                }
                else
                {
                    using (TextWriter outFile = File.AppendText(path + "\\" + date + ".txt"))
                    {

                        outFile.WriteLine("==================================" + date + "==================================");
                        outFile.WriteLine();
                        outFile.WriteLine(message);
                        outFile.WriteLine();
                        outFile.WriteLine("==================================" + date + "==================================");
                    }
                }
                
                //TextWriter outFile = new StreamWriter(path + "\\"+date+".txt");
                

                //outFile.Close();
 
                Console.WriteLine("=======================================================================");
                Console.WriteLine("Infomation log");
                Console.WriteLine("File Location: " + path + "\\"+date + ".txt");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to write to File. Try again");
                return false;
            }

        }
    }
}
