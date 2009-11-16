using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace White.NUnit
{
    //BUG MSTest alternative for Verify
    /// <summary>
    /// Allows you to perform verifications in your tests. This does the same thing as the corresponding Assert methods in NUnit do, only difference being 
    /// it doesn't stop the test at that point. Since functional tests are long running tests, hence one would want to know about all the failures in the 
    /// in one go. One should still use NUnit Assert directly in situations where there is no point in proceeding with the test.
    /// </summary>
    public class Verify
    {
        private static bool failed;
        private static readonly List<string> failures = new List<string>();

        public delegate void AssertDelegate(params object[] objs);

        public static void AreEqual(object expected, object actual)
        {
            AreEqual(expected, actual, string.Empty);
        }

        public static void AreEqual(object expected, object actual, string message)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        /// <summary>
        /// Verifies that two lists have the same elements
        /// </summary>
        public static void AreEqual<T>(IList<T> expected, IList<T> actual)
        {
            try
            {
                Assert.AreEqual(expected.Count, actual.Count, "Number of items in expected and actual lists were different");
                foreach (T t in actual)
                    Assert.Contains(t, expected as IList, t + "- was not found in expected list");
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        /// <summary>
        /// Verifies that two objects are not equal and prints message if they are not equal
        /// </summary>
        public static void AreNotEqual(object expected, object actual, string message)
        {
            try
            {
                Assert.AreNotEqual(expected, actual, message);
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        /// <summary>
        /// Verifies that two objects are not equal
        /// </summary>
        public static void AreNotEqual(object obj1, object obj2)
        {
            AreNotEqual(obj1, obj2, string.Empty);
        }


        /// <summary>
        /// Verifies that a condition is true and prints the message if it is false
        /// </summary>
        public static void IsTrue(bool b, string message)
        {
            try
            {
                Assert.IsTrue(b, message);
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        public static void IsTrue(bool b)
        {
            IsTrue(b, string.Empty);
        }

        /// <summary>
        /// Verifies that a condition is false and prints the message if it is true
        /// </summary>
        public static void IsFalse(bool b, string message)
        {
            try
            {
                Assert.IsFalse(b, message);
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        public static void IsFalse(bool b)
        {
            IsFalse(b, string.Empty);
        }

        /// <summary>
        /// This should be called at the end of every test so that the failures of one test should not appear as failure on other tests.
        /// </summary>
        public static void CleanUp()
        {
            failures.Clear();
            failed = false;
        }

        private static void HandleAssertionException(AssertionException ae)
        {
            var stackTrace = new StackTrace(true);
            var stringBuilder = new StringBuilder();

            try
            {
                stringBuilder.AppendLine(ae.Message);
                string myOwnCodeFileName = stackTrace.GetFrame(0).GetFileName();
                foreach (StackFrame stackFrame in stackTrace.GetFrames())
                {
                    if ((0 != stackFrame.GetFileLineNumber()) && !myOwnCodeFileName.Equals(stackFrame.GetFileName()))
                    {
                        MethodBase method = stackFrame.GetMethod();
                        stringBuilder.AppendLine("at " + method.DeclaringType.FullName + method.Name + @"(...) in " + new FileInfo(stackFrame.GetFileName()).Name + ":line " + stackFrame.GetFileLineNumber());
                    }
                }
                failures.Add(stringBuilder.ToString());
            }
            catch {
            }
            failed = true;
        }

        /// <summary>
        /// Check whether the test failed or succeeded. This would get reset to false when CleanUp is called.
        /// </summary>
        public static bool TestFailed
        {
            get { return failed; }
        }
        
        /// <summary>
        /// Get the stacktrace of all the failures. The StackTrace can be printed out using System.Console.WriteLine.
        /// </summary>
        public static List<string> Failures
        {
            get { return failures; }
        }

        public static void AssertResults()
        {
            if (failed)
            {
                StringBuilder builder = new StringBuilder();
                failures.ForEach(delegate(string obj) { builder.Append(obj); });
                Assert.Fail(builder.ToString());
            }
        }

        public static void Fail()
        {
            Fail(string.Empty);
        }

        public static void Fail(string message)
        {
            try
            {
                Assert.Fail(message);
            }
            catch (AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }

        /// <summary>
        /// Executes user provided method but does not stop the test if the Assertion fails
        /// </summary>
        public static void Perform(AssertDelegate assertDelegate, params object[] @objects)
        {
            try
            {
                assertDelegate(objects);
            }
            catch(AssertionException ae)
            {
                HandleAssertionException(ae);
            }
        }
    }
}
