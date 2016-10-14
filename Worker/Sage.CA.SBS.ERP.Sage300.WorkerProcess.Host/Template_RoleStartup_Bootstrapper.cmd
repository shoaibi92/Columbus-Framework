@Echo off

IF "%EMULATED%"=="true" GOTO ENDINSTALL

SET RoleRoot = Environment.GetEnvironmentVariable("RoleRoot")
SET AppRoot=%RoleRoot%\AppRoot

REM we are creating the enviroment variable to call this during system startup script
SETX  -m AppRoot "%AppRoot%"


mkdir %AppRoot%\Logs

SET LogFileName=%AppRoot%\Logs\Rolebootstrapper_StartupLogfile.txt
 
SET Sage300SetupPath=%systemdrive%\Sage300Download
SET Sage300SetupPath1=%systemdrive%\Sage300setup
SET BlobStorageAccountName=$($env:BlobStorageAccountName)

SET BlobStorageAccountKey="$($env:BlobStorageAccountKey)"
Call  %AppRoot%\EncryptDecryptValues.cmd Decrypt %BlobStorageAccountKey% BlobStorageAccountKey

SET LogTableStorageAccountKey="$($env:TableStorageAccountKey)"
Call  %AppRoot%\EncryptDecryptValues.cmd Decrypt %LogTableStorageAccountKey% LogTableStorageAccountKey

SET Smtppassword="$($env:smtppassword)"
Call  %AppRoot%\EncryptDecryptValues.cmd Decrypt %Smtppassword% Smtppassword

SET BlobContainerName=$($env:Sage300SetupBlobContainerName)
SET BlobScriptContainerName=$($env:Sage300ScriptBlobContainer)

CD /D %AppRoot%\ 


	Bootstrapper /get %BlobContainerName%\WindowsAzureLibsForNet-x64.msi /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
	msiexec  /i  WindowsAzureLibsForNet-x64.msi /quiet
	Bootstrapper /get %BlobScriptContainerName%\Logging.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
	Bootstrapper /get %BlobScriptContainerName%\Sendmail.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
	Echo "Downloading script files and required softwares for logger is done." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL% 


	Echo "Start downloading script  files and required softwares." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	Echo "Start downloading  Sage300Installation Startup script  file." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Bootstrapper /get %BlobScriptContainerName%\AppWorker_SystemOnload_Sage300Installation.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Downloading  Sage300Installation Startup script  file completed." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	Echo "Start downloading  InstallService Startup script  file." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Bootstrapper /get %BlobScriptContainerName%\AppWorker_SystemOnload_InstallService.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Downloading  InstallService Startup script  file completed." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	Echo "Start downloading  AzureFileService  script  file." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Bootstrapper /get %BlobScriptContainerName%\AppWebWorker_SystemReboot_AzureFileService.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Downloading  AzureFileService script  file completed." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
     
	
    Echo "Start downloading  UpdateA4wini Powershell  script  file." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Bootstrapper /get %BlobScriptContainerName%\UpdateA4wini.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Downloading  UpdateA4wini Powershell script  file completed." >> %LogFileName% 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	Echo "Start downloading sage300setup and extracting." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Bootstrapper /get %BlobContainerName%\sage300setup.zip /lr %Sage300SetupPath% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% /unzip  %Sage300SetupPath1% >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "End downloading sage300setup and extracting." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

    Echo "Start downloading ntrights  exe   file." >> %LogFileName% 
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    Bootstrapper /get %BlobContainerName%\ntrights.exe /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    Echo "Downloading  ntrights  exe   file." >> %LogFileName% 
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%


    REM Echo "Start downloading  GrantPermissionToCertificate Powershell  script  file." >> %LogFileName% 
    REM  Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    REM Bootstrapper /get %BlobScriptContainerName%\GrantPermissionToCertificate.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
    REM Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    REM Echo "Downloading  GrantPermissionToCertificate Powershell script  file completed." >> %LogFileName% 
    REM Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
 
    Echo "End downloading script files  and required softwares" >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	Echo "Start Installing Dotnet 3.5 Installation. " >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Powershell -Command "Import-Module ServerManager; Add-WindowsFeature Web-Net-Ext"
	Echo "End Installing Dotnet 3.5 Installation. " >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

  
    Echo "Sage300ERP installation script started." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    Call "AppWorker_SystemOnload_Sage300Installation.cmd"
    Echo "Sage300ERP installation script completed." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%


    Echo "Install windows service  script started." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    Call "AppWorker_SystemOnload_InstallService.cmd" 
    Echo "Install windows service   script completed." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

CD /D %AppRoot%



	Echo "Deleting sage 300 setup file started." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	RMDIR /Q /S %Sage300SetupPath% >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	RMDIR /Q /S %Sage300SetupPath1% >>  %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Deleting sage 300 setup file completed." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%



	Echo "Update  A4w.ini script started." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Powershell %AppRoot%\UpdateA4wini.ps1 -smtpuser "$($env:A4winismtpuser)" -smtppassword  "$($env:A4winismtppassword)" -smtpHandshake "$($env:DataCryptoThumbprint)" 
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
	Echo "Update  A4w.ini  script completed." >> %LogFileName%
	Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%


	 Echo "Azure file server connectivity  started." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
    Call "AppWebWorker_SystemReboot_AzureFileService.cmd"
    Echo "Azure file server connectivity   completed." >> %LogFileName%
    Powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "%LogTableStorageAccountKey%" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "%Smtppassword%" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	
	
	Xcopy /Y  "%AppRoot%\ApplicationLog.txt"  "%AppRoot%\Logs"  >> %LogFileName%

   net stop $($env:ServiceName)
   net start $($env:ServiceName)

:ENDINSTALL
EXIT /B 0

