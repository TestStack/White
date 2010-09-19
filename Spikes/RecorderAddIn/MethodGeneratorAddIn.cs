using System;
using System.Windows.Forms;
using Bricks.Core;
using Core;
using Core.Logging;
using Lunar.Client.View.CommonControls;
using Recorder.Controllers;
using Recorder.Domain;
using Recorder.Recording;

namespace RecorderAddIn
{
    public partial class MethodGeneratorAddIn : Form, UserEventListener
    {
        #region Delegates

        public delegate void MethodGeneratorAddInDelegate(string content);

        public delegate void ModifyControl(string code);

        #endregion

        private const string METHOD_FORMAT = @"public void {0}(){1}";

        private readonly DashboardController controller;
        private readonly string methodNameToRecord;
        private string methodBody = "";

        public MethodGeneratorAddIn(DashboardController controller, string methodNameToRecord)
        {
            InitializeComponent();
            this.controller = controller;
            this.methodNameToRecord = methodNameToRecord;
            BindData();
        }

        #region UserEventListener Members

        public void NewEvent(string userAction)
        {
            try
            {
                codePreviewEditor.Invoke(Delegate.CreateDelegate(typeof (ModifyControl), this, "AppendText"), userAction);
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Error("Exception while writing new event.\n", e);
            }
        }

        public void UpdateEvent(string userAction)
        {
            try
            {
                codePreviewEditor.Invoke(Delegate.CreateDelegate(typeof (ModifyControl), this, "UpdateText"), userAction);
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Error("Exception while updating event.\n", e);
            }
        }

        #endregion

        public event MethodGeneratorAddInDelegate MethodGenerated;

        private void BindData()
        {
            WhiteRecorder recorder = controller.Recorder;
            Applications supportedApplications = recorder.Applications;
            supportedApplications.Insert(0, new NullApplication());
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
                WhiteLogger.Instance.Error("Exception while closing Dashboard: ", exception);
            }
        }

        private void StartMethodRecord(object sender, EventArgs e)
        {
            if (record.Text == START_RECORDING)
                StartRecording();
            else
                StopRecording();
            record.Text = GetNextStatusForRecording();
        }

        private void StopRecording()
        {
            //TODO: Create methods on the recorder for stopping recording
            if (MethodGenerated != null)
                MethodGenerated(codePreviewEditor.Text);
            Close();
        }

        private void StartRecording()
        {
            using (CursorManager.WaitCursor(record))
                controller.Recorder.StartRecording(windowBrowser.CurrentWindow, this);
        }

        private string GetNextStatusForRecording()
        {
            return START_RECORDING == record.Text ? STOP_RECORDING : START_RECORDING;
        }

        private void AppendText(string code)
        {
            methodBody += code + "\n";
            UpdateCodePreviewEditor(methodBody);
        }

        private void UpdateText(string code)
        {
            string existingText = methodBody;
            string s = S.LastLine(existingText);
            UpdateCodePreviewEditor(existingText.Replace(s, code));
        }

        private void UpdateCodePreviewEditor(string methodDefinition)
        {
            codePreviewEditor.Text = string.Format(METHOD_FORMAT, methodNameToRecord, WrapMethodDefinitionWithinBraces(methodDefinition));
        }

        private string WrapMethodDefinitionWithinBraces(string methodDefinition)
        {
            return "{\n" + methodDefinition + "}";
        }
    }
}