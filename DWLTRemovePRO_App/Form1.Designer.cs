
namespace DWLTRemovePRO_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddUnityDirectoryButton = new System.Windows.Forms.Button();
            this.ChooseUnityDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LeftActionsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.RemoveSelectedDirectoriesButton = new System.Windows.Forms.Button();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.AutoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.UnityDirectoryList = new System.Windows.Forms.CheckedListBox();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.LeftActionsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddUnityDirectoryButton
            // 
            this.AddUnityDirectoryButton.Location = new System.Drawing.Point(3, 3);
            this.AddUnityDirectoryButton.Name = "AddUnityDirectoryButton";
            this.AddUnityDirectoryButton.Size = new System.Drawing.Size(194, 23);
            this.AddUnityDirectoryButton.TabIndex = 0;
            this.AddUnityDirectoryButton.Text = "Add Unity Directory";
            this.AddUnityDirectoryButton.UseVisualStyleBackColor = true;
            this.AddUnityDirectoryButton.Click += new System.EventHandler(this.AddUnityDirectory_Click);
            // 
            // LeftActionsLayout
            // 
            this.LeftActionsLayout.Controls.Add(this.AddUnityDirectoryButton);
            this.LeftActionsLayout.Controls.Add(this.RemoveSelectedDirectoriesButton);
            this.LeftActionsLayout.Controls.Add(this.StartStopButton);
            this.LeftActionsLayout.Controls.Add(this.AutoStartCheckBox);
            this.LeftActionsLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftActionsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.LeftActionsLayout.Location = new System.Drawing.Point(0, 0);
            this.LeftActionsLayout.Name = "LeftActionsLayout";
            this.LeftActionsLayout.Size = new System.Drawing.Size(227, 639);
            this.LeftActionsLayout.TabIndex = 2;
            // 
            // RemoveSelectedDirectoriesButton
            // 
            this.RemoveSelectedDirectoriesButton.Location = new System.Drawing.Point(3, 32);
            this.RemoveSelectedDirectoriesButton.Name = "RemoveSelectedDirectoriesButton";
            this.RemoveSelectedDirectoriesButton.Size = new System.Drawing.Size(194, 23);
            this.RemoveSelectedDirectoriesButton.TabIndex = 1;
            this.RemoveSelectedDirectoriesButton.Text = "Remove Selected Directories";
            this.RemoveSelectedDirectoriesButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedDirectoriesButton.Click += new System.EventHandler(this.RemoveUnityDirectories_Click);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(3, 61);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(194, 23);
            this.StartStopButton.TabIndex = 2;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStop_Click);
            // 
            // AutoStartCheckBox
            // 
            this.AutoStartCheckBox.AutoSize = true;
            this.AutoStartCheckBox.Location = new System.Drawing.Point(3, 90);
            this.AutoStartCheckBox.Name = "AutoStartCheckBox";
            this.AutoStartCheckBox.Size = new System.Drawing.Size(178, 19);
            this.AutoStartCheckBox.TabIndex = 3;
            this.AutoStartCheckBox.Text = "Auto Start On Windows Boot";
            this.AutoStartCheckBox.UseVisualStyleBackColor = true;
            this.AutoStartCheckBox.CheckedChanged += new System.EventHandler(this.AutoStartCheckBox_CheckedChanged);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogTextBox.Location = new System.Drawing.Point(227, 462);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(921, 177);
            this.LogTextBox.TabIndex = 3;
            this.LogTextBox.Text = "";
            // 
            // UnityDirectoryList
            // 
            this.UnityDirectoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnityDirectoryList.FormattingEnabled = true;
            this.UnityDirectoryList.Location = new System.Drawing.Point(227, 0);
            this.UnityDirectoryList.Name = "UnityDirectoryList";
            this.UnityDirectoryList.Size = new System.Drawing.Size(921, 462);
            this.UnityDirectoryList.TabIndex = 4;
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "DWLT Remover PRO";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 639);
            this.Controls.Add(this.UnityDirectoryList);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.LeftActionsLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.LeftActionsLayout.ResumeLayout(false);
            this.LeftActionsLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddUnityDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog ChooseUnityDirectoryDialog;
        private System.Windows.Forms.FlowLayoutPanel LeftActionsLayout;
        private System.Windows.Forms.Button RemoveSelectedDirectoriesButton;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.CheckBox AutoStartCheckBox;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.CheckedListBox UnityDirectoryList;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}

