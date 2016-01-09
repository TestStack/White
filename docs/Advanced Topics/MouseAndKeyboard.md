---
layout: layout
title: Mouse and Keyboard
---

## Using keyboard/mouse directly
Ideally you don't need to use these directly but if you do want to use. If you do want to use it then please use window.Keyboard and window.Mouse instead on instantiating a new window. The different between these two is that the use of Keyboard.Instance gives you raw keyboard and any operation performed on it would not wait till the window is busy. You can call window.WaitForInputIdle as well.

Moving the mouse to a particular location
	var point = new Point(100, 100);
	mouse.Location = point;

Moving the mouse to a particular UI Item
	mouse.Location = uiItem.Bounds.Center(); //Please see the class RectX to see options of different locations to which a mouse can be moved.

Sometimes you do not want to use mouse to be used for click and directly use the pattern provided by the UI Automation framework. You can use RaiseClickEvent event method on any UI Item as long as it supports InvokePattern. If it doesn't support the pattern then this would result in no-op.