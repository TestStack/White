namespace White.Core.UIItems.WindowStripControls
{
    public class StatusStripSplitButton
    {
        private readonly TextBox textBox;

        public StatusStripSplitButton(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public virtual void Click()
        {
            textBox.ClickAtRightEdge();
        }
    }

    public class StatusStripDropDownButton
    {
        private readonly TextBox textBox;

        public StatusStripDropDownButton(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public virtual void Click()
        {
            textBox.ClickAtCenter();
        }
    }
}