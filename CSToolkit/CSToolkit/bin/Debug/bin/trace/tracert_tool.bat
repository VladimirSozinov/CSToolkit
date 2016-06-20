@ECHO OFF
@title CS Toolkit - ICMP Traceroute Test
ECHO  -------------------------------------------
ECHO   CS Toolkit - ICMP Traceroute Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  -------------------------------------------
ECHO.
ECHO   Running Test 1 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 2 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 3 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 4 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 5 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 6 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 7 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 8 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 9 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 10 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 11 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 12 of 16 - Performing ICMP traceroute to %primary%
tracert -w 500 %primary%>>"%root_dir%\Traceroutes_ICMP_Primary.txt"
ECHO   Running Test 13 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 14 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 15 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"
ECHO   Running Test 16 of 16 - Performing ICMP traceroute to %backup%
tracert -w 500 %backup%>>"%root_dir%\Traceroutes_ICMP_Backup.txt"

CLS
@title CS Toolkit - ICMP Traceroute Test Complete
ECHO  ------------------------------------------------------------
ECHO   CS Toolkit - ICMP Traceroute Test
ECHO.
ECHO   ICMP traceroute tests complete. This window can be closed.
ECHO  ------------------------------------------------------------
ECHO.
PAUSE
EXIT