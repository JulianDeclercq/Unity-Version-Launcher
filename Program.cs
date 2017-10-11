using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Unity_Launcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnityVersionLauncher unityVersionLauncher = new UnityVersionLauncher();

            // Set the title of the form
            unityVersionLauncher.Text = "UnityVersionLauncher";

            // Define the border style of the form to a dialog box.
            unityVersionLauncher.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            unityVersionLauncher.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            unityVersionLauncher.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            unityVersionLauncher.StartPosition = FormStartPosition.CenterScreen;

            // Run the form
            Application.Run(unityVersionLauncher);
        }
    }
}