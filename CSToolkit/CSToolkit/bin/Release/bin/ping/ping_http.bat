@ECHO OFF
MODE CON:COLS=70 LINES=10
@title TAC Toolkit - HTTP Ping Test
ECHO  --------------------------------------------
ECHO   TAC Toolkit - %ping_test% HTTP Ping Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  --------------------------------------------
ECHO.
ECHO   Running 1000 HTTP ping tests against %ping_test%...
bin\ping\http-ping.exe -v -c -d -q -n 1000 http://%ping_test%>"%root_dir%\Ping_HTTP.txt"
CLS
@title TAC Toolkit - HTTP Ping Test Complete
ECHO  ---------------------------------------------------
ECHO   TAC Toolkit - HTTP Ping Test
ECHO.
ECHO   HTTP Ping tests complete. This window can be closed.
ECHO  ---------------------------------------------------
ECHO.
PAUSE
EXIT