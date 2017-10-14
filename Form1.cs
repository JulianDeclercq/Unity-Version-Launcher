using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Unity_Launcher
{
    public partial class UnityVersionLauncher : Form
    {
        public UnityVersionLauncher()
        {
            InitializeComponent();

            // Retrieve the installation path from the settings
            string unityInstallationPath = Properties.Settings.Default["UnityInstallationPath"].ToString();

            // Display the currently selected path
            currentDirectoryPath.Text = unityInstallationPath;

            // Update the combo box
            UpdateComboBox(unityInstallationPath);
        }

        /// <summary>
        /// Removes last found f and all of the characters that follow it.
        /// </summary>
        /// <param name="target">String to remove trailing f.</param>
        /// <returns>Target string without characters following (and including) last f.</returns>
        private string RemoveTrailingF(string target)
        {
            // Look for an f
            int fIndex = target.LastIndexOf('f');

            // If one is found, remove everything starting from that f
            if (fIndex != -1)
            {
                return target.Substring(0, fIndex);
            }

            // Return the target if there was no trailing f
            return target;
        }

        private string CleanDirectoryName(string name)
        {
            // Remove "Unity_" from the folder name
            // If this is an f version, remove that from the name (this application doesn't consider f versions as different)
            return RemoveTrailingF(name.TrimStart("Unity_".ToCharArray()));
        }

        private void UpdateComboBox(string path)
        {
            // Clear the combobox
            versionSelectorBox.Items.Clear();

            // Check if path is empty (happens e.g. when no properties settings have been set yet at first time launch)
            if (string.IsNullOrEmpty(path))
                return;

            // Add the available unity versions
            List<string> _unityVersions =
                Directory.GetDirectories(path).Where(x => x.ToLower().Contains("unity")).ToList();
            foreach (string fullPath in _unityVersions)
            {
                // Add the name of the path to the choices
                versionSelectorBox.Items.Add(new ComboBoxItem()
                {
                    Text = CleanDirectoryName(new DirectoryInfo(fullPath).Name),
                    Value = fullPath
                });
            }
        }

        private FileInfo FindUnityExecutable(ComboBoxItem comboBoxItem)
        {
            // Retrieve the directory from the comboboxItem
            DirectoryInfo directoryToSearch = new DirectoryInfo(comboBoxItem.Value);

            // Retrieve all executable files and filter for the one with name Unity
            FileInfo unityExecutable =
                directoryToSearch.GetFiles("Unity.exe", SearchOption.AllDirectories).FirstOrDefault();

            // Check if the unity executable is found
            if (unityExecutable == default(FileInfo))
            {
                MessageBox.Show($"No executables found in selected directory {directoryToSearch.Name}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the found or not found executable
            return unityExecutable;
        }

        private void LaunchButtonClick(object sender, EventArgs e)
        {
            // Make sure a version is selected
            if (versionSelectorBox.SelectedItem == null)
            {
                MessageBox.Show("No Unity version was selected to launch.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the unity executable that matches the currently selected folder
            ComboBoxItem _selectedComboBoxItem = (ComboBoxItem)versionSelectorBox.SelectedItem;
            FileInfo unityExecutable = FindUnityExecutable(_selectedComboBoxItem);

            // Run the program
            Process.Start(unityExecutable.FullName);

            // Exit this program
            Application.Exit();
        }

        private void ChangeToolStripMenuItemClick(object sender, EventArgs e)
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
            currentDirectoryPath.Text = _folderBrowserDialog.SelectedPath;

            // Save the path in the settings
            Properties.Settings.Default["UnityInstallationPath"] = _folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();

            // Update the combo box
            UpdateComboBox(_folderBrowserDialog.SelectedPath);
        }

        private void DragDropCallback(object sender, DragEventArgs e)
        {
            // Retrieve the dropped files
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Check if only one folder can be dropped
            if (files.Length > 1)
            {
                MessageBox.Show("Only one item can be dropped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Try/catch block to make sure a folder was dropped and not a file
            try
            {
                DirectoryInfo droppedFolder = new DirectoryInfo(files[0]);
                FileInfo[] textFiles = droppedFolder.GetFiles("*.txt", SearchOption.AllDirectories);

                // Check if the file ProjectVersion.txt exists. If it does, this folder is considered a unity project
                FileInfo projectVersionTextFile = textFiles.FirstOrDefault(x => x.ToString().Equals("ProjectVersion.txt"));
                if (projectVersionTextFile == default(FileInfo))
                {
                    MessageBox.Show("Given folder is not a valid Unity project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve all installed unity versions
                using (StreamReader streamReader = projectVersionTextFile.OpenText())
                {
                    string versionInfo = streamReader.ReadLine();
                    versionInfo = RemoveTrailingF(versionInfo);

                    foreach (var installationFolder in versionSelectorBox.Items)
                    {
                        // Retrieve the unityVersion from the installation folder name
                        string unityVersion = CleanDirectoryName(installationFolder.ToString());

                        // Check if it matches a currently installed version of unity
                        if (versionInfo.Equals($"m_EditorVersion: {unityVersion}"))
                        {
                            // Find the executable.
                            FileInfo unityExecutable = FindUnityExecutable((ComboBoxItem)installationFolder);

                            // Run the unity project
                            Process.Start(unityExecutable.FullName, $"-ProjectPath {droppedFolder.FullName}");

                            // Exit this program
                            Application.Exit();
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Only folders can be dropped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DragEnterCallback(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}