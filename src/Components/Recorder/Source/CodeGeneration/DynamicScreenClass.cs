using System;
using System.Collections.Generic;
using White.Recorder.CodeGeneration;

namespace Recorder.CodeGeneration
{
    public class DynamicScreenClass
    {
        private readonly List<ScreenClassField> screenClassFields = new List<ScreenClassField>();

        public delegate void EachFieldDelegate(ScreenClassField screenClassField);

        public virtual ScreenClassField Add(string name, Type type)
        {
            ScreenClassField screenClassField = Create(name, type);
            screenClassFields.Add(screenClassField);
            return screenClassField;
        }

        private ScreenClassField Create(string name, Type type)
        {
            List<ScreenClassField> sameNameFields = screenClassFields.FindAll(delegate(ScreenClassField obj) { return obj.Has(name, type); });
            int usedIndex = -1;
            foreach (ScreenClassField sameNameField in sameNameFields)
            {
                usedIndex = sameNameField.IndexField();
            }
            return new ScreenClassField(name, type, usedIndex == ScreenClassField.nonIndexedValue ? usedIndex : ++usedIndex);
        }

        public virtual void EachField(EachFieldDelegate eachFieldDelegate)
        {
            foreach (ScreenClassField screenClassField in screenClassFields)
            {
                eachFieldDelegate.Invoke(screenClassField);
            }
        }
    }
}