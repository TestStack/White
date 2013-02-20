using System.Text;
using Reporting.Domain;

namespace Reporting.Utility
{
    public class HtmlGenerator
    {
        public static string GenerateReport(SubFlows subFlows)
        {
            StringBuilder builder = new StringBuilder();
            AppendHeader(subFlows.FlowName, builder);
            builder.AppendLine("<body>");
            builder.AppendLine("<div>");
            int index = 1;
            foreach (SubFlow subFlow in subFlows)
                Add(builder, subFlow, index++);
            builder.AppendLine("</div>");
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");
            return builder.ToString();
        }

        private static void Add(StringBuilder builder, SubFlow subFlow, int rowNumber)
        {
            builder.AppendLine("<div class=\"subFlow" + ((rowNumber%2 == 0) ? "" : " odd") + "\">");
            builder.AppendLine("<div class=\"name\">"+subFlow.Name+"</div>");

            int i = 1;
            foreach (SubFlowStep step in subFlow.FlowSteps)
            {
                builder.AppendLine("<div class=\"step\">");
                builder.AppendLine("<div class=\"stepName\">" + step.Label + "</div>");
                builder.AppendLine("<div class=\"images\">");
                AddSnapShots(builder, step);
                builder.AppendLine("</div>");
                builder.AppendLine("</div>");
                if (i++ != subFlow.FlowSteps.Count)
                    AddTimeStamp(builder, step);
            }
            builder.AppendLine("</div>");
        }

        private static void AddSnapShots(StringBuilder builder, SubFlowStep step)
        {
            foreach (ScreenShot path in step.ScreenShots)
            {
                builder.AppendLine("<a href=\"#\" onclick=\"openScreen('" + path.SnapShotPath.Replace("\\", "/") + "')\"><img height=\"50\" width=\"50\" src=\"" +
                                   path.ThumbNailPath.Replace("\\", "/") + "\"></img></a>");
            }
        }

        private static void AddTimeStamp(StringBuilder builder, SubFlowStep step)
        {
            builder.AppendLine("<div class=\"direction\">=(" + step.TimeSpent + ")=></div>");
        }

        public static void AppendHeader(string title, StringBuilder builder)
        {
            builder.AppendLine("<html>");
            builder.AppendLine("<head>");
            builder.AppendLine("<title>" + title + "</title>");
            AddCssStyles(builder);
            AddJavaScript(builder);
            builder.AppendLine("</head>");
        }

        private static void AddCssStyles(StringBuilder builder)
        {
            builder.AppendLine("<style>");
            builder.AppendLine("div.subFlow{margin-bottom: 15px;border: solid;overflow: auto;}");
            builder.AppendLine("div.odd{background-color: #E0DFDB;}");
            builder.AppendLine("div.direction{float: left;margin-top: 30px;}");
            builder.AppendLine("div.step{margin-right: 15px;margin-left: 15px;text-align: center; float: left;}");
            builder.AppendLine("div.name{margin-left: 30px;font-family: verdana;font-size: 15px;}</style>");
        }

        private static void AddJavaScript(StringBuilder builder)
        {
            builder.AppendLine("<script>");
            builder.AppendLine("function openScreen(){window.open(arguments[0]);}");
            builder.AppendLine("</script>");
        }

        private static string ReplaceEscapedSlashes(string s)
        {
            return s.Replace("\\", "/");
        }
    }
}