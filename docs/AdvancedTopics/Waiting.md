White strives to eliminate any need whatsoever for doing Thread.Sleep and retry in your test programs. So if you find yourself doing these things in your program, please use any one applicable options below. If you don't find it, please raise an issue.

1. When any action is performed white automatically waits till the window can respond again to next action. One of the thing white does during this is to call windowPattern.WaitForInputIdle on the parent window of the UI item on which the action is performed. In cases where the window would be closed as a result of the action performed, this call would throw exception internally, depending on timing of the call. The caller doesn't have to worry about this as this exception is trapped.
All of this happens by default, without having to configure anything.

2. Wait based on presence of hour glass. This can be configured by using WaitBasedOnHourGlass property (default value true). This ensures that the test would wait till the cursor remains in hour-glass or default-and-hour-glass. When configured it would happen for each and every action. It is very common in applications to not use hour glass to provide feedback to the user when the application is busy. It is highly recommended to do this, as WaitWhileBusy call on the process object in .NET is not reliable at all.

3. There are cases where the above two strategy aren’t enough and hence white provides its own wait mechanism. In this test program waits until the certain condition matches. As soon as the condition matches it would return. There is maximum wait duration. This duration can be configured by setting BusyTimeout property.

There are other places where you need to set the timeout (all in milli seconds set to some defaults).

    Property                            Description  
    PopupTimeout                        Timeout period for finding a popup  
    TooltipWaitTime                     Maximum duration in within which tooltip would appear (see Tool tip problem)  
    SuggestionListTimeout               Timeout period for finding a suggestion list on a textbox  
    UIAutomationZeroWindowBugTimeout    Timeout till any window is found for an application. There is a bug in UIAutomation because of which it sometimes doesn’t find windows for a process  

For configuring above have a look at the Configuration section
Timeout means the upper time limit of search. White keeps trying till this time, after every 100 ms.
Custom wait hook

In addition to wait provided by default by white, as mentioned above. From release 0.20 onwards you can also hook in custom wait mechanism. This hook gets called every time after the above wait checks are performed. In this hook you can wait for your conditions to finish. This is useful if your wait scenarios are quite pervasive and you have put in this check at lot of places in your test.

Steps to hook you custom wait:  
Implement the interface White.Core.Configuration.IWaitHook.  
Implement the WaitFor method in it to wait for as long as your test requires. White passed in the UIItemContainer (most of the time this is just the window) object to provide the context of call. e.g. you can wait till you can find a UI Item in this container.
Set the wait hook by setting CoreAppXmlConfiguration.Instance.AdditionalWaitHook value

A note on the custom wait hook:

For the hook to work CoreAppXmlConfiguration.Instance.AdditionalWaitHook has to be set to the object implementing the IWaitHook interface, e.g:

	public class CustomWait : IWaitHook
	{
		public CustomWait()
		{
			CoreAppXmlConfiguration.Instance.AdditionalWaitHook = this;
		}
		
		// Implementation of the IWaitHook interface
		public void WaitFor(UIItemContainer uiItemContainer)
		{
			...
		}
	}

**Note:** IWaitHook is quite heavy handed, it checks after every action (which for a single logical action, there may be multiple internal actions). This can make it rather slow. See the next section for some other techniques

## Handling asynchronous/background work (WPF)
I tend to use the UI automation HelpText to tell White that my application is busy, this approach is not supported by White out of the box, so you will have to put it in yourself. These code samples are for WPF, but the technique can be used in other UI Frameworks

First, you want to create an attached property:

    public static class BusyAutomationBehaviour
    {
        public static readonly DependencyProperty IsApplicationBusyProperty =
            DependencyProperty.RegisterAttached("IsApplicationBusy", typeof (bool), typeof (BusyAutomationBehaviour), new PropertyMetadata(OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutomationProperties.SetHelpText(d, GetIsApplicationBusy(d) ? "Busy" : string.Empty);           
        }

        public static void SetIsApplicationBusy(DependencyObject element, bool value)
        {
            element.SetValue(IsApplicationBusyProperty, value);
        }

        public static bool GetIsApplicationBusy(DependencyObject element)
        {
            return (bool) element.GetValue(IsApplicationBusyProperty);
        }
    }

You can attach this on your main Window, then bind it to a property which is true when your application is busy. Now this requires your application to know when it is busy, so I hope you have made this a cross cutting concern in your app.

    <Window ........
            wpfTodo:BusyAutomationBehaviour.IsApplicationBusy="{Binding LoadingTasks}">

Then in your [Screen](wiki\ScreenPattern) you can have a `WaitWhileBusy` helper.

        public void WaitWhileBusy()
        {
            Retry.For(ShellIsBusy, isBusy => isBusy, TimeSpan.FromSeconds(30));
        }

        bool ShellIsBusy()
        {
            var currentPropertyValue = WhiteWindow.AutomationElement.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
            return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
        }

I hope to expand this article later.