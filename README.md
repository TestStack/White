# TestStack.White
White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages. 

## Introduction
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White. 

We welcome pull requests and reported issues!

If you have any queries, please join our discussion group at [https://groups.google.com/forum/#!forum/teststack_white](https://groups.google.com/forum/#!forum/teststack_white)  

## Getting Started
Install TestStack.White from NuGet

    PM> Install-Package TestStack.White

Download [http://uiautomationverify.codeplex.com/](http://uiautomationverify.codeplex.com/) which is an ESSENTIAL tool when doing UI Automation work.

I have created a sample app which uses the Screen pattern. It is available at [https://github.com/TestStack/White/tree/master/src/Sample%20App](https://github.com/TestStack/White/tree/master/src/Sample%20App)

Documentation
-----------------
 - If you would like to know how to automate specific controls check out Whites UI Test Suite  
[https://github.com/TestStack/White/tree/master/src/TestStack.White.UITests](https://github.com/TestStack/White/tree/master/src/TestStack.White.UITests)
 - For documentation topics, check out the Wiki  
[https://github.com/TestStack/White/wiki](https://github.com/TestStack/White/wiki)
 - For old documentation, check out the CodePlex site (This will be migrated and updated)  
[https://white.codeplex.com/documentation](https://white.codeplex.com/documentation)

Contributions to White's documentation is welcome

## Contributing to White
Pull Requests for White are welcome, please include either Unit or UI Tests covering your changes if possible. 

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