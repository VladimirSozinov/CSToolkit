@ECHO OFF
MODE CON:COLS=70 LINES=10
@title CS Toolkit - DNS Test
CLS
ECHO  -------------------------------------------
ECHO   CS Toolkit - DNS Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  -------------------------------------------
ECHO.
ipconfig /flushdns
ECHO  ------------------------------------------->"%root_dir%\DNS_Data.txt"
ECHO   Tower DNS Results>>"%root_dir%\DNS_Data.txt"
ECHO  ------------------------------------------->>"%root_dir%\DNS_Data.txt"
bin\dns\dig.exe +noall +stats +answer %primary%>>"%root_dir%\DNS_Data.txt"
bin\dns\dig.exe +noall +stats +answer %backup%>>"%root_dir%\DNS_Data.txt"
ECHO  ------------------------------------------->>"%root_dir%\DNS_Data.txt"
ECHO   Website DNS Results>>"%root_dir%\DNS_Data.txt"
ECHO  ------------------------------------------->>"%root_dir%\DNS_Data.txt"
bin\dns\dig.exe +noall +stats +answer -f bin\dns\website_dns_list.txt>>"%root_dir%\DNS_Data.txt"
CLS
@title CS Toolkit - DNS Test Complete
ECHO  ---------------------------------------------------
ECHO   CS Toolkit - DNS Test
ECHO.
ECHO   DNS tests complete. This window can be closed.
ECHO  ---------------------------------------------------
ECHO.
PAUSE
EXIT