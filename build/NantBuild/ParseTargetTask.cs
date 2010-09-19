using NAnt.Core;
using NAnt.Core.Attributes;

namespace NantBuild
{
    [TaskName("parseTarget")]
    public class ParseTargetTask : Task
    {
        [TaskAttribute("target", Required = true)]
        public string Target { get; set; }

        protected override void ExecuteTask()
        {
            string[] splits = Target.Split('.');
            if (splits.Length != 2) throw new BuildException(string.Format("String:{0} not separated into two parts by the separator: {1}", Target, ".".ToCharArray()[0]));
            Project.Properties["component"] = splits[0];
            Project.Properties["target"] = splits[1];
        }
    }
}