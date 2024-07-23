![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/assets/becometilogo-upscaled.png)



# becometrustedinstaller

Become Trusted Installer 
with the power of PowerShell! 

The Classic PS1 script format will soon be replaced by a in-house Engine. The rollout of BTI core 1-5 built on this new Engine has started with GUI.1.2. IN ORDER FOR THIS TO WORK, YOU HAVE TO ENABLE SCRIPT RUNNING IN THE WINDOWS DEV SETTINGS

All my Implementation in this repository is based on the fantastic research by tyrannid (https://www.tiraniddo.dev/  https://github.com/tyranid)

# What is the Executable doing? (BTI core 1-5+)
The executable contains all neccesary code to execute both legacy PS1 scripts with BTI core 1 and the newer BTI core 1-5 actions.

These work by directly injecting into PowerShell, negating the need for a file and increasing security and speed. 

Most parts of the executeble are for cosmetic purposes and a wrapper for older CLI code still left within.

![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/assets/Becometiuiq.png)

# roadmap
- create installer
- update GUI/ WinUI implementation
- fully update to BTI core 1-5
- pack everything into one executable

# What are the powershell-scripts doing? (BTI core 1)
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

![alt text](https://github.com/realdcre/becometrustedinstaller/blob/main/assets/bticorelogo.png)