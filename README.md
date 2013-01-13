# TestStack.White
White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. It is .NET based and does not require the use of any proprietary scripting languages. Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages. 

## Introduction
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White.

We welcome pull requests and reported issues!

If you have any queries, please join our discussion group at https://groups.google.com/forum/#!forum/teststack_white  

### Goals
Our aim is to bring project white up to date and make it an active open source project again! My top priority goals are:

 - ~~Upgrade White to .net 4.0~~
 - ~~Create NuGet packages~~
 - Get tests working
 - CI Build
 - Clean up API (more generic overloads etc)
 - First class screen pattern support
 - ~~Remove Bricks dependency~~
 - ~~Remove legacy projects/Cleanup repository~~
 - Modern App (Xaml) Support

There will obviously be more fixes/changes, but these are the major goals

## Getting Started
Install White from NuGet

    PM> Install-Package TestStack.White

Download [http://uiautomationverify.codeplex.com/](http://uiautomationverify.codeplex.com/) which is an ESSENTIAL tool when doing UI Automation work.

I have created a sample app which uses the Screen pattern. It is available at https://github.com/TestStack/White/tree/master/src/Sample%20App

## Credits
Thanks to Thoughtworks and specifically [Vivek Singh](https://github.com/petmongrels) for starting this project. We have got permission from Vivek to continue this project.

TestStack.White will supersede the following repositories:  
[http://white.codeplex.com/](http://white.codeplex.com/)  
[https://github.com/petmongrels/white](https://github.com/petmongrels/white)  
[https://code.google.com/p/white-project/](https://code.google.com/p/white-project/)

## Legacy Features/Projects
We will be removing some projects in an effort to make White easier to maintain going forward. Some of these things will be added back over time, just leave an issue for the things that you need. The obvious first step is providing a compatibility pack which adds these features back in if they are heavily used!

### White.NUnit
This project doesn't fit, also we think you should fast fail your tests to speed up your feedback cycle. This is easy enough to implement in your own project if you need it!

### Custom Commands
White.Core.CustomCommands is a complex feature with a lot of code. And with the newer versions of .net and the maturing of many other open source projects, we can do this in MUCH nicer ways. 

If you use this feature, please let me know! I can put it in a compatibility pack or prioritise it.

### Custom Controls
Custom Controls is based on CustomCommands, so it also has gone. Once again, if you were using this, let me know your scenarios and we can prioritised putting it back in
