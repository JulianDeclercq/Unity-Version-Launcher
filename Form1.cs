using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unity_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Retrieve the installation path from the settings
            string unityInstallationPath = Properties.Settings.Default["UnityInstallationPath"].ToString();

            // Display the currently selected path
            label1.Text = unityInstallationPath;

            // Update the combo box
            UpdateComboBox(unityInstallationPath);
        }

        private void UpdateComboBox(string path)
        {
            // Clear the combobox
            comboBox1.Items.Clear();

            // Add the available unity versions
            List<string> _unityVersions = Directory.GetDirectories(path).Where(x => x.ToLower().Contains("unity")).ToList();
            foreach (string version in _unityVersions)
            {
                // Add the name of the path to the choices
                comboBox1.Items.Add(new ComboBoxItem() { Text = new DirectoryInfo(version).Name, Value = version });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve the unity executable that matches the currently selected folder
            ComboBoxItem _selectedComboBoxItem = (ComboBoxItem)comboBox1.SelectedItem;
            DirectoryInfo _directoryInfo = new DirectoryInfo(_selectedComboBoxItem.Value);

            // Retrieve all executable files and filter for the one with name Unity
            FileInfo unityExecutable = _directoryInfo.GetFiles("Unity.exe", SearchOption.AllDirectories).FirstOrDefault();

            // Check if the unity executable is found
            if (unityExecutable == default(FileInfo))
            {
                MessageBox.Show($"No executables found in selected directory {_directoryInfo.Name}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Run the program
            Process.Start(unityExecutable.FullName);

            // Exit this program
            Application.Exit();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Select unity installation directory
            FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
            DialogResult _result = _folderBrowserDialog.ShowDialog();

            if (_result != DialogResult.OK)
            {
                MessageBox.Show("Invalid selected folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display the currently selected Unity Installation Directory
            label1.Text = _folderBrowserDialog.SelectedPath;

            // Save the path in the settings
            Properties.Settings.Default["UnityInstallationPath"] = _folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();

            // Update the combo box
            UpdateComboBox(_folderBrowserDialog.SelectedPath);
        }
    }
}