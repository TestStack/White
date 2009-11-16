using System;
using System.Collections.Generic;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace White.WPFCustomControls
{
    public class WhiteChartAutomationPeer : FrameworkElementAutomationPeer, IGridProvider
    {
        private readonly WhiteChart whiteChart;

        public WhiteChartAutomationPeer(WhiteChart whiteChart) : base(whiteChart)
        {
            this.whiteChart = whiteChart;
        }

        protected override List<AutomationPeer> GetChildrenCore()
        {
            return new List<AutomationPeer>();
        }

        public IRawElementProviderSimple GetItem(int row, int column)
        {
            return new WhiteChartItem();
        }

        public int RowCount
        {
            get { return whiteChart.Series.Count; }
        }

        public int ColumnCount
        {
            get { return whiteChart.Series[0].DataPoints.Count; }
        }
    }

    public class WhiteChartItem : IRawElementProviderSimple
    {
        public object GetPatternProvider(int patternId)
        {
            throw new NotImplementedException();
        }

        public object GetPropertyValue(int propertyId)
        {
//            AutomationProperties.NameProperty
            throw new NotImplementedException();
        }

        public ProviderOptions ProviderOptions
        {
            get { return ProviderOptions.ServerSideProvider; }
        }

        public IRawElementProviderSimple HostRawElementProvider
        {
            get { return this; }
        }
    }
}