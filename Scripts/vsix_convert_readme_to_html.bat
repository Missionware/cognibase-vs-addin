"%~dp0pandoc.exe" -s -o "%~dp0..\Assets\readme.md" "%~dp0..\Assets\readmeheader.md" "%~dp0..\Assets\readmefooter.md" 

"%~dp0pandoc.exe" -s -o "%~dp0..\Assets\readme_vsix.md" "%~dp0..\Assets\readmeheader_vsix.md" "%~dp0..\Assets\readmefooter.md" 

"%~dp0pandoc.exe" -s -o "%~dp0..\Source\TemplatesVsix\CognibaseTemplates\GettingStarted.html" "%~dp0..\Assets\readme.md" "%~dp0..\Assets\readmefooter.md" 