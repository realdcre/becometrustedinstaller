Import-Module NtObjectManager
$p = get-ntprocess -name TrustedInstaller.exe
New-Win32process explorer.exe -creationflags Newconsole -parentprocess $p