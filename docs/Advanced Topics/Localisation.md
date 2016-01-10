White uses text internally to find UIItems. These string differ based on locale. e.g. in Table(DataGrid) the header, row header etc, or scroll bars, are identified by some names given to them. These don't work in locales which are not english based. While doesn't provide all the locale values but allows you to configure these text.
In the app.config define sections as:

	<sectionGroup name="White">
	      ....
	      <section name="UIItemId" type="System.Configuration.NameValueSectionHandler"/>
	</sectionGroup>
	  <White>
	...
	    <UIItemId>
	      <add key="TableVerticalScrollBar" value="Vertical Scroll Bar"/>
	    </UIItemId>
	  </White>

Like other configuration these can be set programmatically as well.

	UIItemIdAppXmlConfiguration.Instance. TableVerticalScrollBar = "Vertical Scroll Bar";

Configurable values are:

	TableVerticalScrollBar=Vertical Scroll Bar
	TableHorizontalScrollBar=Horizontal Scroll Bar
	TableColumn=Row 
	TableTopLeftHeaderCell=Top Left Header Cell
	TableCellNullValue=(null)
	TableHeader=Top Row
	HorizontalScrollBar=Horizontal ScrollBar
	VerticalScrollBar=Vertical ScrollBar