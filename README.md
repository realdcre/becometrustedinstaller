# becometrustedinstaller

Become Trusted Installer 
with this simple collection of Powershell Scripts.

## IN ORDER FOR THIS TO WORK, YOU HAVE TO ENABLE SCRIPT RUNNING IN THE WINDOWS DEV SETTINGS

on first use: run installdependencies.ps1 as ADMIN

then use the files in scripts folder to launch PS, CMD and FE as Trustedinstaller



All my Implementation in this repository is based on the fantastic research by tyrannid (https://www.tiraniddo.dev/  https://github.com/tyranid)



# What is this doing?
![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/documentation/trustedinstaller1.png)
The Windows users out there will probably know the pain of wanting to delete a file in system directories only to find it protected by Microsofts dreading TrustedInstaller.
This script uses PowerShell to "impersonate" TrustedInstaller. 

## installdependencies.ps1
In order to properly use trustedinstallers permissions, we need a proper way to get information from "TrustedInstaller.exe". Also, we need to create a new (child-)process. NtObjectManager is a Powershell Library by Google to do such things. Installdependencies installs said modules version 1.1.20.

## PS.ps1 / FE.ps1 / CMD.ps1
These three scripts all do pretty much the same. 
They use NtObjectManager to get the processname from TrustedInstaller.exe to create a child process of it. By doing so, you get a Powershell/CMD or File Explorer window/terminal with TrustedInstallers permission. 


# roadmap
- Package into a singular .exe file
- (create a script that can run core windows services as TrustedInstaller out of the box) 
