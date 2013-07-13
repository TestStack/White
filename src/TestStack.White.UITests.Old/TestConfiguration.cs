using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TestStack.White.Factory;

namespace White.Core.UITests
{
    
    public class SWTTestConfiguration
    {
        private static readonly Dictionary<String, String> SWTJarFiles = new Dictionary<string, string>
                                                             {
                                                                 {"32bit", "org.eclipse.swt.win32.win32.x86_3.7.0.v3735b.jar"},
                                                                 {"64bit", "org.eclipse.swt.win32.win32.x86_64_3.7.0.v3735b.jar"}
                                                             };

        public SWTTestConfiguration(string commandLineArguments)
            //: base(SWTAppFullPath(),
            //        string.Format(@" -classpath SampleSWTApp\bin;""%classpath%"";SampleSWTApp\" + SWTJarFile() + @" -Djava.library.path=SampleSWTApp Program {0}", commandLineArguments)) 
        { }

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
            return javaLocation;//Path.Combine(javaLocation, SWTTestAppLocation);
        }

        protected string WorkingDir
        {
            get { return @"..\..\..\TestApplications"; }
        }
    }
}
