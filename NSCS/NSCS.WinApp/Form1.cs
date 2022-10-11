using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
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
            //if(resultListSearchFile.Count() > 0)
            //    resultListSearchFile.Clear();
            //resultListErrorFile.Clear();
            lblProgress.Text = "";
        }

        public void fillSettingsItem()
        {
            Properties.Settings.Default.filePath = txtFilePath.Text;
            Properties.Settings.Default.searchText = txtSearch.Text;
            Properties.Settings.Default.Save();
        }
        private async void btnRun_Click(object sender, EventArgs e)
        {
            fillSettingsItem();

            if (checkFillFields())
            {
                List<int> AllStationsNumber = allSites();
                int serviceType=0;
                string SelectedMahine = selectedMachine();
                if (chkGetDateInFile.Checked)
                {
                    serviceType = 1;
                }
                else
                    serviceType = 2;

                if (SelectedMahine == "BOTH")
                {
                    
                }
                if(SelectedMahine == "-ADN-POS01")
                {

                }
                if(SelectedMahine == "-ADN-BOS01")
                {

                    foreach (int StaitonNo in AllStationsNumber)
                    {

                        // for test
                        //var t = Task.Run(() => SearchInFile(txtSearch.Text, txtFilePath.Text, serviceType, StaitonNo));
                        //t.Wait();
                        

                        Task<int> task = new Task<int>(() => SearchInFile(txtSearch.Text, txtFilePath.Text, serviceType, StaitonNo));
                        task.Start();
                        lblProgress.Text = "Progressing File. Please Wait ...";
                        int count = await task;
                        lbResult.Items.Add(StaitonNo + "  -----------------> Done");
                        lbResult.TopIndex = lbResult.Items.Count - 1;

                        //Task<int> stTask = new Task<int>(() => SearchInFile(txtSearch.Text, @"\\" + StaitonNo + @"-ADN-BOS01\" + txtFilePath.Text, serviceType, StaitonNo));
                        //stTask.Start();
                        //lblProgress.Text = "Progressing File. Please Wait ...";
                        //int count2 = await stTask;
                    }
                    MessageBox.Show("Scan File in all station is Done ","Done Task",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                lblProgress.Text = "Done";
            }
            else
                MessageBox.Show("Please Fill All data", "Missing Filling", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool checkFillFields()
        {
            if(string.IsNullOrEmpty(txtFilePath.Text) || string.IsNullOrEmpty(txtFilePath.Text) || (chkBosMachine.Checked == false & chkPosMachine.Checked == false))
                    return false;
            else
                return true;
        }

        public string selectedMachine()
        {
            string selectedMachine = "";
            if (chkBosMachine.Checked == true && chkPosMachine.Checked == true)
                selectedMachine= "BOTH";
            if (chkPosMachine.Checked == true && chkBosMachine.Checked == false)
                selectedMachine = "-ADN-POS01";
            if(chkBosMachine.Checked==true && chkPosMachine.Checked == false)
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

        public int SearchInFile(string SearchText,string path,int serviceType,int stationNo)
        {
            int lineNumber = 0;
            int res = 0;
            try
            {
                Thread.Sleep(50);
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
                                resultListSearchFile.Add(stationNo +"|"+ line);
                                using (StreamWriter w = File.AppendText("Result.txt"))
                                {
                                    wirteLog(stationNo + "|" + line, w);
                                }
                            }
                        }
                    }

                    else
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
                                resultListSearchFile.Add(stationNo + "|" + detectedDate);
                                using (StreamWriter w = File.AppendText("result.txt"))
                                {
                                    wirteLog(stationNo + "|" + detectedDate, w);
                                }
                            }
                        }
                    }
                    
                }
                res = 1;
            }
            catch (Exception ex)
            {
                resultListErrorFile.Add(stationNo + " --> " + ex.Message);
                //lbResult.Items.Add(stationNo + " ------------->  Error");
                using (StreamWriter w = File.AppendText("ErrorLog.txt"))
                {
                    wirteLog(stationNo +" --> "+ ex.Message, w);
                }
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

        public static void wirteLog(string textToWrite, TextWriter w)
        {
            w.WriteLine(textToWrite);
        }
    }
}