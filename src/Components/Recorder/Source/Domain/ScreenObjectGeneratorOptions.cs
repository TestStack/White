namespace Recorder.Domain
{
    public class ScreenObjectGeneratorOptions
    {
        private bool ignoreLabels;
        private string @namespace;

        public virtual bool IgnoreLabels
        {
            get { return ignoreLabels; }
            set { ignoreLabels = value; }
        }

        public virtual string Namespace
        {
            get { return @namespace; }
            set { @namespace = value; }
        }
    }
}