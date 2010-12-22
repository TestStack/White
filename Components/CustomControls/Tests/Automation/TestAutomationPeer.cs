using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace White.CustomControls.UnitTests.Automation
{
    public class TestAutomationPeer : AutomationPeer, IValueProvider
    {
        protected override List<AutomationPeer> GetChildrenCore()
        {
            throw new NotImplementedException();
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            throw new NotImplementedException();
        }

        protected override Rect GetBoundingRectangleCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsOffscreenCore()
        {
            throw new NotImplementedException();
        }

        protected override AutomationOrientation GetOrientationCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetItemTypeCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetClassNameCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetItemStatusCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsRequiredForFormCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsKeyboardFocusableCore()
        {
            throw new NotImplementedException();
        }

        protected override bool HasKeyboardFocusCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsEnabledCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsPasswordCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetAutomationIdCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetNameCore()
        {
            throw new NotImplementedException();
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsContentElementCore()
        {
            throw new NotImplementedException();
        }

        protected override bool IsControlElementCore()
        {
            throw new NotImplementedException();
        }

        protected override AutomationPeer GetLabeledByCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetHelpTextCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetAcceleratorKeyCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetAccessKeyCore()
        {
            throw new NotImplementedException();
        }

        protected override Point GetClickablePointCore()
        {
            throw new NotImplementedException();
        }

        protected override void SetFocusCore()
        {
            throw new NotImplementedException();
        }

        public void SetValue(string value)
        {
            throw new NotImplementedException();
        }

        public string Value
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
    }
}