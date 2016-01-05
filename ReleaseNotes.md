# 0.14.0 (TBD)

### Features
- Migration to nUnit - [#348](https://github.com/TestStack/White/pull/348)
- Being able to capture part of the screen - [#350](https://github.com/TestStack/White/pull/350), [#260](https://github.com/TestStack/White/pull/260) (Slightly modified version of ([HEskandari](https://github.com/HEskandari))
- Added color parameter to DrawHighlight
- Added some localization for German UI
- PDB files source indexing [#359]

### Bug Fixes
None so far

### Breaking Changes
None so far

# 0.13.0 (7 June 2014)

 - [#188](https://github.com/TestStack/White/pull/188) - Issue144: Add DrawHighlight method to UIItem contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#242](https://github.com/TestStack/White/pull/242) - White unable to extract DataItems (ListViewRow) contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#238](https://github.com/TestStack/White/pull/238) - added nuget logo and updated nuspecs to point to it contributed by Jason Roberts ([jason-roberts](https://github.com/jason-roberts))
 - [#236](https://github.com/TestStack/White/pull/236) - Bugfix: Allow support for screen types with extremely long full type names contributed by Eric Winkler ([eric-winkler](https://github.com/eric-winkler))
 - [#235](https://github.com/TestStack/White/pull/235) - Bugfix: Allow support for screen types with extremely long full type names contributed by Eric Winkler ([eric-winkler](https://github.com/eric-winkler))
 - [#221](https://github.com/TestStack/White/pull/221) - Window.ModalWindows() is finding zero windows but Window.Modalwindow(title) finds it contributed by Jake Ginnivan ([JakeGinnivan](https://github.com/JakeGinnivan))
 - [#217](https://github.com/TestStack/White/pull/217) - Added ComboBox to DataGrid in WpfTestApplication contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#215](https://github.com/TestStack/White/pull/215) - Clear date test contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#214](https://github.com/TestStack/White/pull/214) - Fix 212: ListViewRow can't be created with DictionaryMappedItemFactory contributed by ([ivan-danilov](https://github.com/ivan-danilov))
 - [#211](https://github.com/TestStack/White/pull/211) - Update README.md to show new home of UIA Verify contributed by Steve Hill ([sghill](https://github.com/sghill))
 - [#210](https://github.com/TestStack/White/issues/210) - Include generated xml documentation in NuGet package
 - [#200](https://github.com/TestStack/White/issues/200) - Test Execution for WPF application is very slow (VS 2012 + Win 8.1). 

Commits: acbe226d60...03e879b851


# 0.12.0 (21 January 2014)

 - [#206](https://github.com/TestStack/White/pull/206) - Net35 Support added back contributed by Jake Ginnivan ([JakeGinnivan](https://github.com/JakeGinnivan))
 - [#204](https://github.com/TestStack/White/pull/204) - * fixed memory leaks in VisibleImage contributed by ([lostmsu](https://github.com/lostmsu))
 - [#196](https://github.com/TestStack/White/pull/196) - Issue168 fixed. contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#194](https://github.com/TestStack/White/pull/194) - Issue105 fix. Removed ClearDate from DateTimePicker. contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#193](https://github.com/TestStack/White/pull/193) - ArgumentNullException when trying to clear date in WPF DatePicker contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#191](https://github.com/TestStack/White/pull/191) - Issue155 fixed. contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#190](https://github.com/TestStack/White/issues/190) - Selected Item of combobox enable = "false"
 - [#189](https://github.com/TestStack/White/pull/189) - Issue183: Add Exists<>() method. contributed by Ilya Murzinov ([ilya-murzinov](https://github.com/ilya-murzinov))
 - [#184](https://github.com/TestStack/White/pull/184) - Close all windows on Application close, not just main one contributed by ([ivan-danilov](https://github.com/ivan-danilov))
 - [#182](https://github.com/TestStack/White/pull/182) - Fix: problem with cursors that are not the same on my OS as hardcoded in the MouseCursor class contributed by ([ivan-danilov](https://github.com/ivan-danilov))
 - [#175](https://github.com/TestStack/White/pull/175) - Added checkbox as possible control in a data grid cell contributed by ([SebastianMax](https://github.com/SebastianMax))
 - [#173](https://github.com/TestStack/White/pull/173) - Fixed typo in readme, the samples link was wrong. contributed by Roberto Luis Bisbe ([rlbisbe](https://github.com/rlbisbe))
 - [#170](https://github.com/TestStack/White/pull/170) - Added Application main window activation after process startup. contributed by ([ivan-danilov](https://github.com/ivan-danilov))
 - [#169](https://github.com/TestStack/White/issues/169) - Exception when expanding tree node
 - [#168](https://github.com/TestStack/White/issues/168) - After trying select value in a Combobox that have already selected, Combobox remains expanded.
 - [#166](https://github.com/TestStack/White/issues/166) - Comobox.Select(string item) and Combox.Select(int index) not working properly
 - [#160](https://github.com/TestStack/White/issues/160) - Accessing menus in child windows 
 - [#158](https://github.com/TestStack/White/issues/158) - TestStack.White.WebBrowser NuGet package not published
 - [#157](https://github.com/TestStack/White/pull/157) - renamed Sample App folder to Samples too to avoid confusion contributed by Mehdi Khalili ([MehdiK](https://github.com/MehdiK))
 - [#156](https://github.com/TestStack/White/pull/156) - Minor changes on Samples contributed by Mehdi Khalili ([MehdiK](https://github.com/MehdiK))
 - [#146](https://github.com/TestStack/White/issues/146) - White is very slow to get elements in window
 - [#143](https://github.com/TestStack/White/pull/143) - Added IUIItem.GetParent<T>() extension method contributed by ([ivan-danilov](https://github.com/ivan-danilov))
 - [#139](https://github.com/TestStack/White/issues/139) - API to access parent of the UIItem found via Get methods

Commits: 15da64db31...be6ad894f0


# 0.11.0.207 (01 August 2013)

 - First release of TestStack.White

Commits: 3dcf106156...78356dfa62
