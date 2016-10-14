if "%EMULATED%"=="true" goto :EOF
installutil /u Sage.CNA.WindowsService.exe > UnInstallService.txt
installutil /unattended Sage.CNA.WindowsService.exe > InstallService.txt
Net start Sage.CNA.WindowsService
exit /B 0

