@ECHO OFF
MODE CON:COLS=70 LINES=10
@title CS Toolkit - TCP Ping Test
ECHO  --------------------------------------------
ECHO   CS Toolkit - %ping_test% TCP Ping Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  --------------------------------------------
ECHO.
ECHO   Running 1000 TCP ping tests against %ping_test%...
ECHO Pinging %ping_test%...>"%root_dir%\Ping_TCP.txt"
bin\ping\tcping -n 1000 -w 500 %ping_test% 80>>"%root_dir%\Ping_TCP.txt"
CLS
@title CS Toolkit - TCP Ping Test Complete
ECHO  ---------------------------------------------------
ECHO   CS Toolkit - TCP Ping Test
ECHO.
ECHO   TCP Ping tests complete. This window can be closed.
ECHO  ---------------------------------------------------
ECHO.
PAUSE
EXIT