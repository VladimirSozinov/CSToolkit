@ECHO OFF
MODE CON:COLS=70 LINES=10
@title CS Toolkit - System Information
ECHO  -------------------------------------------
ECHO   CS Toolkit - System Information
ECHO.
ECHO   Do not close this window until indicated.
ECHO  -------------------------------------------
ECHO.
ECHO  ------------------------------------------->"%root_dir%\System_Information.txt"
ECHO   ipconfig /all Output>>"%root_dir%\System_Information.txt"
ECHO  ------------------------------------------->>"%root_dir%\System_Information.txt"
ipconfig /all>>"%root_dir%\System_Information.txt"
ECHO  ------------------------------------------->>"%root_dir%\System_Information.txt"
ECHO   systeminfo Output>>"%root_dir%\System_Information.txt"
ECHO  ------------------------------------------->>"%root_dir%\System_Information.txt"
systeminfo>>"%root_dir%\System_Information.txt"
CLS
@title CS Toolkit - System Information Captured
ECHO  ------------------------------------------------------------
ECHO   CS Toolkit - System Information
ECHO.
ECHO   System information captured. This window can be closed.
ECHO  ------------------------------------------------------------
ECHO.
PAUSE
EXIT