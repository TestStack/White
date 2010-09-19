using System;
using System.Collections.Generic;
using System.Configuration;
using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace White.Core.UITests.Testing
{
    public class TestMode
    {
        private ApplicationClass applicationClass = ApplicationClass.None;
        public static ApplicationClass DefaultAppClass =
            (ApplicationClass) Enum.Parse(typeof (ApplicationClass), ConfigurationManager.AppSettings["TestMode"]);
        private static readonly Dictionary<string, ApplicationClass> categories = new Dictionary<string, ApplicationClass>();

        static TestMode()
        {
            categories.Add(Constants.WinFormFrameworkId, ApplicationClass.WinForm);
            categories.Add(Constants.WPFFrameworkId, ApplicationClass.WPF);
            categories.Add(Constants.SWT, ApplicationClass.SWT);
        }

        public TestMode(ApplicationClass applicationClass)
        {
            this.applicationClass = applicationClass;
        }

        private TestMode() {}

        public virtual TestConfiguration GetConfiguration(string commandLine, object testObject)
        {
            ApplicationClass applicationClassInUse = ClassFor(testObject);
            if (ApplicationClass.WinForm.Equals(applicationClassInUse))
                return new WinFormTestConfiguration(commandLine);
            if (ApplicationClass.WPF.Equals(applicationClassInUse))
                return new WPFTestConfiguration(commandLine);
            if (ApplicationClass.SWT.Equals(applicationClassInUse))
                return new SWTTestConfiguration(commandLine);
            throw new IllegalTestException(GetType().FullName + " is not a valid test, because it is not marked as WinFormsTest or WPFTest attribute on it");
        }

        public static TestMode Create(string commandLineArguments)
        {
            var testMode = new TestMode();
            bool containsExternalMode = commandLineArguments.Contains("/exclude");
            if (containsExternalMode)
            {
                var modes = new List<string> {Constants.WPFFrameworkId, Constants.WinFormFrameworkId, Constants.SWT};
                string[] strings = commandLineArguments.Split(new[] {"/exclude:"}, StringSplitOptions.None);
                strings = strings[1].Split(',', '\"', ' ');
                foreach (string exclude in strings)
                    modes.Remove(exclude);
                testMode.applicationClass = (ApplicationClass) Enum.Parse(typeof (ApplicationClass), modes[0]);
            }
            return testMode;
        }

        public virtual ApplicationClass ClassFor(object test)
        {
            var @class = new Class(test.GetType());
            if (@class.HasAttribute(typeof (CategoryAttribute)))
            {
                List<CategoryAttribute> categoryAttributes = @class.Attributes<CategoryAttribute>();
                if (ContainsName(categoryAttributes, DefaultAppClass))
                    return DefaultAppClass;
                string category = categoryAttributes[0].Name;
                if (categories.ContainsKey(category)) return categories[category];
            }
            return applicationClass.Equals(ApplicationClass.None) ? DefaultAppClass : applicationClass;
        }

        private static bool ContainsName(List<CategoryAttribute> categoryAttributes, ApplicationClass defaultAppClass)
        {
            foreach (CategoryAttribute categoryAttribute in categoryAttributes)
                if (categoryAttribute.Name.Equals(defaultAppClass.ToString())) return true;
            return false;
        }

        public bool Equals(TestMode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.applicationClass, applicationClass);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TestMode)) return false;
            return Equals((TestMode) obj);
        }

        public override int GetHashCode()
        {
            return applicationClass.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ApplicationClass: {0}", applicationClass);
        }
    }
}
