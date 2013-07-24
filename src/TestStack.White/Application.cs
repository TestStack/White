using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White
{
    /// <summary>
    /// Represents a process which contains windows.
    /// </summary>
    public class Application : IDisposable
    {
        private readonly Process process;
        private readonly ApplicationSession applicationSession;
        private readonly WindowFactory windowFactory;
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(Application));

        protected Application()
        {
        }

        private Application(Process process)
        {
            this.process = process;
            applicationSession = new ApplicationSession();
            applicationSession.Register(this);
            windowFactory = WindowFactory.Desktop;
        }

        /// <summary>
        /// Runs the process identified by the executable and creates Application object for this executable
        /// </summary>
        /// <param name="executable">location of the executable</param>
        /// <returns></returns>
        public static Application Launch(string executable)
        {
            var processStartInfo = new ProcessStartInfo(executable);
            return Launch(processStartInfo);
        }

        /// <summary>
        /// Lauches the process and creates and Application object for it
        /// </summary>
        /// <param name="processStartInfo"></param>
        /// <returns></returns>
        public static Application Launch(ProcessStartInfo processStartInfo)
        {
            if (string.IsNullOrEmpty(processStartInfo.WorkingDirectory)) processStartInfo.WorkingDirectory = ".";

            Logger.DebugFormat("[Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                                             processStartInfo.FileName, 
                                             new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                                             new FileInfo(processStartInfo.FileName).FullName, 
                                             Environment.CurrentDirectory);
            Process process;
            try
            {
                process = Process.Start(processStartInfo);
            }
            catch (Win32Exception ex)
            {
                var error =
                    string.Format(
                        "[Failed Launching process:{0}] [Working directory:{1}] [Process full path:{2}] [Current Directory:{3}]",
                        processStartInfo.FileName,
                        new DirectoryInfo(processStartInfo.WorkingDirectory).FullName,
                        new FileInfo(processStartInfo.FileName).FullName,
                        Environment.CurrentDirectory);
                Logger.Error(error, ex);
                throw;
            }
            //TODO Expose this, and make it capture output properly
            if (ConfigurationManager.AppSettings["CaptureAUTOutput"] != null)
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                Logger.DebugFormat("[TestProcessOutput:{0}]", output);
                Logger.DebugFormat("[TestProcessError:{0}]", error);
            }
            return Attach(process);
        }

        /// <summary>
        /// Creates an Application object for existing process 
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public static Application Attach(int processId)
        {
            Process process = Process.GetProcessById(processId);
            if (process == null) throw new WhiteException("Could not find process with id: " + processId);
            return new Application(process);
        }

        /// <summary>
        /// Attaches with existing process
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static Application Attach(Process process)
        {
            return new Application(process);
        }

        /// <summary>
        /// Attaches with existing process
        /// </summary>
        /// <param name="executable"></param>
        /// <returns></returns>
        public static Application Attach(string executable)
        {
            Process[] processes = Process.GetProcessesByName(executable);
            if (processes.Length == 0) throw new WhiteException("Could not find process named: " + executable);
            return Attach(processes[0]);
        }

        /// <summary>
        /// Attaches to the process if it is running or launches a new process
        /// </summary>
        /// <param name="processStartInfo"></param>
        /// <returns></returns>
        public static Application AttachOrLaunch(ProcessStartInfo processStartInfo)
        {
            string processName = ReplaceLast(processStartInfo.FileName, ".exe", string.Empty);
            processName = Path.GetFileName(processName);
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0) return Launch(processStartInfo);
            return Attach(processes[0]);
        }

        private static string ReplaceLast(string replaceIn, string replace, string with)
        {
            int index = replaceIn.LastIndexOf(replace);
            if (index == -1) return replaceIn;
            return replaceIn.Substring(0, index) + with + replaceIn.Substring(index + replace.Length);
        }

        /// <summary>
        /// Name of the process
        /// </summary>
        public virtual string Name
        {
            get { return process.ProcessName; }
        }

        /// <summary>
        /// Internal to white
        /// </summary>
        public virtual ApplicationSession ApplicationSession
        {
            get { return applicationSession; }
        }

        /// <summary>
        /// Get visible window
        /// </summary>
        /// <param name="title">Title text of window displayed on desktop</param>
        /// <param name="option">Option which would be used to initialize the window.</param>
        /// <returns></returns>
        public virtual Window GetWindow(string title, InitializeOption option)
        {
            WindowSession windowSession = applicationSession.WindowSession(option);
            return windowFactory.CreateWindow(title, process, option, windowSession);
        }

        /// <summary>
        /// Get visible window
        /// </summary>
        /// <param name="title">Title text of window displayed on desktop</param>
        /// <returns></returns>
        public virtual Window GetWindow(string title)
        {
            return GetWindow(title, InitializeOption.NoCache);
        }

        /// <summary>
        /// Find the first window which belongs to this application and satisfies the critera.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <param name="initializeOption">found window would be initialized with this option</param>
        /// <returns></returns>
        public virtual Window GetWindow(SearchCriteria searchCriteria, InitializeOption initializeOption)
        {
            WindowSession windowSession = applicationSession.WindowSession(initializeOption);
            return windowFactory.CreateWindow(searchCriteria, process, initializeOption, windowSession);
        }

        /// <summary>
        /// Tries to find the main window, then close it. If it hasn't closed in 5 seconds, kill the process
        /// </summary>
        public virtual void Close()
        {
            Logger.Info("Closing Application");
            if (Process.HasExited)
            {
                Process.Dispose();
                return;
            }
            Process.CloseMainWindow();
            Process.WaitForExit(5000);
            if (!Process.HasExited)
            {
                Logger.Info("Application Failed to exit, killing process");
                Process.Kill();
            }
            Process.Dispose();
        }

        /// <summary>
        /// Kills the applications and waits till it is closed
        /// </summary>
        public virtual void Kill()
        {
            try
            {
                process.Kill();
                process.WaitForExit();
            }
            catch { }
        }

        /// <summary>
        /// All windows belonging to the application
        /// </summary>
        /// <returns></returns>
        public virtual List<Window> GetWindows()
        {
            return windowFactory.DesktopWindows(process, new NoApplicationSession());
        }

        /// <summary>
        /// Returns whether process has exited
        /// </summary>
        public virtual bool HasExited
        {
            get { return process.HasExited; }
        }

        /// <summary>
        /// Two applications are equal if they have the same process
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            var application = obj as Application;
            if (application == null) return false;
            return Equals(process, application.process);
        }

        public override int GetHashCode()
        {
            return process.GetHashCode();
        }

        public virtual void Dispose()
        {
            Kill();
        }

        public virtual Window FindSplash()
        {
            return windowFactory.SplashWindow(process);
        }

        /// <summary>
        /// Waits till application is busy.
        /// </summary>
        public virtual void WaitWhileBusy()
        {
            process.WaitForInputIdle(CoreAppXmlConfiguration.Instance.BusyTimeout);
        }

        /// <summary>
        /// Looks at all the windows visible for the application and finds one which matches the condition. The match is run against the title 
        /// of the windows
        /// </summary>
        /// <param name="match"></param>
        /// <param name="initializeOption">option for the window which matches the condition</param>
        public virtual Window Find(Predicate<string> match, InitializeOption initializeOption)
        {
            WindowSession windowSession = applicationSession.WindowSession(initializeOption);
            return windowFactory.FindWindow(process, match, initializeOption, windowSession);
        }

        public virtual Process Process
        {
            get { return process; }
        }

        /// <summary>
        /// Kills the application. Read Application.Kill.
        /// It also saves the application test execution state. This saves the position of the window UIItems which would be loaded next time
        /// automatically for improved performance. You would need to use InitializedOption.AndIdentifiedBy for specifying the identification of window.
        /// </summary>
        public virtual void KillAndSaveState()
        {
            Kill();
            ApplicationSession.Save();
        }
    }
}