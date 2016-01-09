---
layout: layout
title: UIA v3/COM Api
---
White will soon be running against the [UIA COM Wrapper](https://github.com/JakeGinnivan/UIAComWrapper) which means that White can support and will expose UI patterns for Virtualisation, and also add support for WinRT applications.

# Breaking Changes
Unfortunately, this will not be a perfectly clean upgrade. There are many small behavior differences, and some more fundamental changes.

For example, SWA would return a control type of `document` for a multi-line textbox in Windows forms, in the COM UIA Api the control type that is exposed is `edit`. But WPF will still have a control type of  This means that with the UIA Com wrapper, a multi-line textbox in WPF you would use the MultiLineTextBox control in White, but in WinForms you would just use TextBox.
There are a number of different controls which have changed slightly, and I will do my best to document changes below.

## Behavior changes
 - Combo-box items no longer are visible to UIA while closed

## Control changes
A few controls will change, for these changes, White will throw meaningful exceptions along the lines of

    The MultiLineTextBox control is no longer supported in Winforms due to a change in UIA 3.0, please use the TextBox or WinFormTextBox instead.

### Conversion list

Windows Forms:
 - MultiLineTextBox -> TextBox
 - ListView -> ListBox