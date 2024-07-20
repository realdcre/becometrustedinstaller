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
Console.Clear();

    Console.WriteLine("Welcome to BecomeTrustedInstaller");
    Console.WriteLine("Select Option:");
    Console.WriteLine("[F] - Run File Explorer");
    Console.WriteLine("[P] - Run PowerShell");
    Console.WriteLine("[C] - Run Command Prompt");
    Console.WriteLine("[+] - Extra Features");

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
} else if (inp == "+")
{
    Console.Clear();
    Console.WriteLine("Select Option:");
    Console.WriteLine("[1] - First Run Setup]");
    Console.WriteLine("[2] - Credits");
    Console.WriteLine("[3] - Restart Trusted Installer");
    string imp2 = Console.ReadLine();

    if (imp2 == "1")
    {
        runscript("installdependencies");
    } else if (imp2 == "2")
    {
        Console.Clear();
        Console.WriteLine("BecomeTrustedInstaller CLI1.2 by dcre");
        Console.WriteLine("Running on .NET 8 and Microsoft Powershell");
        Console.WriteLine("1.1.20 of NtObjectManager by Googleprojectzero");
        Console.WriteLine("Based on the Research by tyranid");
        System.Environment.Exit(1);
    } else if (imp2 == "3")
    {
        runscript("restarttiservice.ps1");
    }

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