using System.Windows;
using TestStack.White.UIItems;

namespace TestStack.White.InputDevices
{
    public interface IAttachedMouse
    {
        /// <summary>
        /// Location <see cref="Point"/> of Mouse
        /// </summary>
        Point Location { get; set; }

        /// <summary>
        /// <see cref="MouseCursor"/> Cursor of the Mouse
        /// </summary>
        MouseCursor Cursor { get; }

        /// <summary>
        /// Perform a Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to Click</param>
        /// <remarks>
        /// Clicks the specified mouse button. Makes sure to not accidentaly fire a double click
        /// if called multiple times
        /// </remarks>
        void Click(MouseButton mouseButton);

        /// <summary>
        /// Perform a Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to Click</param>
        /// <param name="point">Point to Click on</param>
        /// <remarks>
        /// Clicks the specified mouse button. Makes sure to not accidentaly fire a double click
        /// if called multiple times
        /// </remarks>
        void Click(MouseButton mouseButton, Point point);

        /// <summary>
        /// Perform a Double Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to double click</param>
        void DoubleClick(MouseButton mouseButton);

        /// <summary>
        /// Perform a Double Click Operation
        /// </summary>
        /// <param name="mouseButton">MouseButton to double click</param>
        /// <param name="point">Point where to Double Click on</param>
        void DoubleClick(MouseButton mouseButton, Point point);

        /// <summary>
        /// Perform a Left Click Operation
        /// </summary>
        void LeftClick();

        /// <summary>
        /// Perform a Left Click Operation
        /// </summary>
        /// <param name="point">Point where to Click on</param>
        void LeftClick(Point point);

        /// <summary>
        /// Perform a Mouse Left Double Click Operation
        /// </summary>
        void LeftDoubleClick();

        /// <summary>
        /// Perform a Mouse Left Double Click Operation
        /// </summary>
        /// <param name="point">Point where to Double Click on</param>
        void LeftDoubleClick(Point point);

        /// <summary>
        /// Perform a Right Click Operation
        /// </summary>
        void RightClick();

        /// <summary>
        /// Perform a Right Click Operation
        /// </summary>
        /// <param name="point">Point where to Double Click on</param>
        void RightClick(Point point);

        /// <summary>
        /// Drags the dragged <see cref="IUIItem"/> and drops it on the drop <see cref="IUIItem"/>. 
        /// This can be used for any two UIItems  whether they are same application or different. 
        /// To drop items on desktop use Desktop class's Drop method. 
        /// White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="draggedItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="dropItem"><see cref="IUIItem"/> to drop on</param>
        void DragAndDrop(IUIItem draggedItem, IUIItem dropItem);

        /// <summary>
        /// Drags the dragged <see cref="IUIItem"/> and drops it on the drop <see cref="IUIItem"/>. 
        /// This can be used for any two UIItems  whether they are same application or different. 
        /// To drop items on desktop use Desktop class's Drop method. 
        /// White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="mouseButton"><see cref="MouseButton"/> to use for dragging</param>
        /// <param name="draggedItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="dropItem"><see cref="IUIItem"/> to drop on</param>
        void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, IUIItem dropItem);

        /// <summary>
        /// Drags the dragged <see cref="IUIItem"/> and drops it on the drop <see cref="IUIItem"/>. 
        /// This can be used for any two UIItems  whether they are same application or different. 
        /// To drop items on desktop use Desktop class's Drop method. 
        /// White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="draggedItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="startPosition">Start Position <see cref="Point"/></param>
        /// <param name="dropItem"><see cref="IUIItem"/> to drop on</param>
        /// <param name="endPosition">End Position <see cref="Point"/></param>
        void DragAndDrop(IUIItem draggedItem, Point startPosition, IUIItem dropItem, Point endPosition);

        /// <summary>
        /// Drags the dragged <see cref="IUIItem"/> and drops it on the drop <see cref="IUIItem"/>. 
        /// This can be used for any two UIItems  whether they are same application or different. 
        /// To drop items on desktop use Desktop class's Drop method. 
        /// White starts and ends the drag from center of the UIItems.
        /// Some drag and drop operation need to wait for application to process something while item is being dragged.
        /// This can be set but configuring DragStepCount property. This is by default set to 1.
        /// </summary>
        /// <param name="mouseButton"><see cref="MouseButton"/> to use for dragging</param>
        /// <param name="draggedItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="startPosition">Start Position <see cref="Point"/></param>
        /// <param name="dropItem"><see cref="IUIItem"/> to drop on</param>
        /// <param name="endPosition">End Position <see cref="Point"/></param>
        void DragAndDrop(MouseButton mouseButton, IUIItem draggedItem, Point startPosition, IUIItem dropItem,
            Point endPosition);

        /// <summary>
        /// Drag an <see cref="IUIItem"/> horizontally a specific distance
        /// </summary>
        /// <param name="uiItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="distance">Distance to drag</param>
        void DragHorizontally(IUIItem uiItem, int distance);

        /// <summary>
        /// Drag an <see cref="IUIItem"/> horizontally a specific distance
        /// </summary>
        /// <param name="mouseButton"><see cref="MouseButton"/> to use for dragging</param>
        /// <param name="uiItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="distance">Distance to drag</param>
        void DragHorizontally(MouseButton mouseButton, IUIItem uiItem, int distance);

        /// <summary>
        /// Drag an <see cref="IUIItem"/> vertically a specific distance
        /// </summary>
        /// <param name="uiItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="distance">Distance to drag</param>
        void DragVertically(IUIItem uiItem, int distance);

        /// <summary>
        /// Drag an <see cref="IUIItem"/> vertically a specific distance
        /// </summary>
        /// <param name="mouseButton"><see cref="MouseButton"/> to use for dragging</param>
        /// <param name="uiItem"><see cref="IUIItem"/> to drag</param>
        /// <param name="distance">Distance to drag</param>
        void DragVertically(MouseButton mouseButton, IUIItem uiItem, int distance);

        /// <summary>
        /// Move the Mouse Cursor to Point 0, 0
        /// </summary>
        void MoveOut();

        /// <summary>
        /// Move the Mouse Cursor to a certain <see cref="Point"/>
        /// </summary>
        /// <param name="position"><see cref="Point"/> where to position the Mouse Cursor to</param>
        void Move(Point position);
    }
}