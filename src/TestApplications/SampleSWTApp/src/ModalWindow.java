import org.eclipse.swt.SWT;
import org.eclipse.swt.events.MouseAdapter;
import org.eclipse.swt.events.MouseEvent;
import org.eclipse.swt.graphics.Rectangle;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;

public class ModalWindow {
	private static Shell modalShell;

	public static void Show(Display display) {
		modalShell = new Shell(display, SWT.APPLICATION_MODAL | SWT.DIALOG_TRIM);
		modalShell.setText("ModalForm");
		Button okButton = new Button(modalShell, SWT.NONE);
		okButton.setBounds(new Rectangle(100, 100, 178, 123));
		okButton.setText("ok");
		okButton.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				modalShell.dispose();
			}
		});
		modalShell.open();
		
		while (!modalShell.isDisposed()) {
			if (!display.readAndDispatch())
				display.sleep();
		}
	}
}
