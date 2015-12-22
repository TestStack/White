IF '%1'=='' (SET configuration=Debug) ELSE (SET configuration=%1)

"..\..\src\packages\NUnit.Console.3.0.1\tools\nunit3-console.exe" TestStack.White.nunit

pause