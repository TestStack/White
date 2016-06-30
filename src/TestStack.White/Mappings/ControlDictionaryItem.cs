using System;
using System.Windows.Automation;
using TestStack.White.UIItems;

namespace TestStack.White.Mappings
{
    public sealed class ControlDictionaryItem
    {
        private readonly Type testControlType;
        private readonly ControlType controlType;
        private readonly string className;
        private readonly bool identifiedByClassName;
        private readonly bool isPrimary;
        private readonly bool isExcluded;
        private readonly string frameworkId;
        private readonly bool hasPrimaryChildren;

        public ControlDictionaryItem(Type testControlType, ControlType controlType, string className, bool identifiedByClassName, bool isPrimary,
                                     bool isExcluded, string frameworkId, bool hasPrimaryChildren)
        {
            this.testControlType = testControlType;
            this.controlType = controlType;
            this.className = className;
            this.identifiedByClassName = identifiedByClassName;
            this.isPrimary = isPrimary;
            this.isExcluded = isExcluded;
            this.frameworkId = frameworkId;
            this.hasPrimaryChildren = hasPrimaryChildren;
        }

        public static ControlDictionaryItem Primary(Type testControlType, ControlType controlType)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, null, false);
        }

        public static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, null, hasPrimaryChildren);
        }

        public static ControlDictionaryItem WinFormPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId());
        }

        public static ControlDictionaryItem WPFPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId());
        }

        public static ControlDictionaryItem Win32Primary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Win32.FrameworkId());
        }

        public static ControlDictionaryItem SilverlightPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Silverlight.FrameworkId());
        }

        /// <summary>
        /// The XAML primary.
        /// </summary>
        /// <param name="testControlType">
        /// The test control type.
        /// </param>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        /// <returns>
        /// The <see cref="ControlDictionaryItem"/>.
        /// </returns>
        public static ControlDictionaryItem XamlPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Xaml.FrameworkId());
        }

        public static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, null, false);
        }

        public static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, null, hasPrimaryChildren);
        }

        public static ControlDictionaryItem WinFormSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId());
        }

        public static ControlDictionaryItem Win32Secondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Win32.FrameworkId());
        }

        public static ControlDictionaryItem WPFSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId());
        }

        public static ControlDictionaryItem SilverlightSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Silverlight.FrameworkId());
        }

        /// <summary>
        /// The XAML secondary.
        /// </summary>
        /// <param name="testControlType">
        /// The test control type.
        /// </param>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        /// <returns>
        /// The <see cref="ControlDictionaryItem"/>.
        /// </returns>
        public static ControlDictionaryItem XamlSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Xaml.FrameworkId());
        }

        public bool IsPrimary => this.isPrimary;

        public Type TestControlType => this.testControlType;

        public string FrameworkId => this.frameworkId;

        public ControlType ControlType => this.controlType;

        public string ClassName => this.className;

        public bool IsExcluded => this.isExcluded;

        public bool IsIdentifiedByClassName => this.identifiedByClassName;

        public bool HasPrimaryChildren => this.hasPrimaryChildren;

        public bool OfFramework(string id)
        {
            //TODO id.Equals(id) will always return true.. figure out what this is doing
            return string.IsNullOrEmpty(id) || id.Equals(id);
        }

        public bool IsIdentifiedByName { set; get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return 
                $"TestControlType: {this.testControlType.Name}, ControlType: {this.controlType.LocalizedControlType}, ClassName: {this.className}, IdentifiedByClassName: {this.identifiedByClassName}, IsPrimary: {this.isPrimary}, IsExcluded: {this.isExcluded}, FrameworkId: {this.frameworkId}, HasPrimaryChildren: {this.hasPrimaryChildren}, IsIdentifiedByName: {this.IsIdentifiedByName}";
        }

        /// <summary>
        /// The primary.
        /// </summary>
        /// <param name="testControlType">
        /// The test control type.
        /// </param>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        /// <param name="frameworkId">
        /// The framework id.
        /// </param>
        /// <returns>
        /// The <see cref="ControlDictionaryItem"/>.
        /// </returns>
        private static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, frameworkId, false);
        }

        /// <summary>
        /// The secondary.
        /// </summary>
        /// <param name="testControlType">
        /// The test control type.
        /// </param>
        /// <param name="controlType">
        /// The control type.
        /// </param>
        /// <param name="frameworkId">
        /// The framework id.
        /// </param>
        /// <returns>
        /// The <see cref="ControlDictionaryItem"/>.
        /// </returns>
        private static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, frameworkId, false);
        }
    }
}