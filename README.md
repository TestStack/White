# TestStack.White

White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages. 

[![Join the chat at https://gitter.im/TestStack/White](https://badges.gitter.im/TestStack/White.svg)](https://gitter.im/TestStack/White?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Introduction
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White. 

## Build Status
#### Master Branch
[![Build status](https://ci.appveyor.com/api/projects/status/3nq9oblpevt0uu0l/branch/master?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco/branch/master)
[![Test status](http://flauschig.ch/batch.php?type=tests&account=RomanBaeriswyl&slug=white-9yaco&branch=master)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco/branch/master)

#### UIAComWrapper Branch
[![Build status](https://ci.appveyor.com/api/projects/status/3nq9oblpevt0uu0l/branch/UIAComWrapper?svg=true)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco/branch/UIAComWrapper)
[![Test status](http://flauschig.ch/batch.php?type=tests&account=RomanBaeriswyl&slug=white-9yaco&branch=UIAComWrapper)](https://ci.appveyor.com/project/RomanBaeriswyl/white-9yaco/branch/UIAComWrapper)

## Contributing
White needs contributors to keep improving. There is plenty to do:

 - Write documentation. Currently on docs.teststack.net but will likley be migrated to the GitHub wiki, the wiki is publically editable so jump in, migrate a page or improve an existing one.
 - Look into any of the open issues, submit a pull request or suggest a fix which could help the issue be closed
 - Pick up a failing test on the https://github.com/TestStack/White/tree/UIAComWrapper branch. 
 - Add a new test

## Getting Started
Install TestStack.White from NuGet

    PM> Install-Package TestStack.White

Now download one or more of these tools. Each of these has their own strengths and weaknesses and generally using more than one to view the automation properties will be required.

- [Inspect][inspect_download] - This is [part of the Windows SDK][inspect_windows_sdk] and is a good tool in general for looking at automation properties.
- [UI Automation Verify][uiaverify_download] - Also [part of the Windows SDK][uiaverify_windows_sdk] another good general tool for looking at automation properties. There's a [fork of original UIAVerify][uia_verify_teststack_fork] that allows usage of custom patterns and custom properties. For an example how to add your own custom pattern or property to your application, look at [this project][custom_uia_patterns].
- [Snoop][snoop_download] - Only works with WPF applications and is really good at it. Offers much more functionality than just viewing the automation properties.
- [Spy++][Spy++] - This is included in visual studio under the tools menu option. This is good for working with Winforms, Win32 and VB6 applications because it allows you to view the applications window messages and automation properties.

See the [sample apps here](https://github.com/TestStack/White/tree/master/src/Samples) for examples of using White in both WinForms and WPF.

[inspect_download]: http://msdn.microsoft.com/en-US/windows/desktop/bg162891
[inspect_windows_sdk]: https://msdn.microsoft.com/en-us/library/windows/desktop/dd318521(v=vs.85).aspx

[uiaverify_download]: http://msdn.microsoft.com/en-US/windows/desktop/bg162891
[uiaverify_windows_sdk]: http://msdn.microsoft.com/en-us/library/windows/desktop/hh920986(v=vs.85).aspx
[uia_verify_teststack_fork]: https://github.com/TestStack/UIAVerify

[custom_uia_patterns]: https://github.com/TestStack/uia-custom-pattern-managed

[snoop_download]: https://snoopwpf.codeplex.com/

[spy++]: https://msdn.microsoft.com/en-us/library/aa264396(v=vs.60).aspx

Documentation
-----------------
 
### Change Log
[http://docs.teststack.net/White/ChangeLog.html](http://docs.teststack.net/White/ChangeLog.html)

### Documentation Site
[http://teststack.azurewebsites.net/white/index.html](http://teststack.azurewebsites.net/white/index.html)

Also these docs can be found [directly on GitHub](https://github.com/TestStack/TestStack.docs/tree/master/_source/White).

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
