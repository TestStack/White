using System;
using Core.UIItems;
using Repository;

namespace TestSampleApplication.Util
{
    public class VideoLibraryFieldMap : FieldMap
    {
        public virtual string GetFieldNameFor(string controlName, Type controlType)
        {
            if (controlType.IsSubclassOf(typeof(TextBox)) || controlType.Equals(typeof(TextBox)))
            {
                return controlName.ToLower().Replace("textbox", string.Empty);
            }
            return null;
        }
    }
}