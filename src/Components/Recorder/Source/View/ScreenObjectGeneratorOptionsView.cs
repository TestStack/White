using System.Windows.Forms;
using Bricks;
using Recorder.Domain;

namespace Recorder.View
{
    public partial class ScreenObjectGeneratorOptionsView : UserControl
    {
        public ScreenObjectGeneratorOptionsView()
        {
            InitializeComponent();
        }

        public virtual void BindData(ScreenObjectGeneratorOptions options)
        {
            ignoreLabels.DataBindings.Add("Checked", options, CodePath.Get(CodePath.New<ScreenObjectGeneratorOptions>().IgnoreLabels), false,
                                          DataSourceUpdateMode.OnPropertyChanged);
            namespaceText.DataBindings.Add("Text", options, CodePath.Get(CodePath.New<ScreenObjectGeneratorOptions>().Namespace), false,
                                           DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}