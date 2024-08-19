using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace becometi
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        const string psti = "Import-Module NtObjectManager; $p = Get-NtProcess -name TrustedInstaller.exe; New-Win32Process powershell.exe -CreationFlags NewConsole -ParentProcess $p;";

        public Window1()
        {
            InitializeComponent();
        }

        static void runscript(string scriptname)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
                {
                    Arguments = $"-File \"{scriptname}\"",
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    Verb = "runas" // This ensures the process is started with elevated privileges
                };

                Process process = Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running script: {ex.Message}");
            }
        }

        static void executePowerShellCommand(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
                {
                    Arguments = $"-Command \"{command}\"",
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    Verb = "runas" // This ensures the process is started with elevated privileges
                };

                Process process = Process.Start(processInfo);
                process.WaitForExit(); // Optional: wait for the process to exit
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing PowerShell command: {ex.Message}");
            }
        }

        void powershellastrustedinstaller(string command, string command2)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
                {
                    Arguments = $"-Command \"{command}; {command2}\"",
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    Verb = "runas" // This ensures the process is started with elevated privileges
                };

                Process process = Process.Start(processInfo);
                process.WaitForExit(); // Optional: wait for the process to exit
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing PowerShell command: {ex.Message}");
            }
        }

        private void github_button(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/realdcre/becometrustedinstaller",
                UseShellExecute = true
            });
        }

        private void tyranidslair_button(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.tiraniddo.dev/2017/08/the-art-of-becoming-trustedinstaller.html",
                UseShellExecute = true
            });
        }

       

        private void uninstalldep_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("Uninstall-Package NtObjectManager");
        }

        private void github_profile(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/realdcre/",
                UseShellExecute = true
            });
        }

        private void twitterprofile(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://x.com/real_dcre",
                UseShellExecute = true
            });
        }
    }
}