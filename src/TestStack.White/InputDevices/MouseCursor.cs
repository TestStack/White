using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestStack.White.InputDevices
{
    public class MouseCursor
    {
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, IDC_STANDARD_CURSORS lpCursorName);

        enum IDC_STANDARD_CURSORS
        {
            IDC_ARROW = 32512,
            IDC_IBEAM = 32513,
            IDC_WAIT = 32514,
            IDC_CROSS = 32515,
            IDC_UPARROW = 32516,
            IDC_SIZE = 32640,
            IDC_ICON = 32641,
            IDC_SIZENWSE = 32642,
            IDC_SIZENESW = 32643,
            IDC_SIZEWE = 32644,
            IDC_SIZENS = 32645,
            IDC_SIZEALL = 32646,
            IDC_NO = 32648,
            IDC_HAND = 32649,
            IDC_APPSTARTING = 32650,
            IDC_HELP = 32651
        }

        public static MouseCursor IShapedCursor = new MouseCursor(IDC_STANDARD_CURSORS.IDC_IBEAM);
        public static MouseCursor Pointer = new MouseCursor(IDC_STANDARD_CURSORS.IDC_ARROW);
        public static readonly MouseCursor DefaultAndWait = new MouseCursor(IDC_STANDARD_CURSORS.IDC_APPSTARTING);
        public static readonly MouseCursor Wait = new MouseCursor(IDC_STANDARD_CURSORS.IDC_WAIT);

        private readonly int value;
        private static readonly List<MouseCursor> waitCursors = new List<MouseCursor>();

        static MouseCursor()
        {
            waitCursors.Add(DefaultAndWait);
            waitCursors.Add(Wait);
            waitCursors.AddRange(DynamicWaitCursors());
        }

        public MouseCursor(int value)
        {
            this.value = value;
        }

        private MouseCursor(IDC_STANDARD_CURSORS cursor)
        {
            var c = LoadCursor(IntPtr.Zero, cursor);
            this.value = c.ToInt32();
        }

        public static List<MouseCursor> DynamicWaitCursors()
        {
            return new List<MouseCursor> {new MouseCursor(Cursors.WaitCursor.Handle.ToInt32())};
        }

        public static List<MouseCursor> WaitCursors
        {
            get { return waitCursors; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MouseCursor)) return false;
            return ((MouseCursor) obj).value == value;
        }

        public override int GetHashCode()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}