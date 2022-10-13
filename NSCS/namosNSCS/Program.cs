internal class Program
{
    private static void Main(string[] args)
    {
        string[] Stationslines = System.IO.File.ReadAllLines(@"stationsIDs.txt");
        foreach (string Stationline in Stationslines)
        {

            string fallDirectoryPath = @"\\" + StaitonNo + "-ADN-POS01" + @"\" + txtFilePath.Text;
        }
        ///for test
        ///
        Task<int> task = new Task<int>(() => SearchInFileLike(txtSearch.Text, fallDirectoryPath, serviceType, StaitonNo, "POS"));
        task.Start();
        lblProgress.Text = "Progressing File. Please Wait ...";
        int count = await task;

    }
}