IF '%1'=='' (SET configuration=Debug) ELSE (SET configuration=%1)

REM The .nunit file does currently not work
REM "..\..\src\packages\NUnit.Console.3.0.1\tools\nunit3-console.exe" TestStack.White.nunit

"..\..\src\packages\NUnit.Console.3.0.1\tools\nunit3-console.exe" "..\..\src\TestStack.White.ScreenObjects\bin\%configuration%\TestStack.White.ScreenObjects.UITests.dll" "..\..\src\TestStack.White.UITests\bin\%configuration%\TestStack.White.UITests.dll" "..\..\src\TestStack.White.UnitTests\bin\%configuration%\TestStack.White.UnitTests.dll" "..\..\src\TestStack.White.WebBrowser.UITests\bin\%configuration%\TestStack.White.WebBrowser.UITests.dll" "..\..\src\TestStack.White.WebBrowser.UnitTests\bin\%configuration%\TestStack.White.WebBrowser.UnitTests.dll"

pause