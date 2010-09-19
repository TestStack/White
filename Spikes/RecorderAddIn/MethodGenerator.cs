using System;
using System.Windows.Forms;
using Core.Logging;
using EnvDTE;
using EnvDTE80;
using Recorder.Controllers;

namespace RecorderAddIn
{
    public class MethodGenerator
    {
        private readonly DTE2 applicationObject;

        public MethodGenerator(DTE2 applicationObject)
        {
            this.applicationObject = applicationObject;
        }

        public void LaunchRecorder(string methodNameToRecord)
        {
            MethodGeneratorAddIn methodGeneratorAddIn = new MethodGeneratorAddIn(new DashboardController(), methodNameToRecord);
            methodGeneratorAddIn.MethodGenerated += methodGeneratorAddIn_MethodGenerated;
            methodGeneratorAddIn.Show();
        }

        private void methodGeneratorAddIn_MethodGenerated(string methodContent)
        {
            try
            {
                ProjectItem projectItem = Helper.GetSelectedProjectItem(applicationObject);
                InsertGeneratedMethod(projectItem, methodContent);
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Error("Exception while writing new event.\n", e);
                MessageBox.Show(e.Message, "White");
            }
        }

        private void InsertGeneratedMethod(ProjectItem projectItem, string content)
        {
            projectItem.Open(Constants.vsViewKindCode);
            projectItem.Document.ActiveWindow.Activate();
            TextDocument textDocument = (TextDocument) projectItem.Document.Object("TextDocument");
            EditPoint editPoint = textDocument.EndPoint.CreateEditPoint();
            editPoint.EndOfDocument();
            editPoint.StartOfLine();
            editPoint.LineUp(1);
            editPoint.Insert(content + "\n");
            projectItem.Save(Helper.GetFilePath(projectItem));
        }

        public void GetMethodNameAndLaunchRecorder()
        {
            MethodNameGeneratorAddIn methodNameGeneratorAddIn = new MethodNameGeneratorAddIn(this);
            methodNameGeneratorAddIn.Show();
        }
    }
}