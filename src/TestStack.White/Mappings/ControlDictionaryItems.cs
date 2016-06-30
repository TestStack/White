// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlDictionaryItems.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the ControlDictionaryItems type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    /// <summary>
    /// The control dictionary items.
    /// </summary>
    public sealed class ControlDictionaryItems : List<ControlDictionaryItem>
    {
        /// <summary>
        /// Add XAML primary.
        /// </summary>
        /// <param name="testControlType">
        /// The test control type.
        /// </param>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        public void AddXamlPrimary(Type testControlType, ControlType controlType)
        {
            this.Add(ControlDictionaryItem.XamlPrimary(testControlType, controlType));
        }

        public void AddWin32Primary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Win32Primary(testControlType, controlType));
        }

        public void AddWPFPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WPFPrimary(testControlType, controlType));
        }

        public void AddWPFSecondary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WPFSecondary(testControlType, controlType));
        }

        public void AddWinFormPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.WinFormPrimary(testControlType, controlType));
        }

        public void AddSilverlightPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.SilverlightPrimary(testControlType, controlType));
        }

        public void AddPrimary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Primary(testControlType, controlType));
        }

        public void AddSecondary(Type testControlType, ControlType controlType)
        {
            Add(ControlDictionaryItem.Secondary(testControlType, controlType));
        }

        public void AddPrimary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            Add(ControlDictionaryItem.Primary(testControlType, controlType, hasPrimaryChildren));
        }

        public void AddSecondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            Add(ControlDictionaryItem.Secondary(testControlType, controlType, hasPrimaryChildren));
        }

        public ControlDictionaryItem[] FindBy(ControlType controlType)
        {
            return this
                .Where(obj => controlType.Equals(obj.ControlType) && !obj.IsIdentifiedByClassName && !obj.IsIdentifiedByName)
                .ToArray();
        }

        public ControlDictionaryItem[] FindBy(Type testControlType, string frameworkId)
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

        /// <summary>
        /// Adds XAML specific primary.
        /// </summary>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        /// <param name="xamlType">
        /// The XAML type.
        /// </param>
        public void AddXamlSpecificPrimary(ControlType controlType, Type xamlType)
        {
            this.AddXamlPrimary(xamlType, controlType);
        }

        public void AddFrameworkSpecificPrimary(ControlType controlType, Type win32Type, Type winformType, Type wpfType, Type silverlightType)
        {
            AddWin32Primary(win32Type, controlType);
            AddWinFormPrimary(winformType, controlType);
            AddWPFPrimary(wpfType, controlType);
            AddSilverlightPrimary(silverlightType, controlType);
        }
    }
}