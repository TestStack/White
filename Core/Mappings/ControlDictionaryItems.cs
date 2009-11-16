using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace White.Core.Mappings
{
    public class ControlDictionaryItems : List<ControlDictionaryItem>
    {
        public virtual void AddWin32Primary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Win32Primary(testControlType, controlType));
        }

        public virtual void AddWPFPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WPFPrimary(testControlType, controlType));
        }

        public virtual void AddWinFormPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WinFormPrimary(testControlType, controlType));
        }

        public virtual void AddSilverlightPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.SilverlightPrimary(testControlType, controlType));
        }

        public virtual void AddPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Primary(testControlType, controlType));
        }

        public virtual void AddSecondary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Secondary(testControlType, controlType));
        }

        public virtual void AddPrimary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            Add(ControlDictionaryItem.Primary(testControlType, controlType, hasPrimaryChildren));
        }

        public virtual void AddSecondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            Add(ControlDictionaryItem.Secondary(testControlType, controlType, hasPrimaryChildren));
        }

        public virtual ControlDictionaryItem FindBy(ControlType controlType)
        {
            return Find(obj => controlType.Equals(obj.ControlType) && !obj.IsIdentifiedByClassName && !obj.IsIdentifiedByName);
        }

        public virtual ControlDictionaryItem FindBy(Type testControlType, string frameworkId)
        {
            return Find(controlDictionaryItem => testControlType.IsAssignableFrom(controlDictionaryItem.TestControlType) && (frameworkId == null || Equals(controlDictionaryItem.FrameworkId, frameworkId)));
        }
    }
}