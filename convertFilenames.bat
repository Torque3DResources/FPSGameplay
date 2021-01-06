echo on
setlocal enabledelayedexpansion
for /r %%i in (*.cs) do ren "%%i" *.tscript
pause