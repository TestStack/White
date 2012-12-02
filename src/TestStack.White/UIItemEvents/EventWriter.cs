using System;
using System.Text;

namespace White.Core.UIItemEvents
{
    public abstract class EventWriter
    {
        private string code;

        public virtual void Write(Type uiItemType, string actionName, string identification, object[] parameters)
        {
            var builder = new StringBuilder(CodeForGettingUIItem(uiItemType, identification));

            builder.Append(".").Append(actionName);
            if (uiItemType.GetProperty(actionName) != null)
            {
                builder.Append(" = ");
                if (parameters[0] is bool) builder.Append((bool) parameters[0] ? "true" : "false");
                else builder.Append("\"" + parameters[0] + "\"");
            }
            else
            {
                builder.Append("(");
                for (int i = 0; i < parameters.Length; i++)
                {
                    builder.Append("\"").Append(parameters[i]).Append("\"");
                    if (i != parameters.Length - 1) builder.Append(", ");
                }
                builder.Append(")");
            }

            builder.Append(";");
            code = builder.ToString();
        }

        protected abstract string CodeForGettingUIItem(Type uiItemType, string identification);

        public virtual string Code
        {
            get { return code; }
        }
    }
}