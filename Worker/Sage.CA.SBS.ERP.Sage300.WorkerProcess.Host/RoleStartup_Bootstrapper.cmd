@Echo off

IF "%EMULATED%"=="true" GOTO ENDINSTALL

SET RoleRoot = Environment.GetEnvironmentVariable("RoleRoot")
SET AppRoot=%RoleRoot%\AppRoot

SET LogFileName=%AppRoot%\IIS_StartupLogfile.txt
 
SET Sage300SetupPath=%systemdrive%\Sage300Download
SET Sage300SetupPath1=%systemdrive%\Sage300setup
SET BlobStorageAccountName=$($env:BlobStorageAccountName)
SET BlobStorageAccountKey=$($env:BlobStorageAccountKey)
SET BlobContainerName=$($env:Sage300SetupBlobContainerName)
SET BlobScriptContainerName=$($env:Sage300ScriptBlobContainer)

CD /D %AppRoot%\ 

Echo "Start downloading script files and required software for logger." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
  Bootstrapper /get %BlobContainerName%\WindowsAzureLibsForNet-x64.msi /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
msiexec  /i  WindowsAzureLibsForNet-x64.msi /quiet
Bootstrapper /get %BlobScriptContainerName%\Logging.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
Bootstrapper /get %BlobScriptContainerName%\Sendmail.ps1 /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>%LogFileName% 
Echo "End downloading script files and required softwares for logger." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL% 



Echo "Start downloading script  files and required softwares." >> %LogFileName% 
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

   Bootstrapper /get %BlobScriptContainerName%\AppWorker_SystemOnload_Sage300Installation.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
   powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

   Bootstrapper /get %BlobScriptContainerName%\AppWorker_SystemOnload_InstallService.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
   powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

   Bootstrapper /get %BlobScriptContainerName%\AppWebWorker_SystemReboot_AzureFileService.cmd /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
   powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

	 Echo "Start downloading sage300setup and extracting." >> %LogFileName%
     Bootstrapper /get %BlobContainerName%\sage300setup.zip /lr %Sage300SetupPath% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% /unzip  %Sage300SetupPath1% >>	%LogFileName%
	 Echo "End downloading sage300setup and extracting." >> %LogFileName%
    powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

   Bootstrapper /get %BlobContainerName%\ntrights.exe /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
   powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

   Bootstrapper /get %BlobScriptContainerName%\ODBC.reg /lr %AppRoot% /sc DefaultEndpointsProtocol=https;AccountName=%BlobStorageAccountName%;AccountKey=%BlobStorageAccountKey% >>	%LogFileName%
   powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL% 

  Echo "End downloading script files  and required softwares" >> %LogFileName%
  powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

Echo "Sage300ERP installation script started." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
Call "AppWorker_SystemOnload_Sage300Installation.cmd"  >> %LogFileName%
Echo "Sage300ERP installation script completed." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%


Echo "Install windows service  script started." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
Call "AppWorker_SystemOnload_InstallService.cmd"  >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
Echo "Install windows service   script completed." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

CD /D %AppRoot%

REM Echo "This is taken care in Web role."
REM Echo "Azure file service script started." >> %LogFileName%
REM call "AppWebWorker_SystemReboot_AzureFileService.cmd"
REM Echo "Azure file service script completed." >> %LogFileName%

Echo "Deleting sage 300 setup file started." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
RMDIR /Q /S %Sage300SetupPath% >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
RMDIR /Q /S %Sage300SetupPath1% >>  %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%
Echo "Deleting sage 300 setup file completed." >> %LogFileName%
powershell %AppRoot%\Logging.ps1 -LogFilePath %LogFileName% -StorageAccountName "$($env:TableStorageAccountName)" -StorageAccountKey "$($env:TableStorageAccountKey)" -tableName "$($env:TableName)" -smtpuser "$($env:smtpuser)" -smtppassword "$($env:smtppassword)" -fromemailaddress "$($env:fromemailaddress)" -toemailaddress "$($env:toemailaddress)" -errorlevel %ERRORLEVEL%

:ENDINSTALL
EXIT /B 0