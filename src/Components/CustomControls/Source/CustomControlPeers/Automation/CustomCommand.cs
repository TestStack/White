using System;
using System.Reflection;

namespace White.CustomControls.Peers.Automation
{
    public class CustomCommand : ICommand
    {
        private readonly object[] commandList;
        private readonly ICommandAssembly commandAssembly;

        public CustomCommand(string assemblyName, object[] payload, CommandAssemblies commandAssemblies)
        {
            commandList = payload;
            commandAssembly = commandAssemblies.Get(assemblyName);
        }

        private string TypeName
        {
            get { return (string) commandList[0]; }
        }

        private string MethodName
        {
            get { return (string) commandList[1]; }
        }

        private object[] GetArguments()
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
                    copiedArguments[i] = ObjectCopier.Copy(arguments[i], commandAssembly);
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

        public virtual object Execute(object control)
        {
            object commandImpl = commandAssembly.Create(GetImplementedTypeName(), control);
            MethodInfo methodInfo = commandImpl.GetType().GetMethod(MethodName);
            return methodInfo.Invoke(commandImpl, GetArguments());
        }
    }
}