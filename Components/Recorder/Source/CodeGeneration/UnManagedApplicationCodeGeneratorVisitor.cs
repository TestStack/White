using Core.UIItems;
using Recorder.Domain;

namespace Recorder.CodeGeneration
{
    public class UnManagedApplicationCodeGeneratorVisitor : CodeGenerationVisitor
    {
        public UnManagedApplicationCodeGeneratorVisitor(ScreenObjectGeneratorOptions generatorOptions) : base(generatorOptions) {}

        protected override string FieldName(UIItem item)
        {
            return item.Name;
        }
    }
}