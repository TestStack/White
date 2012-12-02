using System;
using System.Windows.Forms;
using Bricks.Core;
using White.Core;
using Lunar.Client.View.CommonControls;
using Recorder.Controllers;
using Recorder.Domain;
using Recorder.Recording;
using log4net;

namespace Recorder
{
    public partial class DashBoard : Form, UserEventListener
    {
        private readonly DashboardController controller;
        private readonly ILog logger = LogManager.GetLogger(typeof(DashBoard));

        public DashBoard(DashboardController controller)
        {
            InitializeComponent();
            Text = "White Recorder";
            this.controller = controller;
            BindData();
        }

        private void BindData()
        {
            WhiteRecorder recorder = controller.Recorder;
            Applications supportedApplications = recorder.Applications;
            supportedApplications.Insert(0, new NullApplication());
            screenObjectGeneratorOptionsView.BindData(recorder.ScreenObjectGenerator.Options);
            windowBrowser.BindData(recorder.Applications);
            recordOptionsView.BindData(recorder.RecordingOptions);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HookEvents();
        }

        private void HookEvents()
        {
            generateWindowClass.Click += GenerateClass;
            record.Click += StartMethodRecord;
            Closed += DashboardClosed;
        }

        private void DashboardClosed(object sender, EventArgs e)
        {
            try
            {
                controller.Recorder.Dispose();
            }
            catch (Exception exception)
            {
                logger.Error("Exception while closing Dashboard: ", exception);
            }
        }

        private void StartMethodRecord(object sender, EventArgs e)
        {
            using (CursorManager.WaitCursor(record))
            {
                codeEditor.Text = string.Empty;
                controller.Recorder.StartRecording(windowBrowser.CurrentWindow, this);
            }
        }

        private void GenerateClass(object sender, EventArgs e)
        {
            codeEditor.Text = string.Empty;
            codeEditor.Text = controller.Recorder.ScreenObjectGenerator.Generate(windowBrowser.CurrentWindow);
        }

        void UserEventListener.NewEvent(string userAction)
        {
            try
            {
                codeEditor.Invoke(Delegate.CreateDelegate(typeof(ModifyControl), this, "AppendText"), userAction);
            }
            catch (Exception e)
            {
                logger.Error("Exception while writing new event.\n", e);
            }
        }

        public virtual void UpdateEvent(string userAction)
        {
            try
            {
                codeEditor.Invoke(Delegate.CreateDelegate(typeof(ModifyControl), this, "UpdateText"), userAction);
            }
            catch (Exception e)
            {
                logger.Error("Exception while updating event.\n", e);
            }
        }

        public delegate void ModifyControl(string code);

        //Used via delegate
        private void AppendText(string code)
        {
            codeEditor.Text += code;
            codeEditor.Text += "\n";
        }

        //Used via delegate
        private void UpdateText(string code)
        {
            string existingText = codeEditor.Text;
            string s = S.LastLine(existingText);
            codeEditor.Text = existingText.Replace(s, code);
        }
    }
}