using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWLTRemovePRO_App
{
    public partial class Form1 : Form
    {
        static RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        static string AppName = "DWLTRemoverPRO";

        Remover remover;
        bool isStarted;

        int lineCountCurrent;
        int lineCountMax = 20;

        public Form1()
        {
            InitializeComponent();

            if (rkApp.GetValue(AppName) == null)
            {
                AutoStartCheckBox.Checked = false;
            }
            else
            {
                AutoStartCheckBox.Checked = true;
            }

            remover = new Remover(this);

            AddLog("Loading directories from .json file");
            remover.LoadDirectories();
            foreach (string path in remover.UnityDirectories.Keys)
            {
                UnityDirectoryList.Items.Add(path);
            }

            if (AutoStartCheckBox.Checked)
            {
                AddLog("Auto start is set : starting now.");
                remover.StartWatching();
                StartStopButton.Text = "Stop";
                isStarted = true;
            }
        }

        private void AddUnityDirectory_Click(object sender, EventArgs e)
        {
            ChooseUnityDirectoryDialog.Description = "Select Unity Directory";
            ChooseUnityDirectoryDialog.ShowNewFolderButton = false;

            DialogResult result = ChooseUnityDirectoryDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string newPath = ChooseUnityDirectoryDialog.SelectedPath;

                if (remover.AddDirectory(newPath))
                {
                    UnityDirectoryList.Items.Add(newPath);
                }
            }
        }

        private void RemoveUnityDirectories_Click(object sender, EventArgs e)
        {
            for (int i = UnityDirectoryList.Items.Count - 1; i >= 0; i--)
            {
                if (UnityDirectoryList.GetItemChecked(i))
                {
                    remover.RemoveDirectory(UnityDirectoryList.Items[i].ToString());
                    UnityDirectoryList.Items.RemoveAt(i);
                }
            }
        }

        private void StartStop_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                AddLog("Starting to watch...");
                StartStopButton.Text = "Stop";
                remover.StartWatching();
            }
            else
            {
                AddLog("Stoping watch.");
                StartStopButton.Text = "Start";
                remover.StopWatching();
            }

            isStarted = !isStarted;
        }

        private void AutoStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoStartCheckBox.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue(AppName, Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue(AppName, false);
            }
        }

        private delegate void SafeCallDelegate(string text);
        public void AddLog(string log)
        {
            if (LogTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddLog);
                LogTextBox.Invoke(d, new object[] { log });
            }
            else
            {
                if (lineCountCurrent == lineCountMax)
                {
                    string[] lines = LogTextBox.Text
                        .Split(Environment.NewLine.ToCharArray())
                        .Skip(1)
                        .ToArray();
                    LogTextBox.Text = string.Join(Environment.NewLine, lines);
                    LogTextBox.Text += log + "\n";
                }
                else
                {
                    lineCountCurrent++;
                    LogTextBox.Text += log + "\n";
                }
                LogTextBox.ScrollToBottom();
            }



        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            NotifyIcon.BalloonTipTitle = "DWLT Remover PRO";
            NotifyIcon.BalloonTipText = "DWLT Remover PRO minimized to Tray App!";
            if (FormWindowState.Minimized == this.WindowState)
            {
                NotifyIcon.Visible = true;
                NotifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                NotifyIcon.Visible = false;
            }
        }
    }
}
