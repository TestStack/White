# TestStack.White

[![Join the chat at https://gitter.im/TestStack/White](https://badges.gitter.im/TestStack/White.svg)](https://gitter.im/TestStack/White?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages. 

## Introduction
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White. 

## Build Status
[![Build status](https://ci.appveyor.com/api/projects/status/3nq9oblpevt0uu0l?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco)
[![Test status](http://flauschig.ch/batch.php?type=tests&account=RomanBaeriswyl&slug=white-9yaco)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco/branch/nunit)

## Contributing
White needs contributors to keep improving. There is plenty to do:

 - Write documentation. Currently on docs.teststack.net but will likley be migrated to the GitHub wiki, the wiki is publically editable so jump in, migrate a page or improve an existing one.
 - Look into any of the open issues, submit a pull request or suggest a fix which could help the issue be closed
 - Pick up a failing test on the https://github.com/TestStack/White/tree/UIAComWrapper branch. 
 - Add a new test

## Getting Started
Install TestStack.White from NuGet

    PM> Install-Package TestStack.White

[Download UI Automation Verify][uiaverify_download], now [part of the Windows SDK][uiaverify_windows_sdk], which is an ESSENTIAL tool when doing UI Automation work.

See the [sample apps here](https://github.com/TestStack/White/tree/master/src/Samples) for examples of using White in both WinForms and WPF.

[uiaverify_download]: http://msdn.microsoft.com/en-US/windows/desktop/bg162891
[uiaverify_windows_sdk]: http://msdn.microsoft.com/en-us/library/windows/desktop/hh920986(v=vs.85).aspx

Documentation
-----------------
 
### Change Log
[http://docs.teststack.net/White/ChangeLog.html](http://docs.teststack.net/White/ChangeLog.html)

### Documentation Site
[http://teststack.azurewebsites.net/white/index.html](http://teststack.azurewebsites.net/white/index.html)

### Discussion Group
[https://groups.google.com/forum/#!forum/teststack_white](https://groups.google.com/forum/#!forum/teststack_white)

### Sample Applications
[https://github.com/TestStack/White/tree/master/src/Samples](https://github.com/TestStack/White/tree/master/src/Samples)

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
