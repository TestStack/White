using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Automation;

namespace White.Core.ScreenMap
{
    public class WindowsAutomationTypesSurrogates : IDataContractSurrogate
    {
        public virtual Type GetDataContractType(Type type)
        {
            if (type == typeof (ControlType))
                return typeof (ControlTypeSurrogate);

            if (type == typeof(AutomationProperty))
                return typeof(AutomationPropertySurrogate);

            return type;
        }

        public virtual object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj.GetType() == typeof (ControlType))
                return new ControlTypeSurrogate { ControlTypeId = ((ControlType)obj).Id };

            if (obj.GetType() == typeof(AutomationProperty))
                return new AutomationPropertySurrogate { AutomationId = ((AutomationProperty)obj).Id};

            return obj;
        }

        public virtual object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(ControlTypeSurrogate))
                return ControlType.LookupById(((ControlTypeSurrogate)obj).ControlTypeId);

            if (obj.GetType() == typeof(AutomationPropertySurrogate))
                return AutomationProperty.LookupById(((AutomationPropertySurrogate) obj).AutomationId);

            return obj;
        }

        public virtual object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public virtual object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public virtual void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            customDataTypes.Add(typeof (ControlTypeSurrogate));
        }

        public virtual Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            if (typeName == typeof (ControlTypeSurrogate).Name)
                return typeof (ControlType);

            return null;
        }

        public virtual CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
    }
}