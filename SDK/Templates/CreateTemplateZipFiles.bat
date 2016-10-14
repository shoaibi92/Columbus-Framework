call :Zip BusinessRepository
call :Zip Interfaces
call :Zip Models
call :Zip Resources
call :Zip Services
call :Zip Web
call :Zip Sage300SolutionTemplate

goto :EOF

REM ***********************************
REM *** Function Definitions

:Zip
cd "%~1"
"C:\Program Files\7-Zip\7z" a -r ..\"%~1".zip *.*
cd ..
goto :EOF
