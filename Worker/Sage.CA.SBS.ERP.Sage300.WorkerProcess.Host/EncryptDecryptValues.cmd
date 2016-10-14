
Set EncryptDecryptDirectoryPath=%~dp0bin\

IF NOT EXIST "%EncryptDecryptDirectoryPath%EncryptDecrypt.ps1" (
 set EncryptDecryptDirectoryPath=%~dp0
 )

GOTO :%~1
REM Encrypt the value supplied.
:Encrypt
powershell -command "&{ . %EncryptDecryptDirectoryPath%EncryptDecrypt.ps1; Encrypt -Value '%~2' -Thumbprint "34bf44d7bd8dafa6828a4c51bb84e4544cd4a01b"}" > CryptoTemp.txt
set /p  EncryptedValue=<CryptoTemp.txt
set "%~3=%EncryptedValue%"
 Echo > CryptoTemp.txt
GOTO :eof

REM Encrypt the value supplied.
:Decrypt
powershell -command "&{ . %EncryptDecryptDirectoryPath%EncryptDecrypt.ps1; Decrypt -Value '%~2' -Thumbprint "34bf44d7bd8dafa6828a4c51bb84e4544cd4a01b"}" > CryptoTemp.txt
set /p  DecryptedValue=<CryptoTemp.txt
set "%~3=%DecryptedValue%"
Echo > CryptoTemp.txt
GOTO :eof