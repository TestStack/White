using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using Recorder.Domain;

namespace Recorder.CodeGeneration
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