---
layout: layout
title: Continuous Integration
---

White drives the mouse and keyboard for it's automation, and only falls back to the automation API's when it can't use the mouse/keyboard. This simulates real world behavior more than using automation directly.  
This means that White has to run on an UNLOCKED desktop.

Here is a list of my setup requirements when I create a UI test agent:
 
 - The build agent running as a Console agent (both TFS and TeamCity support this) and set it to automatically start on boot
 - Automatic logon setup (Use [SysInternals Autologon for Windows](http://technet.microsoft.com/en-us/sysinternals/bb963905.aspx) as it encrypts your password in the registry)
 - Screensaver disabled 
 - Disable Windows Error Reporting. View on Gist: [DisableWER.reg](https://gist.github.com/JakeGinnivan/5131363)  
 - VNC installed and connect via VNC, *not remote desktop*
   - When you connect using Remote desktop, then disconnect, the desktop will be locked, and UI Automation will fail
   - Personally I use [Tight VNC](http://www.tightvnc.com/) with the [DFMirage driver](http://www.tightvnc.com/download.php) 
 - I also put a shortcut (cmd) which restarts the PC on the desktop `shutdown -r -t 0`. Useful for when you connect via Remote Desktop, you can then reboot, and auto login will make sure your test agent is good to go when it comes back up!

Make sure that, while running these tests you would need to make sure that there aren't applications which would show windows while test is running. e.g. new chat message window coming up in restored or maximum mode. (I am not going into this here but there are ways to do this, like get the Yahoo Messenger new message window can be made to show as minimized).

You might have issues running it in CI, if the server runs as windows service. Allowing the service to "interact with the desktop" might help. (This can be set from the service properties log-on tab)

Please choose user version of windows instead of server versions. i.e. XP/Windows7 over Windows2003/Windows2008. The automation support for UIA is generally poor in server editions of windows.