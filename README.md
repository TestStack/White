# TestStack.White
White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages. 

## Introduction
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White. 

## Getting Started
Install TestStack.White from NuGet

    PM> Install-Package TestStack.White

Download [http://uiautomationverify.codeplex.com/](http://uiautomationverify.codeplex.com/) which is an ESSENTIAL tool when doing UI Automation work.

I have created a sample app which uses the Screen pattern. It is available at [https://github.com/TestStack/White/tree/master/src/Sample%20App](https://github.com/TestStack/White/tree/master/src/Sample%20App)

Documentation
-----------------
 
### Documentation Site
[http://teststack.azurewebsites.net/white/index.html](http://teststack.azurewebsites.net/white/index.html)

### Discussion Group
[https://groups.google.com/forum/#!forum/teststack_white](https://groups.google.com/forum/#!forum/teststack_white)

### Sample Applications
[https://github.com/TestStack/White/tree/master/src/Sample%20App](https://github.com/TestStack/White/tree/master/src/Sample%20App)

### Whites UI Tests
[https://github.com/TestStack/White/tree/master/src/TestStack.White.UITests](https://github.com/TestStack/White/tree/master/src/TestStack.White.UITests)

Contributions to White's documentation is welcome

## Contributing to White
Pull Requests for White are welcome, please include either Unit or UI Tests covering your changes if possible. 

### Setting up Git
[http://jake.ginnivan.net/setting-up-git](http://jake.ginnivan.net/setting-up-git)

### Contributing to a TestStack Project
[http://teststack.azurewebsites.net/Contributing.html](http://teststack.azurewebsites.net/Contributing.html)

## Reporting Issues
If possible, please add a failing test to TestStack.White.UITests when you report an issue, this will allow me to fix it, and ensure there is no regression later.

Also include the following information:

 - Operating System
 - Target Framework (WPF, Winforms etc)
 - Optionally but preferred, a failing test or a repro solution.

## Credits
Thanks to Thoughtworks and specifically [Vivek Singh](https://github.com/petmongrels) for starting this project. We have got permission from Vivek to continue this project.

TestStack.White will supersede the following repositories:  
[http://white.codeplex.com/](http://white.codeplex.com/)  
[https://github.com/petmongrels/white](https://github.com/petmongrels/white)  
[https://code.google.com/p/white-project/](https://code.google.com/p/white-project/)