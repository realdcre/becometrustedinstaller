echo off
Import-Module NtObjectManager
$p = get-ntprocess -name TrustedInstaller.exe
New-Win32process powershell.exe -creationflags Newconsole -parentprocess $p