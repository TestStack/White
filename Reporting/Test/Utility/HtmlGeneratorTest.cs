using System.IO;
using System.Text;
using NUnit.Framework;
using Reporting.Domain;
using Reporting.Utility;

namespace Reporting.Test.Utility
{
    [TestFixture]
    public class HtmlGeneratorTest
    {
        private readonly SubFlows subFlows = new SubFlows("archiveLocation", "flowName");

        [SetUp]
        public void SetUp()
        {
            subFlows.Begin("subFlow");
            subFlows.Next(typeof (One));
            subFlows.Next(typeof (Two));
            subFlows.Finish();
        }
   
        [Test]
        public void Generate()
        {
            Assert.AreEqual(File.ReadAllText(@"Test\Utility\GeneratedReport.htm"), HtmlGenerator.GenerateReport(subFlows));
        }

        [Test]
        public void AppendHeader()
        {
            StringBuilder expectedHtmlText = new StringBuilder();
            expectedHtmlText.AppendLine("<head>");
            expectedHtmlText.AppendLine("<title>flowName</title>");
            expectedHtmlText.AppendLine("<script>");
            expectedHtmlText.AppendLine("function ShowScreenShots(){");
            expectedHtmlText.AppendLine("images = '';");
            expectedHtmlText.AppendLine("for(i=0;i<arguments.length;i++)images += ('<img src=\"' + arguments[i] + '\"/>');");
            expectedHtmlText.AppendLine("document.getElementById('screenShots').innerHTML = images;}");
            expectedHtmlText.AppendLine("</script>");

            expectedHtmlText.AppendLine("</head>");
            StringBuilder builder = new StringBuilder();
            HtmlGenerator.AppendHeader(subFlows.FlowName, builder);
            Assert.AreEqual(expectedHtmlText.ToString(), builder.ToString());
        }
    }
}