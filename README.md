![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/assets/becometilogo-upscaled.png)



# becometrustedinstaller

Become Trusted Installer 
with this simple collection of Powershell Scripts.


## IN ORDER FOR THIS TO WORK, YOU HAVE TO ENABLE SCRIPT RUNNING IN THE WINDOWS DEV SETTINGS

All my Implementation in this repository is based on the fantastic research by tyrannid (https://www.tiraniddo.dev/  https://github.com/tyranid)

# What are the powershell-scripts doing?
![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/assets/trustedinstaller1.png)
The Windows users out there will probably know the pain of wanting to delete a file in system directories only to find it protected by Microsofts dreading TrustedInstaller.
This script uses PowerShell to "impersonate" TrustedInstaller. 

## installdependencies.ps1
In order to properly use trustedinstallers permissions, we need a proper way to get information from "TrustedInstaller.exe". Also, we need to create a new (child-)process. NtObjectManager is a Powershell Library by Google to do such things. Installdependencies installs said modules version 1.1.20.

## PS.ps1 / FE.ps1 / CMD.ps1
These three scripts all do pretty much the same. 
They use NtObjectManager to get the processname from TrustedInstaller.exe to create a child process of it. By doing so, you get a Powershell/CMD or File Explorer window/terminal with TrustedInstallers permission. 

## starttiservice.ps1 / stoptiservice.ps1
Start / Stop the TrustedInstaller Service

# What is the Executable doing?
The executable is just a wrapper for the .ps1 scripts to make them feel nicer. The executable needs to run with Elevated Privileges in order to run the ps1 scripts as admin.


# roadmap
- Package into a singular .exe file (done to part)
- (create a script that can run core windows services as TrustedInstaller out of the box) 
- Create GUI
- Pack all ps1 scrips into the exe aswell
