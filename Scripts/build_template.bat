if (%1) == () goto blank
"%~dp0nuget.exe" pack "%~dp0templates.nuspec"  -OutputDirectory "%~dp0..\Output" -Version %1
goto end
:blank
"%~dp0nuget.exe" pack "%~dp0templates.nuspec"  -OutputDirectory "%~dp0..\Output"
:end