@ECHO OFF
@title CS Toolkit - TCP Traceroute Test
ECHO  -------------------------------------------
ECHO   CS Toolkit - TCP Traceroute Test
ECHO.
ECHO   Do not close this window until indicated.
ECHO  -------------------------------------------
ECHO.
ECHO   Running Test 1 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 2 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 3 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 4 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 5 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 6 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 7 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 8 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 9 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 10 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 11 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 12 of 16 - Performing TCP traceroute to %primary%
bin\trace\tracetcp %primary%:8080>>"%root_dir%\Traceroutes_TCP_Primary.txt" -t 500
ECHO   Running Test 13 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 14 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 15 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
ECHO   Running Test 16 of 16 - Performing TCP traceroute to %backup%
bin\trace\tracetcp %backup%:8080>>"%root_dir%\Traceroutes_TCP_Backup.txt" -t 500
CLS
@title CS Toolkit - TCP Traceroute Test Complete
ECHO  ----------------------------------------------------------
ECHO   CS Toolkit - TCP Traceroute Test
ECHO.
ECHO   TCP traceroute tests complete. This window can be closed.
ECHO  -----------------------------------------------------------
ECHO.
PAUSE
EXIT