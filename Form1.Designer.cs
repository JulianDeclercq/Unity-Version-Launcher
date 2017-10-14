using System.Windows.Forms;

namespace Unity_Launcher
{
    partial class UnityVersionLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.versionSelectorBox = new System.Windows.Forms.ComboBox();
            this.currentDirectoryPath = new System.Windows.Forms.Label();
            this.launchButton = new System.Windows.Forms.Button();
            this.versionSelectorInfoLabel = new System.Windows.Forms.Label();
            this.directoryInfoLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.versionSelectorBox.FormattingEnabled = true;
            this.versionSelectorBox.Location = new System.Drawing.Point(60, 158);
            this.versionSelectorBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.versionSelectorBox.Name = "comboBox1";
            this.versionSelectorBox.Size = new System.Drawing.Size(180, 28);
            this.versionSelectorBox.TabIndex = 0;
            // 
            // label1
            // 
            this.currentDirectoryPath.AutoSize = true;
            this.currentDirectoryPath.Location = new System.Drawing.Point(18, 78);
            this.currentDirectoryPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDirectoryPath.Name = "label1";
            this.currentDirectoryPath.Size = new System.Drawing.Size(161, 20);
            this.currentDirectoryPath.TabIndex = 2;
            this.currentDirectoryPath.Text = "Path visualisation text";
            // 
            // button2
            // 
            this.launchButton.Location = new System.Drawing.Point(94, 208);
            this.launchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchButton.Name = "button2";
            this.launchButton.Size = new System.Drawing.Size(112, 35);
            this.launchButton.TabIndex = 3;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.LaunchButtonClick);
            // 
            // label2
            // 
            this.versionSelectorInfoLabel.AutoSize = true;
            this.versionSelectorInfoLabel.Location = new System.Drawing.Point(84, 129);
            this.versionSelectorInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionSelectorInfoLabel.Name = "label2";
            this.versionSelectorInfoLabel.Size = new System.Drawing.Size(132, 20);
            this.versionSelectorInfoLabel.TabIndex = 4;
            this.versionSelectorInfoLabel.Text = "Version to launch";
            // 
            // label3
            // 
            this.directoryInfoLabel.AutoSize = true;
            this.directoryInfoLabel.Location = new System.Drawing.Point(18, 58);
            this.directoryInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.directoryInfoLabel.Name = "label3";
            this.directoryInfoLabel.Size = new System.Drawing.Size(188, 20);
            this.directoryInfoLabel.TabIndex = 5;
            this.directoryInfoLabel.Text = "Unity installation directory";
            // 
            // menuStrip1
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip1";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(304, 35);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.editToolStripMenuItem.Text = "File";
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(367, 30);
            this.changeToolStripMenuItem.Text = "Change Unity installation directory";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItemClick);
            // 
            // UnityVersionLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 258);
            this.Controls.Add(this.directoryInfoLabel);
            this.Controls.Add(this.versionSelectorInfoLabel);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.currentDirectoryPath);
            this.Controls.Add(this.versionSelectorBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UnityVersionLauncher";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Set the title of the form
            this.Text = "UnityVersionLauncher";

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Enabling dragging and dropping of unity project folders
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(DragEnterCallback);
            this.DragDrop += new DragEventHandler(DragDropCallback);

        }

        #endregion

        private ComboBox versionSelectorBox;
        private Label currentDirectoryPath;
        private Button launchButton;
        private Label versionSelectorInfoLabel;
        private Label directoryInfoLabel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem;
    }
}

