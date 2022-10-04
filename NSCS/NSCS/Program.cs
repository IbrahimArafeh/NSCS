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
       
        string[] Stationslines = System.IO.File.ReadAllLines(@"stationsIDs.txt");
        string stationPath = "";
        foreach(string Stationline in Stationslines)
        {
            stationPath = @"\\" + Stationline + "-" + machinePath + filePath;
            Console.WriteLine(stationPath);
            try
            {
                CheckOnLogFile(stationPath, firstLine);
                //CheckOnLogFile(@"C:\\DayEnd.1.log", firstLine);
                Thread.Sleep(150);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
        }
       
    }

    public static void CheckOnLogFile(string path,string searchText)
    {
        int lineNumber = 0;
        using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (BufferedStream bs = new BufferedStream(fs))
        using (StreamReader sr = new StreamReader(bs))
        {
            string line="";
            string detectedDate="";
            while ((line = sr.ReadLine()) != null)
            {
                lineNumber++;
                bool isOK = Regex.IsMatch(line, @"[0-9][0-9]\.[0-9][0-9]\s[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");
                if(isOK)
                {
                    detectedDate=line;
                }
                if (line.Contains(searchText))
                {
                    Console.WriteLine(lineNumber + " : " + detectedDate + ": " + line);
                }
            }
        }
    }

    public static void wirteLog(string LogDate, string stationNO, TextWriter w)
    {
        w.WriteLine(stationNO + "|" + LogDate);
    }


}