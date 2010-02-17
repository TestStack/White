using System.Collections.Generic;

namespace White.WPFCustomControls.Automation
{
    public class CustomCommand : ICustomCommand
    {
        private readonly List<object> commandList;

        public CustomCommand(List<object> commandList)
        {
            this.commandList = commandList;
        }

        public string AssemblyFile
        {
            get { return (string) commandList[0]; }
        }

        public virtual string TypeName
        {
            get { return (string) commandList[1]; }
        }

        public virtual string MethodName
        {
            get { return (string) commandList[2]; }
        }

        public virtual object[] Arguments
        {
            get { return (object[]) commandList[3]; }
        }

        public virtual string GetImplementedTypeName()
        {
            string[] strings = TypeName.Split('.');
            int lastIndex = strings.Length - 1;
            strings[lastIndex] = strings[lastIndex].Substring(1);
            return string.Join(".", strings);
        }
    }
}