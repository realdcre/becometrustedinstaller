using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;
using System.Windows;

namespace becometi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public MainWindow()
        {
            executePowerShellCommand("cd C:\\windows\\servicing\\; start-service trustedinstaller");
        }

        private void ps_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("Import-Module NtObjectManager; $p = get-ntprocess -name TrustedInstaller.exe; New-Win32process powershell.exe -creationflags Newconsole -parentprocess $p");
        }

        private void fe_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("Import-Module NtObjectManager; $p = get-ntprocess -name TrustedInstaller.exe; New-Win32process explorer.exe -creationflags Newconsole -parentprocess $p");
        }

        private void cmd_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("Import-Module NtObjectManager; $p = get-ntprocess -name TrustedInstaller.exe; New-Win32process cmd.exe -creationflags Newconsole -parentprocess $p");
        }

        private void install_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("Install-Module -Name NtObjectManager -RequiredVersion 1.1.20");
        }

        private void start_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("cd C:\\windows\\servicing\\; start-service trustedinstaller");
        }

        private void stop_button(object sender, RoutedEventArgs e)
        {
            executePowerShellCommand("cd C:\\windows\\servicing\\; stop-service trustedinstaller");
        }
        private void extras_button(object sender, RoutedEventArgs e)
        {
            Window1 secondWindow = new Window1();
            secondWindow.Show();
        }

    }
}