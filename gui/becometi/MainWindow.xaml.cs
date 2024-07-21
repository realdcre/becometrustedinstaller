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

        public MainWindow()
        {
            runscript("restarttiservice.ps1");
        }

        private void ps_button(object sender, RoutedEventArgs e)
        {
            runscript("PS.ps1");
        }

        private void fe_button(object sender, RoutedEventArgs e)
        {
            runscript("fe.ps1");
        }

        private void cmd_button(object sender, RoutedEventArgs e)
        {
            runscript("cmd.ps1");
        }

        private void install_button(object sender, RoutedEventArgs e)
        {
            runscript("installdependencies.ps1");
        }

        private void start_button(object sender, RoutedEventArgs e)
        {
            runscript("restarttiservice.ps1");
        }

        private void stop_button(object sender, RoutedEventArgs e)
        {
            runscript("stoptiservice.ps1");
        }
    }
}