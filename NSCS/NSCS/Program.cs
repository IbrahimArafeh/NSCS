using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] ConfigLines = System.IO.File.ReadAllLines(@"config.txt");
        string firstLine = ConfigLines[0].ToString(); 
        string machinePath = ConfigLines[1].ToString(); 
        string filePath = ConfigLines[2].ToString(); 
        string exts = ConfigLines[3].ToString();
       
        string[] Stationslines = System.IO.File.ReadAllLines(@"stationsIDs.txt");
        string stationPath = "";
        foreach(string Stationline in Stationslines)
        {
            string sationID = string.Join("", Stationline.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            stationPath = @"" +exts + sationID  + machinePath + filePath;
            try
            {
                // this for test
                //var t = Task.Run(() => CheckOnLogFile(@"C:\\DayEnd.1.log", firstLine, Stationline));
                //t.Wait();

                var t = Task.Run(() => CheckOnLogFile(stationPath, firstLine, sationID));
                t.Wait();


                using (StreamWriter w = File.AppendText("SuccessLog.txt"))
                {
                    Console.WriteLine(sationID + " ----> Done");
                    wirteLog(Stationline, "Done", w); ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                {
                    wirteLog(sationID , ex.Message, w);
                }

            }
        }
      
    }


    static async void CheckOnLogFile(string path, string searchText,string stationID)
    {
        int lineNumber = 0;
        try
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string detectedDate = "";
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    bool isOK = Regex.IsMatch(line, @"[0-9][0-9]\.[0-9][0-9]\s[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");
                    if (isOK)
                    {
                        Regex regex = new Regex(@"[0-9][0-9]\.[0-9][0-9]\s[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");
                        Match match = regex.Match(line);
                        detectedDate = match.ToString();
                    }
                    if (line.Contains(searchText))
                    {
                        using (StreamWriter w = File.AppendText("Resultlog.txt"))
                        {
                            wirteLog(detectedDate, stationID, w);
                        }
                    }
                    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            using (StreamWriter w = File.AppendText("ErrorLog.txt"))
            {
                wirteLog(stationID , ex.Message, w);
            }
        }
      
    }

    public static void wirteLog(string LogDate, string stationNO, TextWriter w)
    {
        w.WriteLine(stationNO + "|" + LogDate);
    }


}