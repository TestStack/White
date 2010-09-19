using Recorder.CodeGeneration;
using Recorder.Domain;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace White.Recorder.CodeGeneration
{
    public class WindowCodeGenerationStrategy : CodeGenerationStrategy
    {
        private readonly ScreenObjectGeneratorOptions generatorOptions;

        public WindowCodeGenerationStrategy(ScreenObjectGeneratorOptions generatorOptions)
        {
            this.generatorOptions = generatorOptions;
        }

        public virtual bool Reject(IUIItem uiItem)
        {
            return uiItem is Window || (generatorOptions.IgnoreLabels && uiItem is Label);
        }

        public virtual string FieldName(IUIItem uiItem)
        {
            return uiItem.Framework.IsManaged ? uiItem.Id : uiItem.Name;
        }
    }
}