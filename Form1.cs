using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateZPK_2
{
    public partial class Form1 : Form
    {
        string _WinRAR = @"C:\Program Files\WinRAR\WinRAR.exe";
        string _7zPath = @"C:\Program Files\7-Zip\7z.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Create_Zpk_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Watch faces (*.zip) | *.zip";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string zpkFileName = CreateZPK(openFileDialog.FileName);
                if (zpkFileName != null && zpkFileName.Length > 0)
                {
                    // открываем файл если создали его
                    if (File.Exists(zpkFileName))
                    {
                        Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + zpkFileName));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(_7zPath))
            {
                radioButton_7Zip.Enabled = true;
                radioButton_7Zip.Checked = true;
                button_Create_Zpk.Enabled = true;
            }
            if (File.Exists(_WinRAR))
            {
                radioButton_WinRar.Enabled = true;
                radioButton_WinRar.Checked = true;
                button_Create_Zpk.Enabled = true;
            }
        }

        private string CreateZPK(string fullFileName)
        {
            if (!radioButton_WinRar.Checked && !radioButton_7Zip.Checked) return null;
            if (!File.Exists(fullFileName)) return null;
            string tempDir = Path.Combine(Application.StartupPath, "Temp");
            string targetDir = Path.GetDirectoryName(fullFileName);
            string fileName = Path.GetFileNameWithoutExtension(fullFileName);
            string zipFileName = Path.Combine(tempDir, "device.zip");
            string zpkFileName = Path.Combine(targetDir, fileName + ".zpk");

            if (Directory.Exists(tempDir)) DeleteDirectory(tempDir);
            ZipArchive zip = System.IO.Compression.ZipFile.OpenRead(fullFileName);
            List<ZipArchiveEntry> fileList = zip.Entries.ToList();
            if (!IsWatchFace(fileList))
            {
                MessageBox.Show("Perhaps the file is not a watch face.");
                return null;
            }
            if (File.Exists(zpkFileName))
            {
                DialogResult result = MessageBox.Show("Such a zpk file already exists. Should I overwrite it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return null;
                File.Delete(zpkFileName);
            }

            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            File.WriteAllBytes(zpkFileName, Properties.Resources.WatchFace);
            File.Copy(fullFileName, zipFileName, true);

            if (radioButton_WinRar.Checked)
            {
                string arguments = "a -ep \"";
                arguments += zpkFileName;
                arguments += "\" \"";
                arguments += zipFileName;
                arguments += "\"";

                //Process.Start(_WinRAR, arguments);
                using (Process pr = new Process())
                {
                    pr.StartInfo.FileName = _WinRAR;
                    pr.StartInfo.Arguments = arguments;
                    pr.StartInfo.UseShellExecute = false;
                    pr.Start();
                    pr.WaitForExit();
                } 
            }
            else if (radioButton_7Zip.Checked)
            {
                string arguments = "a \"";
                arguments += zpkFileName;
                arguments += "\" \"";
                arguments += zipFileName;
                arguments += "\"";

                using (Process pr = new Process())
                {
                    pr.StartInfo.FileName = _7zPath;
                    pr.StartInfo.Arguments = arguments;
                    pr.StartInfo.UseShellExecute = false;
                    pr.Start();
                    pr.WaitForExit();
                }
            }

            DeleteDirectory(tempDir);
            return zpkFileName;
        }

        // Проверяем что есть необходимые файлы для циферблата
        private bool IsWatchFace(List<ZipArchiveEntry> fileList)
        {
            bool appJs = false;
            bool appJson = false;
            bool assets = false;
            foreach (ZipArchiveEntry item in fileList)
            {
                if (item.FullName == "app.js") appJs = true;
                if (item.FullName == "app.bin") appJs = true;
                if (item.FullName == "app.json") appJson = true;
                if (item.FullName == "assets/") assets = true;
                if (appJs && appJson && assets) return true;
            }
            return false;
        }

        public static void DeleteDirectory(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                File.Delete(file);
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteDirectory(subDir);
            }

            Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
            Directory.Delete(target_dir);
        }

    }
}
