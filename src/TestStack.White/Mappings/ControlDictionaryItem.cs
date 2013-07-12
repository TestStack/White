using System;
using System.Windows.Automation;

namespace TestStack.White.Mappings
{
    public class ControlDictionaryItem
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

        private static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, frameworkId, false);
        }

        public static ControlDictionaryItem WinFormPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, Constants.WinFormFrameworkId);
        }

        public static ControlDictionaryItem WPFPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, Constants.WPFFrameworkId);
        }

        public static ControlDictionaryItem Win32Primary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, Constants.Win32FrameworkId);
        }

        public static ControlDictionaryItem SilverlightPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, Constants.SilverlightFrameworkId);
        }

        private static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, frameworkId, false);
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
            return Secondary(testControlType, controlType, Constants.WinFormFrameworkId);
        }

        public static ControlDictionaryItem Win32Secondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, Constants.Win32FrameworkId);
        }

        public static ControlDictionaryItem WPFSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, Constants.WPFFrameworkId);
        }

        public static ControlDictionaryItem SilverlightSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, Constants.SilverlightFrameworkId);
        }

        public virtual bool IsPrimary
        {
            get { return isPrimary; }
        }

        public virtual Type TestControlType
        {
            get { return testControlType; }
        }

        public virtual string FrameworkId
        {
            get { return frameworkId; }
        }

        public virtual ControlType ControlType
        {
            get { return controlType; }
        }

        public virtual string ClassName
        {
            get { return className; }
        }

        public virtual bool IsExcluded
        {
            get { return isExcluded; }
        }

        public virtual bool IsIdentifiedByClassName
        {
            get { return identifiedByClassName; }
        }

        public virtual bool HasPrimaryChildren
        {
            get { return hasPrimaryChildren; }
        }

        public virtual bool OfFramework(string id)
        {
            //TODO id.Equals(id) will always return true.. figure out what this is doing
            return string.IsNullOrEmpty(id) || id.Equals(id);
        }

        public virtual bool IsIdentifiedByName { set; get; }

        public override string ToString()
        {
            return
                string.Format(
                    "TestControlType: {0}, ControlType: {1}, ClassName: {2}, IdentifiedByClassName: {3}, IsPrimary: {4}, IsExcluded: {5}, FrameworkId: {6}, HasPrimaryChildren: {7}, IsIdentifiedByName: {8}",
                    testControlType.Name, controlType.LocalizedControlType, className, identifiedByClassName, isPrimary, isExcluded, frameworkId, hasPrimaryChildren,
                    IsIdentifiedByName);
        }
    }
}