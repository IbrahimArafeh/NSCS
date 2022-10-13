using Microsoft.Management.Infrastructure;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static List<string> stRam = new List<string>();

    private static void Main(string[] args)
    {
        string[] ConfigLines = System.IO.File.ReadAllLines(@"config.txt");
        string firstLine = ConfigLines[0].ToString(); 
        string machinePath = ConfigLines[1].ToString(); 
        string filePath = ConfigLines[2].ToString(); 
        string exts = ConfigLines[3].ToString();
        int serviceType = Convert.ToInt32(ConfigLines[4]);
        string trxSrvBosFilePath = ConfigLines[5].ToString();
        string posMachinePath = ConfigLines[6].ToString();
        string trxSrvPosFilePath = ConfigLines[7].ToString();
        int BosRamCompareValue = Convert.ToInt32(ConfigLines[8]);
        int SqlRamCompareValue = Convert.ToInt32(ConfigLines[9]);

        string[] Stationslines = System.IO.File.ReadAllLines(@"stationsIDs.txt");
        string stationEODPath = "";
        string stationTrxSrvBOSPath = "";
        string stationTrxSrvPOSPath = "";
     

        foreach(string Stationline in Stationslines)
        {
            string sationID = string.Join("", Stationline.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            stationEODPath = @"" +exts + sationID  + machinePath + filePath;
            stationTrxSrvBOSPath = @"" +exts + sationID  + machinePath + trxSrvBosFilePath;
            stationTrxSrvPOSPath = @"" +exts + sationID  + posMachinePath + trxSrvPosFilePath;
            if(serviceType == 2)
            {
                try
                {

                    // //this for test
                    //var t0 = Task.Run(() => CheckOnLogFile(@"C:\\SY_PROCS.TXT", firstLine, sationID, serviceType, sationID + "" + machinePath));
                    //t0.Wait();

                    //var tGetRam = Task.Run(() => getRamUsage(".", sationID, RamCompareValue));
                    //tGetRam.Wait();


                    //using (StreamWriter w = File.AppendText("OptTrxSrv_Success_Log.txt"))
                    //{
                    //    Console.WriteLine(sationID + "BOS ----> Done");
                    //    wirteLog(sationID, "BOS --- Done", w); ;
                    //}

                    //var t00 = Task.Run(() => CheckOnLogFile(@"C:\\SY_PROCS.TXT", firstLine, sationID, serviceType, sationID + "" + posMachinePath));
                    //t00.Wait();

                    //using (StreamWriter w = File.AppendText("OptTrxSrv_Success_Log.txt"))
                    //{
                    //    Console.WriteLine(sationID + "BOS ----> Done");
                    //    wirteLog(sationID, "POS --- Done", w); ;
                    //}






                    //var t = Task.Run(() => CheckOnLogFile(stationTrxSrvBOSPath, firstLine, sationID, serviceType, sationID + "" + machinePath));
                    //t.Wait();

                    //var tGetRam = Task.Run(() => getRamUsage(machinePath, sationID, RamCompareValue));
                    //tGetRam.Wait();


                    //using (StreamWriter w = File.AppendText("OptTrxSrv_Success_Log.txt"))
                    //{
                    //    Console.WriteLine(sationID + " --> BOS ----> Done");
                    //    wirteLog(sationID, "--> BOS ---> Done", w); ;
                    //}

                    //var t2 = Task.Run(() => CheckOnLogFile(stationTrxSrvPOSPath, firstLine, sationID, serviceType, sationID + "" + posMachinePath));
                    //t2.Wait();


                    //using (StreamWriter w = File.AppendText("OptTrxSrv_Success_Log.txt"))
                    //{
                    //    Console.WriteLine(sationID + " ---> POS ----> Done");
                    //    wirteLog(sationID, "---> POS -- Done", w); ;
                    //}

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    using (StreamWriter w = File.AppendText("OptTrxSvr_Error_Log.txt"))
                    {
                        wirteLog(sationID, ex.Message, w);
                    }

                }
            }
            else
            {
                try
                {
                    // this for test
                    //var t = Task.Run(() => CheckOnLogFile(@"C:\\DayEnd.1.log", firstLine, Stationline));
                    //t.Wait();

                    var tGet2323Ram = Task.Run(() => getRamUsage(".", ""));
                    tGet2323Ram.Wait();

                    var tSqlRam = Task.Run(() => getSqlRam("SP02B01ZZ4864A", sationID, SqlRamCompareValue));
                    tSqlRam.Wait();




                    var t = Task.Run(() => CheckOnLogFile(stationEODPath, firstLine, sationID, serviceType, ""));
                    t.Wait();

                    //var tGetRam = Task.Run(() => getRamUsage(machinePath, sationID));
                    //tGetRam.Wait();


                    //var tSqlRam = Task.Run(() => getSqlRam(sationID + machinePath, sationID, SqlRamCompareValue));
                    //tGetRam.Wait();


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
                        wirteLog(sationID, ex.Message, w);
                    }
                }
            }
            
        }
      
    }


    static async void CheckOnLogFile(string path, string searchText,string stationID,int serviceType,string machineName)
    {
        int lineNumber = 0;
        try
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                if(serviceType == 2)
                {
                    string line = "";
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(searchText))
                        {
                            using (StreamWriter w = File.AppendText("OptTrxSvr_Result.txt"))
                            {
                                wirteLog(line, machineName, w);
                            }
                        }
                    }
                }

                else
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
                            using (StreamWriter w = File.AppendText("EOD_Result.txt"))
                            {
                                wirteLog(detectedDate, stationID, w);
                            }
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

        //getRamUsage(machineName,stationID);

    }

    public static void wirteLog(string LogDate, string stationNO, TextWriter w)
    {
        w.WriteLine(stationNO + "|" + LogDate);
    }

    public async static void getRamUsage(string comName,string stationID)
    {
        double RamValue = 0;
        try
        {
            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;
            string machinePath = @"\\" + stationID + comName + "\\root\\CIMV2";
            ManagementScope scope = new ManagementScope(machinePath, connection);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject queryObj in searcher.Get())
            {
                RamValue = Convert.ToUInt64(queryObj["TotalPhysicalMemory"]) / (1024 * 1024);
                Console.WriteLine(stationID + " ---> " + "Ram size :" + RamValue);
                    using (StreamWriter w = File.AppendText("RAM_Result.txt"))
                    {
                        wirteLog(RamValue.ToString(), stationID,w);
                    }
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            using (StreamWriter w = File.AppendText("Ram_ErrorLog.txt"))
            {
                wirteLog(stationID, ex.Message, w);
            }
        }
       
    }


    public async static void getSqlRam(string comName, string stationID, int RamCompareValue)
    {
        double RamValue = 0;
        string sqlConn = @"Data Source=" + comName + ";Initial Catalog=Master;Integrated Security=True";

        try
        {
            using (var connection = new SqlConnection(sqlConn))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd;
                    SqlDataReader dataReader;
                    string sql = "";

                    sql = "select physical_memory_kb/1024 from sys.dm_os_sys_info;";
                    cmd = new SqlCommand(sql, connection);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var output = (int)(long)dataReader.GetInt64(0);
                        using (StreamWriter w = File.AppendText("Sql_CmdRam.txt"))
                        {
                            Console.WriteLine(stationID + " --> " + " SqlRam" + ": " + output);
                            wirteLog(output.ToString(), stationID, w);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        Console.WriteLine(ex.Message);
                        wirteLog(stationID, ex.Message, w);
                        throw;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            using (StreamWriter w = File.AppendText("Ram_ErrorLog.txt"))
            {
                wirteLog(stationID, ex.Message, w);
            }
        }

    }





}