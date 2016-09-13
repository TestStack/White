using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace TestStack.White.Mappings
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

        public virtual void AddWPFSecondary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WPFSecondary(testControlType, controlType));
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

        public virtual ControlDictionaryItem[] FindBy(ControlType controlType)
        {
            return this
                .Where(obj => controlType.Equals(obj.ControlType) && !obj.IsIdentifiedByClassName && !obj.IsIdentifiedByName)
                .ToArray();
        }

        public virtual ControlDictionaryItem[] FindBy(Type testControlType, string frameworkId)
        {
            var frameworkSpecificMatch = this
                .Where(c => testControlType.IsAssignableFrom(c.TestControlType) && Equals(c.FrameworkId, frameworkId))
                .ToArray();
            return frameworkSpecificMatch.Any()
                ? frameworkSpecificMatch
                : this
                    .Where(c => testControlType.IsAssignableFrom(c.TestControlType) && string.IsNullOrEmpty(c.FrameworkId))
                    .ToArray();
        }

        public virtual void AddFrameworkSpecificPrimary(ControlType controlType, Type win32Type, Type winformType, Type wpfType, Type silverlightType)
        {
            AddWin32Primary(win32Type, controlType);
            AddWinFormPrimary(winformType, controlType);
            AddWPFPrimary(wpfType, controlType);
            AddSilverlightPrimary(silverlightType, controlType);
        }
    }
}