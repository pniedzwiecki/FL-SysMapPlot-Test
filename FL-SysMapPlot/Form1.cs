using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FL_SysMapPlot
{
    public partial class Form1 : Form
    {
        string revDefaultComment = "INFRASTRUCTURE COORDINATION";
        string revDate;
        int dwgPerCore;
        int coreOne, coreTwo, coreThree, coreFour, dwgExtra;
        string path;
        string[] filePaths;
        //                               C:\offnetworkcadd\WadeTrim\Autodesk\Ford
        const string C3D_VersionPath = @"C:\offnetworkcadd\WadeTrim\Autodesk\Ford\FordLandVersion.txt";
        string version = "";
        

        public Form1()
        {
            InitializeComponent();
            chkAddRev.Checked = false;
            txtRevComment.Enabled = false;
            chkDefaultComment.Enabled = false;
            btnSelFiles.Enabled = false;
            revDatePick.Enabled = false;
            btnProcessFiles.Enabled = false;
            lblVersion.Text = "Version " + typeof(Form1).Assembly.GetName().Version.ToString();
            version = GetFLC3DVersion(C3D_VersionPath);
            //Check to see if the FordLandVersion.txt file exists and if the version
            //listed in the text file is installed, if both are true then continue else
            //display a message box and then exit.
            if (File.Exists(C3D_VersionPath))
            {
                string appPath = "C:\\Program Files\\Autodesk\\AutoCAD " + version;
                if (Directory.Exists(appPath))
                {
                    lblFLC3DVersion.Text = "WadeTrim C3D " + version;
                }
                else
                {
                    MessageBox.Show("The required version of Civil 3D is not installed on this pc." +
                        "\nContact IT for assistance.");
                    //this.Close();
                    btnSelFolder.Enabled = false;
                    chkAddRev.Enabled = false;
                    lblFLC3DVersion.Text = "WadeTrim";
                }
            }
            else
            {
                MessageBox.Show("Missing FordLandVersion.txt file." +
                    "\nContact IT for assistance.");
                //this.Close();
                btnSelFolder.Enabled = false;
                chkAddRev.Enabled = false;
                lblFLC3DVersion.Text = "WadeTrim";
            }
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                filePaths = Directory.GetFiles(path, "*.dwg");
                DisplayInfo(filePaths, path);
            }
            btnSelFiles.Enabled = false;
        }

        private void DisplayInfo(string[] filePaths, string path)
        {
            if (filePaths.Length == 0)
            {
                MessageBox.Show("No drawing files found in selected folder!" +
                    "\nSelect another folder.", "No drawings found!");
            }
            else
            {
                int cntr = 0;

                foreach (string file in filePaths)
                {
                    rTxtInfo.AppendText(file + Environment.NewLine);
                    cntr++;
                }

                rTxtInfo.AppendText("\n" + filePaths.Length.ToString() + " drawings files.\n");

                if ((cntr % 4) == 0)
                {
                    dwgPerCore = cntr / 4;
                    coreOne = dwgPerCore;
                    coreTwo = dwgPerCore;
                    coreThree = dwgPerCore;
                    coreFour = dwgPerCore;
                }
                else
                {
                    dwgExtra = cntr % 4;
                    dwgPerCore = (cntr - dwgExtra) / 4;

                    if (dwgExtra == 3)
                    {
                        coreOne = dwgPerCore + 1;
                        coreTwo = dwgPerCore + 1;
                        coreThree = dwgPerCore + 1;
                        coreFour = dwgPerCore;
                    }
                    else if (dwgExtra == 2)
                    {
                        coreOne = dwgPerCore + 1;
                        coreTwo = dwgPerCore + 1;
                        coreThree = dwgPerCore;
                        coreFour = dwgPerCore;
                    }
                    else
                    {
                        coreOne = dwgPerCore + 1;
                        coreTwo = dwgPerCore;
                        coreThree = dwgPerCore;
                        coreFour = dwgPerCore;
                    }
                }

                rTxtInfo.AppendText("\nDrawings per core (+/-) = " + dwgPerCore.ToString());
                rTxtInfo.AppendText("\n" + coreOne + " files in core 1");
                rTxtInfo.AppendText("\n" + coreTwo + " files in core 2");
                rTxtInfo.AppendText("\n" + coreThree + " files in core 3");
                rTxtInfo.AppendText("\n" + coreFour + " files in core 4\n");

                btnProcessFiles.Enabled = true;
            }
        }

        private void WriteBatchFiles(string[] filePaths, int core, int count, string corName, string path)
        {
            StreamWriter batchOut = new StreamWriter(path + "\\" + corName, append: true);

            int increment = count - core;

            while (increment < count)
            {
                batchOut.WriteLine("\"C:\\Program Files\\Autodesk\\AutoCAD " + version + "\\accoreconsole.exe\"" + " /i "
                    + "\"" + filePaths[increment] + "\""
                    + " /s "
                    + "\"C:\\offnetworkcadd\\WadeTrim\\Autodesk\\Support\\Lisp\\CAD Management\\FL-SysMapPlot.scr\""
                    + " /l en-US");
                increment++;
            }

            batchOut.WriteLine("exit");

            batchOut.Close();
        }

        private string GetFLC3DVersion(string path)
        {
            string version;

            using (StreamReader versionTxt = new StreamReader(path))
            {
                version = versionTxt.ReadLine();
            }

            return version;
        }

        private void btnSelFiles_Click(object sender, EventArgs e)
        {
            btnSelFolder.Enabled = false;
        }

        private void chkAddRev_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddRev.Checked == true)
            {
                txtRevComment.Enabled = true;
                chkDefaultComment.Enabled = true;
                chkDefaultComment.Checked = true;
                txtRevComment.Text = revDefaultComment;
                revDatePick.Enabled = true;
            }
            else if (chkAddRev.Checked == false)
            {
                chkDefaultComment.Enabled = false;
                chkDefaultComment.Checked = false;
                chkDefaultComment.Enabled = false;
                txtRevComment.Text = "";
                txtRevComment.Enabled = false;
                revDatePick.Enabled = false;

            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            rTxtInfo.Clear();
            rTxtInfo.AppendText("Processing files...");

            WriteBatchFiles(filePaths, coreOne, coreOne, "CoreOne.bat", path);
            WriteBatchFiles(filePaths, coreTwo, (coreOne + coreTwo), "CoreTwo.bat", path);
            WriteBatchFiles(filePaths, coreThree, (coreOne + coreTwo + coreThree), "CoreThree.bat", path);
            WriteBatchFiles(filePaths, coreFour, (coreOne + coreTwo + coreThree + coreFour), "CoreFour.bat", path);

            if (chkAddRev.Checked == true)
            {
                StreamWriter revInfo = new StreamWriter(path + "\\revInfo.rev");
                revInfo.WriteLine(revDate = revDatePick.Value.ToString("MM/dd/yyyy"));
                if (chkDefaultComment.Checked == true)
                {
                    revInfo.WriteLine(revDefaultComment);
                }
                else
                {
                    revInfo.WriteLine(txtRevComment.Text);
                }

                revInfo.Close();

            }

            ProcessStartInfo CoreOne;
            ProcessStartInfo CoreTwo;
            ProcessStartInfo CoreThree;
            ProcessStartInfo CoreFour;

            Process ProcCoreOne;
            Process ProcCoreTwo;
            Process ProcCoreThree;
            Process ProcCoreFour;

            CoreOne = new ProcessStartInfo("cmd.exe", @"/c " + path + "\\CoreOne.bat")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            CoreTwo = new ProcessStartInfo("cmd.exe", @"/c " + path + "\\CoreTwo.bat")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            CoreThree = new ProcessStartInfo("cmd.exe", @"/c " + path + "\\CoreThree.bat")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            CoreFour = new ProcessStartInfo("cmd.exe", @"/c " + path + "\\CoreFour.bat")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            ProcCoreOne = Process.Start(CoreOne);
            ProcCoreTwo = Process.Start(CoreTwo);
            ProcCoreThree = Process.Start(CoreThree);
            ProcCoreFour = Process.Start(CoreFour);

            ProcCoreOne.WaitForExit();
            ProcCoreTwo.WaitForExit();
            ProcCoreThree.WaitForExit();
            ProcCoreFour.WaitForExit();

            ProcCoreOne.Close();
            ProcCoreTwo.Close();
            ProcCoreThree.Close();
            ProcCoreFour.Close();

            MessageBox.Show("Process Complete", "Ford Land System Map Plots");

            VerifyPlots();

            CleanUpFiles();

        }

        private void CountPdfs()
        {
            string[] pdfPaths = Directory.GetFiles(path, "*.pdf");

            if (pdfPaths.Length == filePaths.Length)
            {
                rTxtInfo.Clear();
                rTxtInfo.AppendText("All drawings were plotted to pdf.");
            }
            else if ((filePaths.Length - pdfPaths.Length) == 1)
            {
                int missing = (filePaths.Length - pdfPaths.Length);
                rTxtInfo.Clear();
                rTxtInfo.AppendText(missing.ToString() + " drawing did not plot to pdf.");
                //VerifyPlots();
            }
            else
            {
                int missing = (filePaths.Length - pdfPaths.Length);
                rTxtInfo.Clear();
                rTxtInfo.AppendText(missing.ToString() + " drawings did not plot to pdf.");
                //VerifyPlots();
            }
        }

        private void CleanUpFiles()
        {
            if (File.Exists(path + "\\CoreOne.bat"))
            {
                File.Delete(path + "\\CoreOne.bat");
            }
            if (File.Exists(path + "\\CoreTwo.bat"))
            {
                File.Delete(path + "\\CoreTwo.bat");
            }
            if (File.Exists(path + "\\CoreThree.bat"))
            {
                File.Delete(path + "\\CoreThree.bat");
            }
            if (File.Exists(path + "\\CoreFour.bat"))
            {
                File.Delete(path + "\\CoreFour.bat");
            }
            if (File.Exists(path + "\\revInfo.rev"))
            {
                File.Delete(path + "\\revInfo.rev");
            }
        }

        private void VerifyPlots()
        {
            rTxtInfo.Clear();
            string dwgName;
            string pdfName;
            int position;
            string fullPath;

            string[] pdfPaths = Directory.GetFiles(path, "*.pdf");

            foreach (string file in filePaths)
            {
                fullPath = file;
                position = fullPath.LastIndexOf('\\');
                dwgName = fullPath.Substring(position + 1);
                pdfName = dwgName.Substring(0, dwgName.Length - 4) + "*.pdf";
                bool fileExist = Directory.EnumerateFiles(path, pdfName).Any();

                if (!fileExist)
                {
                    rTxtInfo.AppendText(dwgName + " was not plotted to pdf!\n");
                }
            }
        }

        private void revDatePick_ValueChanged(object sender, EventArgs e)
        {
            revDate = revDatePick.Value.ToString("MM/dd/yyyy");
        }

        private void chkDefaultComment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDefaultComment.Checked == true)
            {
                txtRevComment.Enabled = false;
                txtRevComment.Text = revDefaultComment;
            }
            else if (chkDefaultComment.Checked == false)
            {
                txtRevComment.Enabled = true;
                txtRevComment.Text = "";
                txtRevComment.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rTxtInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}