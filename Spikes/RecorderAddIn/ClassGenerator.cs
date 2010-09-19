using System;
using System.IO;
using System.Windows.Forms;
using Core.Logging;
using EnvDTE;
using EnvDTE80;
using Recorder.Controllers;

namespace RecorderAddIn
{
    public class ClassGenerator
    {
        private const string CSHARP_FILE_EXTENSION = ".cs";
        private const string TEMPLATE_FILE_PATH = @"Common7\IDE\NewFileItems\csharpclass.cs";
        private const string VISUAL_STUDIO_BASE_FOLDER = @"Microsoft Visual Studio 8";

        private readonly DTE2 applicationObject;

        public ClassGenerator(DTE2 applicationObject)
        {
            this.applicationObject = applicationObject;
        }

        public void LaunchScreenObjectGenerator()
        {
            CodeGeneratorAddIn codeGeneratorAddIn = new CodeGeneratorAddIn(new DashboardController());
            codeGeneratorAddIn.CodeGenerated += codeGeneratorAddIn_CodeGenerated;
            codeGeneratorAddIn.Show();
        }

        private void codeGeneratorAddIn_CodeGenerated(string fileName, string content)
        {
            try
            {
                Project selectedProject = Helper.GetSelectedProject(applicationObject);
                ProjectItem projectItem = AddProjectItemFromTemplate(selectedProject, fileName);
                InsertGeneratedCode(projectItem, content);
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Error("Exception while writing new event.\n", e);
                MessageBox.Show(e.Message, "White");
            }
        }

        private void InsertGeneratedCode(ProjectItem projectItem, string generatedContent)
        {
            projectItem.Open(Constants.vsViewKindCode);
            projectItem.Document.ActiveWindow.Activate();
            TextDocument textDocument = (TextDocument) projectItem.Document.Object("TextDocument");
            EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
            editPoint.Delete(textDocument.EndPoint);
            editPoint.Insert(generatedContent);
            projectItem.Save(Helper.GetFilePath(projectItem));
        }

        private ProjectItem AddProjectItemFromTemplate(Project selectedProject, string fileName)
        {
            return selectedProject.ProjectItems.AddFromTemplate(GetTemplateFilePath(selectedProject), fileName + CSHARP_FILE_EXTENSION);
        }

        private string GetTemplateFilePath(Project project)
        {
            string projectItemTemplatePath = applicationObject.Solution.ProjectItemsTemplatePath(project.Kind);
            string visualStudioFolderPath =
                projectItemTemplatePath.Substring(0, projectItemTemplatePath.IndexOf(VISUAL_STUDIO_BASE_FOLDER) + VISUAL_STUDIO_BASE_FOLDER.Length);
            return Path.Combine(visualStudioFolderPath, TEMPLATE_FILE_PATH);
        }
    }
}