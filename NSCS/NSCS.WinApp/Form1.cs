using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NSCS.WinApp
{
    public partial class Form1 : Form
    {
        public static List<string> resultListSearchFile { get; set; }
        public static List<string> resultListErrorFile { get; set; }
        
        public Form1()
        {
            InitializeComponent();
            fillDataInFields();
        }

        public void fillDataInFields()
        {
            Properties.Settings.Default.filePath = txtFilePath.Text ;
            Properties.Settings.Default.searchText = txtSearch.Text ;
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
        private void btnRun_Click(object sender, EventArgs e)
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
                    foreach(int StaitonNo in AllStationsNumber)
                    {
                        var t = Task.Run(() => SearchInFile(txtSearch.Text,@"\\"+ StaitonNo + @"-ADN-BOS01\" +txtFilePath, serviceType, StaitonNo));
                        t.Wait();
                    }
                }
                else
                {

                }
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
            if (chkPosMachine.Checked == true)
                selectedMachine = "-ADN-POS01";
            if(chkBosMachine.Checked==true)
                selectedMachine = "-ADN-BOS01";

            return selectedMachine;
        }

        public List<int> allSites()
        {
            List<string> allSites = new List<string>();
            List<int> allSitesInt = new List<int>();
            try
            {
                allSites = Properties.Settings.Default.AllSites.Cast<string>().ToList();
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

        public void SearchInFile(string SearchText,string path,int serviceType,int stationNo)
        {
            int lineNumber = 0;
            try
            {
                lblProgress.Text = "Please Wait ...";
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
                                lbResult.Items.Add(stationNo + " ------------->  Done");
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
                                resultListSearchFile.Add(stationNo+"|"+detectedDate);
                                lbResult.Items.Add(stationNo + " ------------->  Done");
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                resultListErrorFile.Add(stationNo + " --> " + ex.Message);
                lbResult.Items.Add(stationNo + " ------------->  Error");

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}