### Speed up performance by Position based search

Performance of finding UIItems (based on search criteria) is proportional to the number of items on a window. A UIItem is found by enumerating over all the controls in a window (at windows messages level, everything is a window, try spy++ to understand this better). Smaller the scope of faster would be search. Position based search is based on this idea.

When finding a window from an application or another window you need to specify the identification of the window. This identification has to be unique as this is the identification for the cache. This cache is stored in the xml file. Duplicate identification would not cause any failures but you would not get benefit of position based search in such cases. This is how to do this.

	Window window = application.GetWindow("Customer - Foo", InitializeOption.NoCache.AndIdentifiedBy("Customer"));

The identification is tied to the type of window and not instance of window. So even if I was doing this somewhere else in the code where my customer name is "Bar" I would do this.

	Window window = application.GetWindow("Customer - Bar", InitializeOption.NoCache.AndIdentifiedBy("Customer"));

Similarly for modal windows same applies:

	Window modalWindow = window.ModalWindow("Address - Home", InitializeOption.NoCache.AndIdentifiedBy("Address"));

You also need to do

	application.ApplicationSession.Save();

at the end of the test (or after killing the application).

White remembers the position of UIItems on a window when you run your program for the first time and stores it on the file system as an xml file (see Configuration for setting the directory). In the next run it finds the UIItems based on the position of UIItem which is very fast because there is only one item at the point. If the item is not found at the position it would perform the normal search.
The position which is saved in xml file is relative to the window, hence change in position of window doesn’t affect position based find. Changes in layout of items in a window are taken care of by overwriting the position when it changes. You need to delete these files when you switch to new version of white. After first run they would be cached again.