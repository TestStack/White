using System;
using System.CodeDom;
using White.Core;
using White.Core.UIItems;
using Repository.ScreenAttributes;
using White.Recorder.CodeGeneration;

namespace Recorder.CodeGeneration
{
    public class CodeGenerationVisitor : WindowControlVisitor
    {
        private readonly DynamicScreenClass dynamicScreenClass = new DynamicScreenClass();
        private readonly CodeGenerationStrategy strategy;

        public CodeGenerationVisitor(CodeGenerationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public virtual void Accept(UIItem uiItem)
        {
            if (strategy.Reject(uiItem)) return;
            dynamicScreenClass.Add(strategy.FieldName(uiItem), uiItem.GetType());
        }

        public virtual void Generate(CodeTypeDeclaration codeTypeDeclaration)
        {
            dynamicScreenClass.EachField(GenerateField(codeTypeDeclaration));
        }

        private static DynamicScreenClass.EachFieldDelegate GenerateField(CodeTypeDeclaration codeTypeDeclaration)
        {
            return delegate(ScreenClassField screenClassField)
                       {
                           CodeMemberField codeMemberField = new CodeMemberField(screenClassField.FieldType, screenClassField.FieldName);
                           codeMemberField.Attributes = MemberAttributes.Private;
                           if (screenClassField.IsIndexed)
                               codeMemberField.CustomAttributes.Add(
                                   CodeForNameIndexAttribute(typeof (IndexAttribute), screenClassField.FieldName, screenClassField.Index));
                           if (screenClassField.UIItemNameInvalidFieldName)
                               codeMemberField.CustomAttributes.Add(CodeAttribute(typeof (AutomationIdAttribute), screenClassField.UIItemName));

                           codeTypeDeclaration.Members.Add(codeMemberField);
                       };
        }

        private static CodeAttributeDeclaration CodeAttribute(Type type, object value)
        {
            CodeTypeReference indexAttributeType = new CodeTypeReference(type);
            CodeAttributeArgument indexAttributeArgument = new CodeAttributeArgument(new CodePrimitiveExpression(value));
            return new CodeAttributeDeclaration(indexAttributeType, indexAttributeArgument);
        }

        private static CodeAttributeDeclaration CodeForNameIndexAttribute(Type type, string name, int index)
        {
            CodeTypeReference indexAttributeType = new CodeTypeReference(type);
            CodeAttributeArgument nameAttribute = new CodeAttributeArgument(new CodePrimitiveExpression(name));
            CodeAttributeArgument indexAttribute = new CodeAttributeArgument(new CodePrimitiveExpression(index));
            return new CodeAttributeDeclaration(indexAttributeType, nameAttribute, indexAttribute);
        }
    }
}