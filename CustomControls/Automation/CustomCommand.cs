using System;
using System.Collections.Generic;

namespace White.CustomControls.Automation
{
    public class CustomCommand : ICustomCommand
    {
        private readonly string assemblyFile;
        private readonly List<object> commandList;

        public CustomCommand(string assemblyFile, List<object> payload)
        {
            this.assemblyFile = assemblyFile;
            commandList = payload;
        }

        public virtual string AssemblyFile
        {
            get { return assemblyFile; }
        }

        public virtual string TypeName
        {
            get { return (string) commandList[0]; }
        }

        public virtual string MethodName
        {
            get { return (string) commandList[1]; }
        }

        public virtual object[] GetArguments(AssemblyBasedFactory factory)
        {
            var arguments = (object[]) commandList[2];
            var copiedArguments = new object[arguments.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == null)
                {
                    copiedArguments[i] = null;
                }
                else
                {
                    Type type = factory.GetType(arguments[i].GetType().FullName);
                    copiedArguments[i] = type == null ? arguments[i] : ObjectCopier.Copy(arguments[i], type);
                }
            }
            return copiedArguments;
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