using System;
using System.Windows.Forms;
using Bricks;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.WindowItems;
using Lunar.Client.View.CommonControls;
using Recorder.Domain;
using Repository;
using Application=White.Core.Application;

namespace Recorder.View
{
    public partial class WindowBrowser : UserControl
    {
        public delegate void OnWindowChange(Window lastWindow, Window newWindow);
        public virtual event OnWindowChange WindowChanged = delegate {};

        private Window selectedWindow;
        private Tab selectedTab;

        public WindowBrowser()
        {
            InitializeComponent();
            AddTooltips();
            HookEvents();
        }

        public virtual Window CurrentWindow
        {
            get { return (Window)windows.SelectedItem; }
        }

        private void AddTooltips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(applications, "Displays a list process names, of all application on your desktop which have atleast one visible window.");
            toolTip.SetToolTip(windows, "Diplays the list of all windows for the selected application.");
            toolTip.SetToolTip(windowTabs, "Displays the list all the tabs available in the selected window.");
            toolTip.SetToolTip(tabPages, "List of tab pages in the selected tab. ");
        }

        private void HookEvents()
        {
            windows.SelectedIndexChanged += SelectedWindowChanged;
            applications.SelectedIndexChanged += SelectedApplicationChanged;
            windowTabs.SelectedIndexChanged += SelectedTabChanged;
            applications.DoubleClick += SelectedApplicationChanged;
        }

        private void SelectedTabChanged(object sender, EventArgs e)
        {
            selectedTab = (Tab) windowTabs.SelectedItem;
            tabPages.DataSource = selectedTab.Pages;
        }

        private void SelectedWindowChanged(object sender, EventArgs e)
        {
            if (selectedWindow != null) WindowChanged(selectedWindow, CurrentWindow);
            selectedWindow = CurrentWindow;
            windowTabs.DataSource = selectedWindow.Tabs;
        }

        public virtual void BindData(Applications applicationsWithWindow)
        {
            applications.DataSource = applicationsWithWindow;
            applications.DisplayMember = CodePath.Get(CodePath.New<Application>().Name);

            windows.DisplayMember = CodePath.Get(CodePath.New<DummyWindow>().Title);
            windowTabs.DisplayMember = CodePath.Get(CodePath.New<Tab>().PrimaryIdentification);
        }

        private void SelectedApplicationChanged(object sender, EventArgs e)
        {
            using (CursorManager.WaitCursor(applications)) windows.DataSource = ((Application)(applications.SelectedItem)).GetWindows();
        }
    }
}
