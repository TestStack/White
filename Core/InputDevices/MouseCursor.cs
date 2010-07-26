using System.Collections.Generic;
using System.Windows.Forms;

namespace White.Core.InputDevices
{
    public class MouseCursor
    {
        public static MouseCursor IShapedCursor = new MouseCursor(65555);
        public static MouseCursor Pointer = new MouseCursor(65553);
        public static readonly MouseCursor DefaultAndWait = new MouseCursor(65575);
        public static readonly MouseCursor Wait = new MouseCursor(65557);
        public static readonly MouseCursor SilverlightWait = new MouseCursor(65543);
        public static MouseCursor SilverlightPointer = new MouseCursor(65539);

        private readonly int value;
        private static readonly List<MouseCursor> waitCursors = new List<MouseCursor>();

        static MouseCursor()
        {
            waitCursors.Add(DefaultAndWait);
            waitCursors.Add(Wait);
            waitCursors.Add(SilverlightWait);
            waitCursors.AddRange(DynamicWaitCursors());
        }

        public MouseCursor(int value)
        {
            this.value = value;
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