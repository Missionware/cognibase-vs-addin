SET nugetpath="nuget"
where /q nuget
IF ERRORLEVEL 1 (
    SET nugetpath="%~dp0nuget.exe"
)

if (%1) == () goto blank
%nugetpath% pack "%~dp0templates.nuspec"  -OutputDirectory "%~dp0..\Output" -Version %1
goto end
:blank
%nugetpath% pack "%~dp0templates.nuspec"  -OutputDirectory "%~dp0..\Output"
:end