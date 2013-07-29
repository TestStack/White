using System;
using System.IO;

namespace TestStack.White.ScreenObjects.ScreenFlow
{
    public class StringGraphWriter
    {
        private class Digraph
        {
            public const string Start = "digraph G {";
            public const string End = "}";
            public const string RedEdge = @"edge [color=red];";

            public static string Path(string fromNode, string toNode, string pathLabel)
            {
                return string.Format(@"""{0}"" -> ""{1}"" [label=""{2}""];", fromNode, toNode, pathLabel);
            }

            public static string BoxNode(string node)
            {
                return string.Format(@"""{0}"" [shape=box];", node);
            }
        }

        private readonly string fileName;

        public StringGraphWriter(string fileName)
        {
            this.fileName = fileName;
            File.WriteAllText(fileName, string.Empty);
        }

        public virtual void Stop(string stopNode)
        {
            string[] entireText =
                new string[] {Digraph.Start, File.ReadAllText(fileName), Digraph.BoxNode(stopNode), Digraph.End};
            File.WriteAllLines(fileName, entireText);
        }

        public virtual void Start(string startNode)
        {
            AppendLine(Digraph.BoxNode(startNode));
        }

        public virtual void AppendFlow(string fromNode, string toNode)
        {
            string text = Digraph.Path(fromNode, toNode, DateTime.Now.ToLongTimeString());
            AppendLine(text);
        }

        public virtual void AppendError()
        {
            AppendLine(Digraph.RedEdge);
        }

        private void AppendLine(string text)
        {
            string[] entireText = new string[] {File.ReadAllText(fileName), text};
            File.WriteAllLines(fileName, entireText);
        }
    }
}