using White.Core.UIItems;

namespace Recorder.CodeGeneration
{
    public interface CodeGenerationStrategy
    {
        bool Reject(IUIItem uiItem);
        string FieldName(IUIItem uiItem);
    }
}