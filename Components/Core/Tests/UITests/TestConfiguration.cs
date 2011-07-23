using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using White.Core.Factory;

namespace White.Core.UITests
{
    public abstract class TestConfiguration
    {
        public static string WPFTestAppLocation = @"..\..\..\Components\Tests\WPFTestApp\bin\debug\WindowsPresentationFramework.exe";
        public static string WinFormsTestAppLocation = @"..\..\..\Components\Tests\WinFormsTestApp\bin\debug\WinFormsTestApp.exe";

        public static string SWTTestAppLocation = @"java.exe";

        private readonly string program;
        protected string commandLineArguments;
        private readonly InitializeOption windowInitializeOption;

        protected TestConfiguration(string program, string commandLineArguments)
        {
            this.program = program;
            this.commandLineArguments = commandLineArguments;
            windowInitializeOption = InitializeOption.NoCache;
        }

        public virtual Application Launch()
        {
            var processStartInfo = new ProcessStartInfo
                                       {
                                           WorkingDirectory = WorkingDir,
                                           FileName = program,
                                           Arguments = commandLineArguments.Trim(),
                                           UseShellExecute = false,
                                           CreateNoWindow = true,
                                           RedirectStandardOutput = true,
                                           RedirectStandardError = true
                                       };
            return Application.Launch(processStartInfo);
        }

        protected virtual string WorkingDir
        {
            get { return Environment.CurrentDirectory; }
        }

        public virtual InitializeOption WindowInitializeOption
        {
            get { return windowInitializeOption.AndIdentifiedBy("Form1"); }
        }
    }

    public class WPFTestConfiguration : TestConfiguration
    {
        public WPFTestConfiguration(string commandLineArguments) : base(WPFTestAppLocation, commandLineArguments) {}
    }

    public class WinFormTestConfiguration : TestConfiguration
    {
        public WinFormTestConfiguration(string commandLineArguments) : base(WinFormsTestAppLocation, commandLineArguments) {}
    }

    public class SWTTestConfiguration : TestConfiguration
    {
        public SWTTestConfiguration(string commandLineArguments)
            : base(
                SWTAppFullPath(),
                @" -classpath SampleSWTApp\bin;""%classpath%"";SampleSWTApp\org.eclipse.swt.win32.win32.x86_3.2.1.v3235.jar -Djava.library.path=SampleSWTApp Program " +
                commandLineArguments) {}

        private static string SWTAppFullPath()
        {
            string javaLocation = ConfigurationManager.AppSettings["JavaLocation"];
            if (javaLocation == null) throw new ConfigurationErrorsException("JavaLocation key is not configured in appSettings");
            return Path.Combine(javaLocation, SWTTestAppLocation);
        }

        protected override string WorkingDir
        {
            get { return @"..\..\..\TestApplications"; }
        }
    }
}
