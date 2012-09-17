# TestStack.ProjectWhite
Project white has been inactive for some time, but still has many users and is a great UI automation framework.

TestStack has brought this project into it's offering to try and breathe some life into Project White.

White will become a *rich client* UI automation framework, which makes it really easy to create maintainable and reliable UI automation tests. 

## The Plan
### NuGet
First priority is to get Project White up on NuGet

### Documentation
Get some guidance and documentation around many of the concepts in Project White, this will all end up in our GitHub wiki

### Cleanup
We will be removing Bricks, and quite a few of the projects that are in white. We want to make it a lean and mean automation framework which helps you build **reliable, fast and easy to maintain UI automation tests!!**

### DotNet 4.0 Upgrade
Project White will be upgraded to .net 4.0 so we can take advantage of some new language features and UIA improvements.

## Legacy Features/Projects
We will be removing some projects in an effort to make White easier to maintain going forward. Some of these things will be added back over time, just leave an issue for the things that you need. The obvious first step is providing a compatibility pack which adds these features back in if they are heavily used!

### White.NUnit
This project doesn't fit, also we think you should fast fail your tests to speed up your feedback cycle. This is easy enough to implement in your own project if you need it!

### Custom Commands
White.Core.CustomCommands is a complex feature with a lot of code. And with the newer versions of .net and the maturing of many other open source projects, we can do this in MUCH nicer ways. 

If you use this feature, please let me know! I can put it in a compatibility pack or prioritise it.