namespace WindowsFormsTestApplication
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;

    [DefaultProperty("NotWhole")]
    public class BasicTypes
    {
        public BasicTypes(string buffer, bool boolean, int integer, float notWhole)
        {
            Buffer = buffer;
            NotWhole = notWhole;
            Integer = integer;
            Boolean = boolean;
        }

        [DefaultValue(false)]
        public bool Boolean { get; set; }

        [Description("String")]
        public string Buffer { get; set; }

        [Description("Select a file..."), Category("Input"), Browsable(true), 
         Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string FileName { get; set; } = "test.txt";

        [Category("Number")]
        public int Integer { get; set; }

        [Category("Number"), ReadOnly(true)]
        public float NotWhole { get; set; }

        [Category("General")]
        public Color ToolbarColor { get; set; } = SystemColors.Control;

        [Category("General")]
        public Font WindowFont { get; set; } = new Font("Arial", 8, FontStyle.Regular);

        [Category("General")]
        public Size WindowSize { get; set; } = new Size(100, 100);
    }
}