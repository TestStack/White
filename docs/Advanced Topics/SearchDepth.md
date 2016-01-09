---
layout: layout
title: Controlling Search Depth
---

 - UI Automation provides two approach for querying the UIAutomation tree of an automation element.
 - Search on automation element tree: In this search the API user specifies the criteria and scope of the search. The scope is of two levels children or descendant. This is simpler API as the user doesn't need to match against every element.

Search during automation element tree navigation: In this search the user is provided with tree navigation calls which the she can use to search the elements among other things. This provides complete freedom to the user at the cost of simplicity of API.
White until release 0.19 used only the first approach. With 0.20 one can configure search based on tree navigation using the RawElementBasedSearch property in Configuration file. This property is used along with MaxElementSearchDepth property which indicates the depth of navigation, white should perform when using this mode. Hence, if you have a very deep tree but you hope to find your UI Items within 4 levels then you can set RawElementBasedSearch=true and MaxElementSearchDepth=4, and this would perform much better than when RawElementBasedSearch=false. Like most other configuration this can be set programmatically using CoreAppXmlConfiguration.Instance.

	CoreAppXmlConfiguration.Instance.RawElementBasedSearch = true;
	CoreAppXmlConfiguration.Instance.MaxElementSearchDepth = 2;
	var listView = window.Get<ListView>("listView");
	// or any of other execution in white would use search depth of 2
	CoreAppXmlConfiguration.Instance.RawElementBasedSearch = false; // white starts using regular search