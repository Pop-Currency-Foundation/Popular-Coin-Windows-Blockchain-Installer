using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.ComponentModel;

namespace POPCoinBlockchain
{
    public partial class Form1 : Form
    {
        bool HAVE_ZIP = false;
        string ZipFilePath = string.Empty;
        string PopDataPath = string.Empty;
        const string ZipFileName = "popblockchain.zip";
        string ZipFilePathName { get{ return ZipFilePath + "\\" + ZipFileName; }}

        

        public Form1()
        {
            InitializeComponent();

            EnsureInstallerAppData();

            try
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)))
                {
                    if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POPCoin"))
                    {
                        PopDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POPCoin\\";
                        txtInstallLocation.Text = PopDataPath;
                    }
                    else
                    {
                        MessageBox.Show("The POPCoin data folder was not found in the default location.  If you haven't already, try running the POP wallet first, then close it, then run this app again.\n\r\n\rIf you have already run the wallet for the first time and are still seeing this message, you will have to supply the path to the wallet data folder.","POPCoin Default Data Folder Not Found",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                } else
                {

                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message,"Error Checking Data Folder");
            }
        }
        private void btnChooseInstallDir_Click(object sender, EventArgs e)
        {
            try
            {
                var FD = new System.Windows.Forms.FolderBrowserDialog();
                FD.SelectedPath = txtInstallLocation.Text;
                FD.Description = "Select the location for the blockchain files";

                DialogResult result = FD.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtInstallLocation.Text = FD.SelectedPath;
                    PopDataPath = FD.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message,"Error showing folder picker: " + ex.Message);
            }
        }

        private void btnLoadBlockchain_Click(object sender, EventArgs e)
        {
            if (!EnsurePopData())
            {
                ShowError("The specified folder does not exist.  Please specify a destination folder for the POP blockchain files.", "Folder Not Found");
            }
            else
            {
                lstProgress.Items.Clear();
                lstProgress.Items.Add("Installing to " + PopDataPath); this.Refresh();

                if (AlreadyHaveBlockchainZip())
                {
                    if (MessageBox.Show("Found a previously downloaded blockchain file.  Use it?", "Found Previous Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        HAVE_ZIP = true;
                    }
                    else
                    {
                        RemovePriorBlockchainZip();
                    }
                }

                if (HAVE_ZIP)
                    // skip download, go to install files
                    timer1.Enabled = true;
                else
                    DownloadZipFile();
            }
            
        }

        string InstallBlockchainFiles()
        {
            // \blocks\
            // \chainstate\

            string ret = "Unknown error";

            try
            {
                if (File.Exists(ZipFilePathName))
                {
                    // clean any existing blockchain folders
                    AddToProgress("Removing prior blockchain files");
                    try { Directory.Delete(PopDataPath + "\\blocks\\",true); } catch(Exception ex) { AddToProgress("Removing blocks: " + ex.Message); }
                    try { Directory.Delete(PopDataPath + "\\chainstate\\",true); } catch (Exception ex) { AddToProgress("Removing chainstate: " + ex.Message); }

                    this.Cursor = Cursors.WaitCursor;
                    AddToProgress("Writing blockchain files ...");
                    ZipFile.ExtractToDirectory(ZipFilePathName,PopDataPath);
                    this.Cursor = Cursors.Default;
                    AddToProgress("... done");
                    ret = "OK";
                }
                else
                {
                    AddToProgress("Could not find " + ZipFileName);
                    ret = "Could not find " + ZipFileName;
                }

            }
            catch (Exception ex)
            {
                AddToProgress(ex.Message);
                ret = "Error writing blockchain files: " + ex.Message;
            }

            return ret;

        }

        void ShowInfo(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ShowWarn(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        void ShowError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void EnsureInstallerAppData()
        {
            try
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)))
                {
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POPCoinBlockchainInstaller"))
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POPCoinBlockchainInstaller");
                        ZipFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\POPCoinBlockchainInstaller";
                    }
                }
                else // no appdata found
                {
                    ShowError("No AppData folder found","Folder Not Found");
                }

                }
            catch (Exception ex)
            {
                ShowError("While creating installer data folder: " + ex.Message,"Error Validating AppData");
            }

        }
        bool EnsurePopData()
        {
            if (Directory.Exists(PopDataPath))
                return true;
            else
                return false;
        }
        bool AlreadyHaveBlockchainZip()
        {
            if (File.Exists(ZipFilePathName))
                return true;
            else
                return false;
        }
        void RemovePriorBlockchainZip()
        {
            try
            {
                File.Delete(ZipFilePathName);
            }
            catch (Exception ex)
            {
                AddToProgress("Problem removing prior zip: " + ex.Message);
            }
        }
        void DownloadZipFile()
        {
            // start the zip watchdog timer
            timer1.Enabled = true;

            startDownload(ZipFilePath);
        }

        private void startDownload(string destfolder)
        {
            string dlurl = string.Empty;
            try { dlurl = System.Configuration.ConfigurationManager.AppSettings["DownloadURL"]; } catch { }

            if (dlurl.Length > 0)
            {
                AddToProgress("Downloading the blockchain archive");

                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(dlurl), ZipFilePathName);
            }
            else
            {
                ShowError("No download URL specified in the config file.  Please ensure appsettings DownloadURL key exists and points to a valid POPCoin blockchain archive","No Download URL Specified");
            }

        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            AddToProgress("Download complete");

            // set flag for zip timer
            HAVE_ZIP = true;
        }

        void AddToProgress(string msg)
        {
            lstProgress.Items.Add(msg); this.Refresh();
            lstProgress.TopIndex = lstProgress.Items.Count - 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // watches for zip acquisition and extracts it when ready
            if (HAVE_ZIP)
            {
                timer1.Enabled = false;

                string InstallResult = InstallBlockchainFiles();

                if (InstallResult == "OK")
                {
                    if (MessageBox.Show("Finished installing the blockchain.  The downloaded blockchain archive is large and is no longer needed on this computer.  If you're installing the POPCoin blockchain on other computers, select 'No' here and copy it from your AppData\\Roaming\\POPCoinBlockchainInstaller.\n\r\n\rWould you like to remove the blockchain .zip archive from your system?", "Keep Downloaded Archive?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(ZipFilePathName);
                            AddToProgress("Zip archive removed");
                        }
                        catch (Exception ex)
                        {
                            ShowError("There was a problem removing the zip archive, you'll have to do it yourself.\n\r\n\rError: " + ex.Message,"Problem Removing Archive");
                        }
                    }

                    ShowInfo("Close this app and run the POPCoin wallet.\n\r\n\rThe first time you open your POPCoin wallet after this, it will need to rebuild indexes, which may take 30 minutes or more.  That's just for the first time, please be patient.", "Installation Completed");
                }
                else
                    ShowError("There was a problem installing the blockchain: " + InstallResult, "Problem Installing Blockchain");

            }
        }
    }
}
