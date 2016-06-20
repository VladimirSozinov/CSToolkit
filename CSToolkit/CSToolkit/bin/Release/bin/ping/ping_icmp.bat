@ECHO OFF
MODE CON:COLS=70 LINES=10
@title TAC Toolkit - ICMP Ping Test
ECHO  --------------------------------------------
ECHO   TAC Toolkit - %ping_test% ICMP Ping Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  --------------------------------------------
ECHO.
ECHO   Running 1000 ICMP ping tests against %ping_test%...
ping -t -n 1000 %ping_test%>"%root_dir%\Ping_ICMP.txt"
CLS
@title TAC Toolkit - ICMP Ping Test Complete
ECHO  ---------------------------------------------------
ECHO   TAC Toolkit - ICMP Ping Test
ECHO.
ECHO   ICMP Ping tests complete. This window can be closed.
ECHO  ---------------------------------------------------
ECHO.
PAUSE
EXIT