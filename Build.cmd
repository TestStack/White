@ECHO OFF

%~dp0\tools\GitHubFlowVersion\GitHubFlowVersion.exe /ProjectFile %~dp0/TestStack.White.proj /UpdateAssemblyInfo

IF NOT ERRORLEVEL 0 EXIT /B %ERRORLEVEL%

pause