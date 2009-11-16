using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.Factory;
using White.Core.UIItems.WindowItems;
using Recorder.Recording;

namespace Recorder.Domain
{
    public class WhiteRecorder
    {
        private readonly ScreenObjectGenerator screenObjectGenerator;
        private readonly List<Window> windowsUnderRecording = new List<Window>();
        private readonly RecordingOptions recordingOptions;

        public WhiteRecorder()
        {
            screenObjectGenerator = new ScreenObjectGenerator();
            recordingOptions = new RecordingOptions();
        }

        public virtual RecordingOptions RecordingOptions
        {
            get { return recordingOptions; }
        }

        public virtual Applications Applications
        {
            get
            {
                PropertyCondition controlTypeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
                AutomationElementCollection automationElementCollection = AutomationElement.RootElement.FindAll(TreeScope.Children, controlTypeCondition);
                return new Applications(automationElementCollection);
            }
        }

        public virtual ScreenObjectGenerator ScreenObjectGenerator
        {
            get { return screenObjectGenerator; }
        }

        public virtual void StartRecording(Window window, UserEventListener eventListener)
        {
            windowsUnderRecording.Add(window);
            window.ReInitialize(InitializeOption.WithCache);
            window.Visit(new RecorderVisitor(eventListener, recordingOptions));
        }

        public virtual void Dispose()
        {
            for (int i = 0; i < windowsUnderRecording.Count; i++)
            {
                windowsUnderRecording[0].Visit(new UnHookEventsVisitor());
                windowsUnderRecording.Remove(windowsUnderRecording[0]);
            }
        }
    }
}