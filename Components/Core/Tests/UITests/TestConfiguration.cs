using System;
using System.Diagnostics;
using White.Core.Factory;

namespace White.Core.UITests
{
    public abstract class TestConfiguration
    {
        public static string WPFTestAppLocation = @"..\..\..\WPFTestApp\bin\debug\WindowsPresentationFramework.exe";
        public static string WinFormsTestAppLocation = @"..\..\..\WinFormsTestApp\bin\debug\WinFormsTestApp.exe";

        public static string SWTTestAppLocation = @"java";

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
                                           CreateNoWindow = true
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
                SWTTestAppLocation,
                @" -classpath SampleSWTApp\bin;""%classpath%"";SampleSWTApp\org.eclipse.swt.win32.win32.x86_3.2.1.v3235.jar -Djava.library.path=SampleSWTApp Program " +
                commandLineArguments) {}

        protected override string WorkingDir
        {
            get { return @"..\..\..\TestApplications"; }
        }
    }
}
