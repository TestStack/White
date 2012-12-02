using System.Windows.Forms;
using Bricks;
using Recorder.Domain;

namespace Recorder.View
{
    public partial class RecordOptionsView : UserControl
    {
        public RecordOptionsView()
        {
            InitializeComponent();
        }

        public virtual void BindData(RecordingOptions recordingOptions)
        {
            core.DataBindings.Add("Checked", recordingOptions, CodePath.Get(CodePath.New<RecordingOptions>().Core), false,
                                  DataSourceUpdateMode.OnPropertyChanged);
            screenRepository.DataBindings.Add("Checked", recordingOptions, CodePath.Get(CodePath.New<RecordingOptions>().ScreenRepository), false,
                                  DataSourceUpdateMode.OnPropertyChanged);
            bulkText.DataBindings.Add("Checked", recordingOptions, CodePath.Get(CodePath.New<RecordingOptions>().BulkText), false,
                                      DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
