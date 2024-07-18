Import-Module NtObjectManager
$p = get-ntprocess -name TrustedInstaller.exe
New-Win32process cmd.exe -creationflags Newconsole -parentprocess $p