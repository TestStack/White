---
layout: layout
title: Screen Objects in White
---

**This is significant addition to white. This should allow one to design the tests better and get rid of repeated initialization of UIItems in the tests. Brings the concept of convention over configuration to functional testing**

TestStack.White provides the engine for automating windows applications. Programs written using Core expresses intention of tests are UI Controls level. TestStack.White's API is tries to keep the intent of the program very clear. 

In case of complex applications (e.g. consisting of multiple windows) the automation programs for these become complex as well and it is quite likely that their intent is not very clear.

This is where TestStack.White.ScreenObjects comes in, it brings the well known `Page Object Pattern` to White and Rich Client testing. 

For a sample application at [https://github.com/TestStack/White/blob/master/src/Sample%20App/Wpf/WpfTodo.UITests/TodoAppTests.cs](https://github.com/TestStack/White/blob/master/src/Sample%20App/Wpf/WpfTodo.UITests/TodoAppTests.cs) which uses White's ScreenRepository

**NOTE:** Some of the API's may change over time, especially relating to reporting and Work Sessions

For more information on the Page Object Pattern, see [Page Object Pattern](/Guidance/PageObjectPattern.html) under the guidance section of our documentation.