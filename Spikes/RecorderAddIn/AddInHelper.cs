using System;
using System.IO;
using EnvDTE;
using EnvDTE80;

public class Helper
{
    public static bool IsActiveDocumentAProject(DTE2 applicationObject)
    {
        foreach (Project project in GetProjectsInSolution(applicationObject))
        {
            if (IsSelectedUIHierarchyItemAProject(applicationObject, project))
                return true;
        }
        return false;
    }

    public static string GetFilePath(ProjectItem projectItem)
    {
        return Path.Combine(projectItem.Document.Path, projectItem.Document.FullName);
    }

    private static object[] GetProjectsInSolution(DTE2 applicationObject)
    {
        return applicationObject.ActiveSolutionProjects as object[];
    }

    public static Project GetSelectedProject(DTE2 applicationObject)
    {
        return
            (Project)
            Array.Find(GetProjectsInSolution(applicationObject),
                       delegate(object project) { return IsSelectedUIHierarchyItemAProject(applicationObject, project); });
    }

    private static bool IsSelectedUIHierarchyItemAProject(DTE2 applicationObject, object project)
    {
        return IsSelectedUIHierarchyItemAProject(applicationObject, (Project) project);
    }

    private static bool IsSelectedUIHierarchyItemAProject(DTE2 applicationObject, Project project)
    {
        return project.Name == GetSelectedUIHierarchyItem(applicationObject).Name;
    }

    public static UIHierarchyItem GetSelectedUIHierarchyItem(DTE2 applicationObject)
    {
        UIHierarchy uiHierarchy = applicationObject.ToolWindows.SolutionExplorer;
        return (UIHierarchyItem) ((Array) uiHierarchy.SelectedItems).GetValue(0);
    }

    public static ProjectItem GetSelectedProjectItem(DTE2 applicationObject)
    {
        UIHierarchy uiHierarchy = applicationObject.ToolWindows.SolutionExplorer;
        UIHierarchyItem item = (UIHierarchyItem) ((Array) uiHierarchy.SelectedItems).GetValue(0);
        foreach (SelectedItem selectedItem in applicationObject.SelectedItems)
        {
            if (item.Name == selectedItem.Name)
                return selectedItem.ProjectItem;
        }
        return null;
    }
}