using System.Diagnostics;
using System.Security.Principal;

    bool IsAdministrator()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    Console.WriteLine("You are running: BecomeTrustedInstaller CLI.1.0 by dcre");
    string path = Directory.GetCurrentDirectory();
    Console.WriteLine("The current directory is {0}", path);
    Console.WriteLine(IsAdministrator());

    Console.WriteLine("Welcome to BecomeTrustedInstaller");
    Console.WriteLine("Select Option:");
    Console.WriteLine("[F] - Run File Explorer");
    Console.WriteLine("[P] - Run PowerShell");
    Console.WriteLine("[C] - Run Command Prompt");

    string inp = Console.ReadLine();

    if (inp == "f" || inp == "F")
    {
        runscript("FE.ps1");
    }
    else if (inp == "P" || inp == "p")
    {
        runscript("PS.ps1");
    }
    else if (inp == "C" || inp == "c")
    {
        runscript("CMD.ps1");
    }
    else
    {
        System.Environment.Exit(0);
    }

    static void runscript(string scriptname)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe");
        processInfo.Arguments = $"-File \"{scriptname}\"";
        processInfo.CreateNoWindow = false;
    // processInfo.UseShellExecute = false;
    processInfo.CreateNoWindow = false;
    processInfo.UseShellExecute = true;
    processInfo.Verb = "runas"; // This ensures the process is started with elevated privileges

    Process process = Process.Start(processInfo);
        process.WaitForExit();

        process.Close();
    }