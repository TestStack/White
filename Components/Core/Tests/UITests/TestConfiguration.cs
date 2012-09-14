using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using White.Core.Factory;

namespace White.Core.UITests
{
    public abstract class TestConfiguration
    {
        public static string WPFTestAppLocation = @"WindowsPresentationFramework.exe";
        public static string WinFormsTestAppLocation = @"WinFormsTestApp.exe";

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
        private static readonly Dictionary<String, String> SWTJarFiles = new Dictionary<string, string>
                                                             {
                                                                 {"32bit", "org.eclipse.swt.win32.win32.x86_3.7.0.v3735b.jar"},
                                                                 {"64bit", "org.eclipse.swt.win32.win32.x86_64_3.7.0.v3735b.jar"}
                                                             };

        public SWTTestConfiguration(string commandLineArguments)
            : base(SWTAppFullPath(),
                    string.Format(@" -classpath SampleSWTApp\bin;""%classpath%"";SampleSWTApp\" + SWTJarFile() + @" -Djava.library.path=SampleSWTApp Program {0}", commandLineArguments)) { }

        private static string SWTJarFile()
        {
            string processorType = ConfigurationManager.AppSettings["ProcessorType"];
            string jarFile;
            if (!SWTJarFiles.TryGetValue(processorType, out jarFile))
                throw new ConfigurationErrorsException("ProcessorType property is not specified in AppSettings");
            return jarFile;
        }

        private static string SWTAppFullPath()
        {
            string javaLocation = ConfigurationManager.AppSettings["JavaLocation"];
            if (javaLocation == null) throw new ConfigurationErrorsException("JavaLocation key is not configured in appSettings");
            //check this location exists
            if (!Directory.Exists(javaLocation)) throw new ConfigurationErrorsException("JavaLocation does not point to a valid installation of JDK in appSettings!");
            //check it contains java.exe
            if (!File.Exists(javaLocation + "\\java.exe")) throw new ConfigurationErrorsException("JavaLocation contains a valid JDK folder, but can't find java.exe within the folder in appSettings!");
            return Path.Combine(javaLocation, SWTTestAppLocation);
        }

        protected override string WorkingDir
        {
            get { return @"..\..\..\Components\Core\Tests"; }
        }
    }
}
