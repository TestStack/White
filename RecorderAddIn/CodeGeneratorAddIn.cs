using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Core;
using Core.Logging;
using Recorder.Controllers;
using Recorder.Domain;

namespace RecorderAddIn
{
    public delegate void CodeGeneratorAddInDelegate(string fileName, string content);

    public partial class CodeGeneratorAddIn : Form
    {
        private readonly DashboardController controller;

        public CodeGeneratorAddIn(DashboardController controller)
        {
            InitializeComponent();
            this.controller = controller;
            BindData();
        }

        public event CodeGeneratorAddInDelegate CodeGenerated;

        private void BindData()
        {
            WhiteRecorder recorder = controller.Recorder;
            Applications supportedApplications = recorder.Applications;
            supportedApplications.Insert(0, new NullApplication());
            screenObjectGeneratorOptionsView.BindData(recorder.ScreenObjectGenerator.Options);
            windowBrowser.BindData(recorder.Applications);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HookEvents();
        }

        private void HookEvents()
        {
            generate.Click += GenerateClass;
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

        private void GenerateClass(object sender, EventArgs e)
        {
            if (CodeGenerated != null)
            {
                string generatedCode = controller.Recorder.ScreenObjectGenerator.Generate(windowBrowser.CurrentWindow);
                CodeGenerated(GetClassNameFrom(generatedCode), generatedCode);
            }
            Close();
        }

        private string GetClassNameFrom(string generatedCode)
        {
            string patternToMatchClassName = @"(\w+)(\s+)class(\s+)(?<classname>(\w+))(\s+){";
            return Regex.Match(generatedCode, patternToMatchClassName, RegexOptions.Multiline).Groups["classname"].ToString();
        }
    }
}