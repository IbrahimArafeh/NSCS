using NSCS.WinApp.Properties;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NSCS.WinApp
{
    public partial class Form1 : Form
    {
        public List<string> resultListSearchFile = new List<string>();
        public List<string> resultListErrorFile = new List<string>();

        public Form1()
        {
            InitializeComponent();
            fillDataInFields();
        }

        public void fillDataInFields()
        {
            txtFilePath.Text = Properties.Settings.Default.filePath;
            txtSearch.Text = Properties.Settings.Default.searchText;
            txtFileNameLike.Text = Properties.Settings.Default.FileNameLike;
            lblProgress.Text = "";
            pb.Maximum = allSites().Count();
            List<string> ss = new List<string>();
            foreach (int item in allSites())
            {
                ss.Add(item.ToString());
            }
            rtbStationID.Lines = ss.ToArray();
            
        }

        public void fillSettingsItem()
        {
            Properties.Settings.Default.filePath = txtFilePath.Text;
            Properties.Settings.Default.searchText = txtSearch.Text;
            Properties.Settings.Default.FileNameLike = txtFileNameLike.Text;
            Properties.Settings.Default.Save();
        }
        private async void btnRun_Click(object sender, EventArgs e)
        {
            fillSettingsItem();

            if (checkFillFields())
            {
                List<int> AllStationsNumber = allSites();
                int serviceType = 0;
                string SelectedMahine = selectedMachine();
                if (chkGetDateInFile.Checked)
                {
                    serviceType = 1;
                }
                else
                    serviceType = 2;

                if (chkAnyFileLike.Checked)
                {
                    serviceType = 3;
                }

                if (SelectedMahine == "BOTH")
                {
                    foreach (int StaitonNo in AllStationsNumber)
                    {
                        //Test
                        //if (serviceType == 3)
                        //{
                        //    string fullDirectoryPath1 = txtFilePath.Text;
                        //    string fullDirectoryPath2 = txtFilePath.Text;

                        //    Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath1, 2, StaitonNo, "BOS"));
                        //    task.Start();
                        //    lblProgress.Text = "Progressing File. Please Wait ...";
                        //    int count = await task;

                        //    Task<int> task2 = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath2, 2, StaitonNo, "POS"));
                        //    task2.Start();
                        //    lblProgress.Text = "Progressing File. Please Wait ...";
                        //    int count2 = await task2;

                        //}

                        //Release
                        if (serviceType == 3)
                        {
                            try
                            {
                                string fullDirectoryPath1 = @"\\" + StaitonNo + "-ADN-BOS01" + @"\" + txtFilePath.Text;
                                string fullDirectoryPath2 = @"\\" + StaitonNo + "-ADN-POS01" + @"\" + txtFilePath.Text;
                                ;
                               

                                Task<int> task1 = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath1, serviceType, StaitonNo, "BOS"));
                                task1.Start();
                                lblProgress.Text = "Progressing File. Please Wait ...";
                                int count = await task1;


                                Task<int> task2 = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath2, serviceType, StaitonNo, "POS"));
                                task2.Start();
                                lblProgress.Text = "Progressing File. Please Wait ...";
                                int count2 = await task2;

                            }
                            catch (Exception ex)
                            {
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                                    {
                                        wirteLog(StaitonNo + "...." + ex.Message, w);
                                    }
                                    lbResult.Items.Add(StaitonNo + "..................." + ex.Message);
                                    lbResult.TopIndex = lbResult.Items.Count - 1;
                                }));
                            }
                        }

                        pb.PerformStep();
                    }
                }

                if (SelectedMahine == "-ADN-POS01")
                {
                    foreach (int StaitonNo in AllStationsNumber)
                    {
                        //Test
                        //if (serviceType == 3)
                        //{
                        //    string fallDirectoryPath = txtFilePath.Text;
                        //    ;
                        //    Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fallDirectoryPath, 2, StaitonNo, "POS"));
                        //    task.Start();
                        //    lblProgress.Text = "Progressing File. Please Wait ...";
                        //    int count = await task;

                        //}

                        //Release
                        if (serviceType == 3)
                        {
                            string fallDirectoryPath = @"\\" + StaitonNo + "-ADN-POS01" + @"\" + txtFilePath.Text;
                            ;
                            ///for test
                            ///
                            Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fallDirectoryPath, serviceType, StaitonNo, "POS"));
                            task.Start();
                            lblProgress.Text = "Progressing File. Please Wait ...";
                            int count = await task;
                        }

                        pb.PerformStep();
                    }

                }

                if (SelectedMahine == "-ADN-BOS01")
                {

                    //ProcessOnAllStation(AllStationsNumber,serviceType);
                    foreach (int StaitonNo in AllStationsNumber)
                    {
                        ///for test
                        ///
                        //Task<int> task = new Task<int>(() => SearchInFile(txtSearch.Text, txtFilePath.Text, serviceType, StaitonNo));
                        //task.Start();
                        //lblProgress.Text = "Progressing File. Please Wait ...";
                        //int count = await task;


                        ////Test
                        //if (serviceType == 3)
                        //{
                        //    string fullDirectoryPath1 = txtFilePath.Text;

                        //    Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath1, 2, StaitonNo, "BOS"));
                        //    task.Start();
                        //    lblProgress.Text = "Progressing File. Please Wait ...";
                        //    int count = await task;
                        //}

                        //Release
                        if (serviceType == 3)
                        {
                            string fullDirectoryPath1 = @"\\" + StaitonNo + "-ADN-BOS01" + @"\" + txtFilePath.Text;
                            ;

                            Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fullDirectoryPath1, serviceType, StaitonNo, "BOS"));
                            task.Start();
                            lblProgress.Text = "Progressing File. Please Wait ...";
                            int count = await task;

                        }

                        //Release Version
                        //Task<int> stTask = new Task<int>(() => SearchInFile(txtSearch.Text, @"\\" + StaitonNo + SelectedMahine + @"\" + txtFilePath.Text, serviceType, StaitonNo));
                        //stTask.Start();
                        //lblProgress.Text = "Progressing File. Please Wait ...";
                        //int count2 = await stTask;


                        //lbResult.Items.Add(StaitonNo + "...................... Done");
                        //lbResult.TopIndex = lbResult.Items.Count - 1;

                        pb.PerformStep();
                    }

                    MessageBox.Show("Scan File in all station is Done ", "Done Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                lblProgress.Text = "Done";
            }
            else
                MessageBox.Show("Please Fill All data", "Missing Filling", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool checkFillFields()
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || string.IsNullOrEmpty(txtFilePath.Text) || (chkBosMachine.Checked == false & chkPosMachine.Checked == false))
                return false;
            else
                return true;
        }

        public string selectedMachine()
        {
            string selectedMachine = "";
            if (chkBosMachine.Checked == true && chkPosMachine.Checked == true)
                selectedMachine = "BOTH";
            if (chkPosMachine.Checked == true && chkBosMachine.Checked == false)
                selectedMachine = "-ADN-POS01";
            if (chkBosMachine.Checked == true && chkPosMachine.Checked == false)
                selectedMachine = "-ADN-BOS01";

            return selectedMachine;
        }

        public List<int> allSites()
        {
            List<string> allSites = new List<string>();
            List<int> allSitesInt = new List<int>();
            try
            {
                allSites = Properties.Settings.Default.AllSites.Cast<string>().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                //allSites = Properties.Settings.Default.AllSites.Cast<string>().ToList();
                foreach (string site in allSites)
                {
                    int siteTrimed = Convert.ToInt32(site.Trim());
                    allSitesInt.Add(siteTrimed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allSitesInt;
        }

        public int SearchInFile(string SearchText, string path, int serviceType, int stationNo)
        {
            int lineNumber = 0;
            int res = 0;
            try
            {

                //lblProgress.Text = "Please Wait ...";
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    if (serviceType == 2)
                    {
                        string? line = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(SearchText))
                            {
                                using (StreamWriter w = File.AppendText("Result.txt"))
                                {
                                    wirteLog(stationNo + "|" + line, w);
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        lbResult.Items.Add(stationNo + "......................" + line);
                                        lbResult.TopIndex = lbResult.Items.Count - 1;
                                    }));
                                }
                            }
                        }
                    }

                    if (serviceType == 1)
                    {
                        string detectedDate = "";
                        string? line = "";

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
                            if (line.Contains(SearchText))
                            {
                                using (StreamWriter w = File.AppendText("result.txt"))
                                {
                                    wirteLog(stationNo + "|" + detectedDate, w);
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        lbResult.Items.Add(stationNo + "..................." + detectedDate);
                                        lbResult.TopIndex = lbResult.Items.Count - 1;
                                    }));
                                }
                            }
                        }
                    }



                }
                //lbResult.Items.Add(stationNo + "...................... Done");
                //lbResult.TopIndex = lbResult.Items.Count - 1;
                res = 1;
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate ()
                    {
                        using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                        {
                            wirteLog(stationNo + "...." + ex.Message, w);
                        }
                        lbResult.Items.Add(stationNo + "..................." + ex.Message);
                        lbResult.TopIndex = lbResult.Items.Count - 1;
                    }));
                res = 0;
            }

            return res;

        }

        public int SearchInFileLike(string SearchText, string directory, int serviceType, int stationNo, string machineName)
        {
            int lineNumber = 0;
            int res = 0;
            try
            {
                string[] files = Directory.GetFiles(directory, txtFileNameLike.Text);
                foreach (var file in files)
                {
                    string fileNamee = Path.GetFileName(file);

                    using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (BufferedStream bs = new BufferedStream(fs))
                    using (StreamReader sr = new StreamReader(bs))
                    {
                            string? line = "";

                            while ((line = sr.ReadLine()) != null)
                            {
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        lbResult.Items.Add(stationNo + "..." + machineName + "..." + fileNamee + "......" + line);
                                        lbResult.TopIndex = lbResult.Items.Count - 1;
                                    }));

                            if (line.Contains(SearchText))
                                {
                                    using (StreamWriter w = File.AppendText("namosnt_Result_Log.txt"))
                                    {
                                        wirteLog(stationNo + "|" + machineName + "|" + fileNamee + "|" + line, w);
                                        this.Invoke(new MethodInvoker(delegate ()
                                        {
                                            lbResult.Items.Add(stationNo + "....." + machineName + "......." + fileNamee + "......................" + line);
                                            lbResult.TopIndex = lbResult.Items.Count - 1;
                                        }));
                                    }
                                }
                            }
                        
                    }
                    res = 1;
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                    {
                        wirteLog(stationNo + "|" + machineName + "...." + ex.Message, w);
                    }
                    lbResult.Items.Add(stationNo + "....." + machineName + "..................." + ex.Message);
                    lbResult.TopIndex = lbResult.Items.Count - 1;
                }));
                res = 0;
            }

            return res;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        static async Task wirteLog(string textToWrite, TextWriter w)
        {
            await w.WriteLineAsync(textToWrite);
        }

        public async void ProcessOnAllStation(List<int> AllStationsNumber, int serviceType)
        {
            foreach (int StaitonNo in AllStationsNumber)
            {
                ///for test
                Task<int> task = new Task<int>(() => SearchInFile(txtSearch.Text, txtFilePath.Text, serviceType, StaitonNo));
                task.Start();
                lblProgress.Text = "Progressing File. Please Wait ...";
                int count = await task;


                //Release Version
                Task<int> stTask = new Task<int>(() => SearchInFile(txtSearch.Text, @"\\" + StaitonNo + @"-ADN-BOS01\" + txtFilePath.Text, serviceType, StaitonNo));
                stTask.Start();
                lblProgress.Text = "Progressing File. Please Wait ...";
                int count2 = await stTask;


                lbResult.Items.Add(StaitonNo + "...................... Done");
                lbResult.TopIndex = lbResult.Items.Count - 1;

                pb.PerformStep();
            }
        }


        public double getSqlRam(string dbServerName, int stationID)
        {
            double RamValue = 0;
            string sqlConn = @"Data Source=" + dbServerName + ";Initial Catalog=Master;Integrated Security=True";

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
                            RamValue = output;

                            using (StreamWriter w = File.AppendText("Sql_CmdRam.txt"))
                            {
                                Console.WriteLine(stationID + ".............." + " SqlRam" + ": " + output);
                                wirteLog(stationID + "" + output.ToString(), w);
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                            {
                                wirteLog(stationID + "............" + ex.Message, w);
                            }
                            lbResult.Items.Add(stationID + "..................." + ex.Message);
                            lbResult.TopIndex = lbResult.Items.Count - 1;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                    {
                        wirteLog(stationID + "............" + ex.Message, w);
                    }
                    lbResult.Items.Add(stationID + "..................." + ex.Message);
                    lbResult.TopIndex = lbResult.Items.Count - 1;
                }));
            }

            return RamValue;

        }

        private void btnUpdateSts_Click(object sender, EventArgs e)
        {
            var lines = rtbStationID.Text.Split('\n');
            Properties.Settings.Default.AllSites.Clear();
            foreach (var item in lines)
            {
                string stId = item.ToString();
                Properties.Settings.Default.AllSites.Add(stId);
                Properties.Settings.Default.Save();
            }
            
        }
    }
}