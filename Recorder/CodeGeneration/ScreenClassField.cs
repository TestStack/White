using System;

namespace Recorder.CodeGeneration
{
    public class ScreenClassField
    {
        private readonly string name;
        private readonly string uiItemName;
        private readonly Type type;
        private int index = nonIndexedValue;
        private static readonly string invalidCharacters = "._;:'][{}+=!@#$%^&*()~`\"?/><, ";
        private readonly bool invalidFieldName;
        public static readonly int nonIndexedValue = -1;

        public ScreenClassField(string name, Type type, int index)
        {
            string[] strings = name.Split(invalidCharacters.ToCharArray());
            if (strings.Length != 1)
            {
                invalidFieldName = true;
            }
            foreach (string s in strings)
            {
                this.name += s;
            }
            this.type = type;
            this.index = index;
            uiItemName = name;
        }

        public virtual Type FieldType
        {
            get { return type; }
        }

        public virtual string FieldName
        {
            get { return name + (index > nonIndexedValue ? index.ToString() : string.Empty); }
        }

        public virtual int Index
        {
            get { return index; }
        }

        public virtual bool IsIndexed
        {
            get { return index != nonIndexedValue; }
        }

        public virtual bool UIItemNameInvalidFieldName
        {
            get { return invalidFieldName; }
        }

        public virtual string UIItemName
        {
            get { return uiItemName; }
        }

        internal virtual bool Has(string otherName, Type otherType)
        {
            return uiItemName.Equals(otherName) && type.Equals(otherType);
        }

        internal virtual int IndexField()
        {
            if (index == nonIndexedValue) return ++index;
            return index;
        }
    }
}