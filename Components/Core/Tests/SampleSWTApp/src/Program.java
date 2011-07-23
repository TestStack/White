import org.eclipse.swt.SWT;
import org.eclipse.swt.events.KeyAdapter;
import org.eclipse.swt.events.KeyEvent;
import org.eclipse.swt.events.MouseAdapter;
import org.eclipse.swt.events.MouseEvent;
import org.eclipse.swt.events.SelectionAdapter;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.events.ShellAdapter;
import org.eclipse.swt.events.ShellEvent;
import org.eclipse.swt.events.TreeAdapter;
import org.eclipse.swt.events.TreeEvent;
import org.eclipse.swt.graphics.Point;
import org.eclipse.swt.graphics.Rectangle;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Combo;
import org.eclipse.swt.widgets.Composite;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Event;
import org.eclipse.swt.widgets.Label;
import org.eclipse.swt.widgets.Link;
import org.eclipse.swt.widgets.List;
import org.eclipse.swt.widgets.Listener;
import org.eclipse.swt.widgets.Menu;
import org.eclipse.swt.widgets.MenuItem;
import org.eclipse.swt.widgets.ProgressBar;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.swt.widgets.TabFolder;
import org.eclipse.swt.widgets.TabItem;
import org.eclipse.swt.widgets.Text;
import org.eclipse.swt.widgets.Tree;
import org.eclipse.swt.widgets.TreeItem;

public class Program {
	private static Display display;
	private Shell shell = null;

	private Label label = null;

	private Text textBox = null;

	private Button button = null;

	private Label result = null;

	private Button chequeBox = null;

	private Button checkBoxLaunchedModalWindow = null;

	private Label komboBoxLabel = null;

	private Combo komboBox = null;
	private Label modalComboBoxLabel = null;
	private Combo comboBoxLaunchingModalWindow = null;
	private Button radioButton1 = null;
	private Button radioButton2 = null;
	private Link linkLabel = null;
	private Link linkLaunchesModalWindow = null;
	private Label labelForListBox = null;
	private List chequedListBox = null;
	private Label progressBarLabel = null;
	private ProgressBar progressBar = null;
	private Label labelForTree = null;
	private Tree ped = null;
	private Button addNode = null;
	private Button launchModal = null;
	private Menu menuBar = null;
	private Label seasonsLabel = null;
	private TabFolder seasons = null;
	private Label listBoxLabel = null;
	private List listBox = null;
	private Label listBoxWithVScrollBarLabel = null;
	private List listBoxWithVScrollBar = null;
	private Label treeViewLaunchesModalLabel = null;
	private Tree treeViewLaunchesModal = null;
	private Label dynamicTextBoxLabel = null;
	private Button addDynamicControl = null;
	private Button disableControls = null;

	private Text textBox1 = null;
	private Label labelForTextBoxWithHScroll;

	private void createSShell() {
		shell = new Shell();
		shell.setText("Form1");
		shell.setSize(new Point(1065, 431));
		menuBar = new Menu(shell, SWT.BAR);
		addSubMenus();
		label = new Label(shell, SWT.None);
		label.setBounds(new Rectangle(32, 21, 60, 13));
		label.setText("textBox");
		textBox = new Text(shell, SWT.BORDER);
		textBox.setBounds(new Rectangle(100, 20, 76, 19));
		textBox.addKeyListener(new KeyAdapter() {
			public void keyReleased(KeyEvent e) {
				super.keyReleased(e);
				result.setText("Text changed");
			}
		});
		button = new Button(shell, SWT.None);
		button.setBounds(new Rectangle(202, 18, 78, 23));
		button.setText("buton");
		result = new Label(shell, SWT.None);
		result.setBounds(new Rectangle(303, 23, 88, 13));
		result.setText("result");
		chequeBox = new Button(shell, SWT.CHECK);
		chequeBox.setBounds(new Rectangle(409, 23, 82, 13));
		chequeBox.setText("chequeBox");
		checkBoxLaunchedModalWindow = new Button(shell, SWT.CHECK);
		checkBoxLaunchedModalWindow.setBounds(new Rectangle(514, 26, 179, 16));
		checkBoxLaunchedModalWindow.setText("checkBoxLaunchedModalWindow");
		komboBoxLabel = new Label(shell, SWT.None);
		komboBoxLabel.setBounds(new Rectangle(717, 21, 62, 18));
		komboBoxLabel.setText("komboBox");
		createKomboBox();
		shell.setMenuBar(menuBar);
		modalComboBoxLabel = new Label(shell, SWT.None);
		modalComboBoxLabel.setBounds(new Rectangle(22, 68, 178, 13));
		modalComboBoxLabel.setText("comboBoxLaunchingModalWindow");
		createComboBoxLaunchingModalWindow();
		radioButton1 = new Button(shell, SWT.RADIO);
		radioButton1.setBounds(new Rectangle(338, 64, 91, 16));
		radioButton1.setText("radioButton1");
		radioButton2 = new Button(shell, SWT.RADIO);
		radioButton2.setBounds(new Rectangle(451, 64, 111, 16));
		radioButton2.setText("radioButton2");
		linkLabel = new Link(shell, SWT.None);
		linkLabel.setBounds(new Rectangle(565, 65, 55, 13));
		linkLabel.setText("<a>linkLabel</a>");
		linkLaunchesModalWindow = new Link(shell, SWT.None);
		linkLaunchesModalWindow.setBounds(new Rectangle(636, 66, 141, 13));
		linkLaunchesModalWindow.setText("<a>linkLaunchesModalWindow</a>");
		labelForListBox = new Label(shell, SWT.None);
		labelForListBox.setBounds(new Rectangle(803, 65, 81, 13));
		labelForListBox.setText("chequedListBox");
		chequedListBox = new List(shell, SWT.None);
		chequedListBox.setBounds(new Rectangle(889, 65, 67, 64));
		progressBarLabel = new Label(shell, SWT.None);
		progressBarLabel.setBounds(new Rectangle(23, 125, 61, 13));
		progressBarLabel.setText("progressBar");
		progressBar = new ProgressBar(shell, SWT.None);
		progressBar.setBounds(new Rectangle(96, 124, 162, 18));
		progressBar.setSelection(50);
		labelForTree = new Label(shell, SWT.None);
		labelForTree.setBounds(new Rectangle(284, 123, 54, 13));
		labelForTree.setText("ped");
		createTree();

		addNode = new Button(shell, SWT.None);
		addNode.setText("addNode");
		addNode.setBounds(new Rectangle(439, 120, 56, 23));
		launchModal = new Button(shell, SWT.None);
		launchModal.setBounds(new Rectangle(924, 16, 75, 23));
		launchModal.setText("launchModal");
		seasonsLabel = new Label(shell, SWT.None);
		seasonsLabel.setBounds(new Rectangle(18, 221, 54, 13));
		seasonsLabel.setText("seasons");
		createSeasons();
		listBoxLabel = new Label(shell, SWT.NONE);
		listBoxLabel.setBounds(new Rectangle(525, 123, 25, 13));
		listBoxLabel.setText("listBox");
		listBox = new List(shell, SWT.NONE);
		listBox.setBounds(new Rectangle(566, 123, 67, 64));
		listBoxWithVScrollBarLabel = new Label(shell, SWT.NONE);
		listBoxWithVScrollBarLabel.setBounds(new Rectangle(654, 124, 78, 13));
		listBoxWithVScrollBarLabel.setText("listBoxWithVScrollBar");
		createListBoxWithVScrollBar();
		treeViewLaunchesModalLabel = new Label(shell, SWT.NONE);
		treeViewLaunchesModalLabel.setBounds(new Rectangle(315, 229, 121, 13));
		treeViewLaunchesModalLabel.setText("treeViewLaunchesModal");
		createTreeWhichLaunchesModal();
		disableControls = new Button(shell, SWT.NONE);
		disableControls.setBounds(new Rectangle(863, 147, 131, 23));

		addPopupMenuToListBox();
		addPopupMenuToVScrollBarListBox();
		launchModal.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				ModalWindow.Show(display);
			}
		});
		addNode.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				TreeItem treeItem = new TreeItem(ped, SWT.None);
				treeItem.setText("DynamicNode");
			}
		});

		chequedListBox.add("Bill Gates");
		chequedListBox.add("Narayan Murthy");

		linkLabel.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				result.setText("Link label clicked");
			}
		});
		linkLaunchesModalWindow.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				ModalWindow.Show(display);
			}
		});
		disableControls.setText("disableControls");
		disableControls.addMouseListener(new MouseAdapter(){
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				textBox.setEnabled(false);
				komboBox.setEnabled(false);
			}
		});

		createTextBoxWithHScroll();
		createTextBoxWithVScroll();
		createDynamicControlItems();
	}

	private void createDynamicControlItems() {
		dynamicTextBoxLabel = new Label(shell, SWT.NONE);
		dynamicTextBoxLabel.setBounds(new Rectangle(556, 350, 86, 13));
		dynamicTextBoxLabel.setText("dynamicTextBox");
		addDynamicControl = new Button(shell, SWT.NONE);
		addDynamicControl.setBounds(new Rectangle(803, 350, 119, 23));
		addDynamicControl.setText("addDynamicControl");

		addDynamicControl.addMouseListener(new MouseAdapter(){
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				Text dynamicTextBox = new Text(shell, SWT.None);
				Rectangle bounds = dynamicTextBoxLabel.getBounds();
				dynamicTextBox.setBounds(bounds.x + bounds.width + 5, bounds.y, 20, 10);
				dynamicTextBox.setSize(20, 10);
			}
		});
	}

	private void createListBoxWithVScrollBar() {
		listBoxWithVScrollBar = new List(shell, SWT.NONE | SWT.V_SCROLL);
		listBoxWithVScrollBar.add("1");
		listBoxWithVScrollBar.add("2");
		listBoxWithVScrollBar.add("3");
		listBoxWithVScrollBar.add("4");
		listBoxWithVScrollBar.add("5");
		listBoxWithVScrollBar.add("6");
		listBoxWithVScrollBar.add("7");
		listBoxWithVScrollBar.add("8");
		listBoxWithVScrollBar.add("9");
		listBoxWithVScrollBar.add("10");
		listBoxWithVScrollBar.add("11");
		listBoxWithVScrollBar.add("12");
		listBoxWithVScrollBar.add("13");
		listBoxWithVScrollBar.add("14");
		listBoxWithVScrollBar.add("15");
		listBoxWithVScrollBar.add("16");
		listBoxWithVScrollBar.add("17");
		listBoxWithVScrollBar.add("18");
		listBoxWithVScrollBar.add("0");
		listBoxWithVScrollBar.setBounds(new Rectangle(754, 123, 67, 64));
	}

	private void createTextBoxWithHScroll(){
		labelForTextBoxWithHScroll = new Label(shell, SWT.None);
		labelForTextBoxWithHScroll.setBounds(new Rectangle(540, 200, 60, 13));
		labelForTextBoxWithHScroll.setText("textBox1");
		textBox1 = new Text(shell, SWT.BORDER | SWT.MULTI | SWT.H_SCROLL);
		textBox1.setBounds(new Rectangle(640, 200, 76, 50));
		textBox1.setText("fdsfhkjsdfhdskjfhdsfhsfkhfkdshfdshfk");
		textBox1.addKeyListener(new KeyAdapter() {
			public void keyReleased(KeyEvent e) {
				super.keyReleased(e);
			}
		});
	}

	private void createTextBoxWithVScroll(){
		labelForListBox = new Label(shell, SWT.None);
		labelForListBox.setBounds(new Rectangle(740, 200, 60, 13));
		labelForListBox.setText("multilineTextBox");
		textBox1 = new Text(shell, SWT.BORDER | SWT.MULTI | SWT.V_SCROLL | SWT.WRAP);
		textBox1.setBounds(new Rectangle(840, 200, 76, 50));
		textBox1.addKeyListener(new KeyAdapter() {
			public void keyReleased(KeyEvent e) {
				super.keyReleased(e);
			}
		});
	}

	private void createTreeWhichLaunchesModal() {
		treeViewLaunchesModal = new Tree(shell, SWT.NONE);
		treeViewLaunchesModal.setBounds(new Rectangle(452, 228, 80, 80));

		TreeItem rootItem = new TreeItem(treeViewLaunchesModal, SWT.None);
		rootItem.setText("Root");
		TreeItem childItem = new TreeItem(rootItem, SWT.None);
		childItem.setText("Child");
		treeViewLaunchesModal.addTreeListener(new TreeAdapter() {
			public void treeExpanded(TreeEvent e) {
				super.treeExpanded(e);
				ModalWindow.Show(display);
			}
		});
	}

	private void addPopupMenuToVScrollBarListBox() {
		final Menu menu = new Menu(shell, SWT.POP_UP);

		MenuItem rootItem = new MenuItem(menu, SWT.CASCADE);
		rootItem.setText("Root");

		Menu rootSubMenu = new Menu(rootItem);
		rootItem.setMenu(rootSubMenu);
		MenuItem level1Item = new MenuItem(rootSubMenu, SWT.CASCADE);
		level1Item.setText("Level1");

		Menu level1SubMenu = new Menu(level1Item);
		level1Item.setMenu(level1SubMenu);
		MenuItem level2Item = new MenuItem(level1SubMenu, SWT.PUSH);
		level2Item.setText("Level2");

		level2Item.addSelectionListener(new SelectionAdapter(){
			public void widgetSelected(SelectionEvent e) {
				super.widgetSelected(e);
				result.setText("Level2Click");
			}
		});

		listBoxWithVScrollBar.addListener(SWT.MenuDetect, new Listener() {
			public void handleEvent(Event event) {
				menu.setLocation(event.x, event.y);
				menu.setVisible(true);
			}
		});
	}

	private void addPopupMenuToListBox() {
		listBox.addListener(SWT.MenuDetect, new Listener() {
			public void handleEvent(Event event) {
				Menu menu = new Menu(shell, SWT.POP_UP | SWT.CASCADE);
				MenuItem item = new MenuItem(menu, SWT.PUSH);
				item.setText("Show Films");
				item.addListener(SWT.Selection, new Listener() {
					public void handleEvent(Event e) {
						result.setText("All good films");
					}
				});
				menu.setLocation(event.x, event.y);
				menu.setVisible(true);
				while (!menu.isDisposed() && menu.isVisible()) {
					if (!display.readAndDispatch())
						display.sleep();
				}
				menu.dispose();
			}
		});
	}

	private void addSubMenus() {
		MenuItem fileMenu = new MenuItem(menuBar, SWT.CASCADE);
		fileMenu.setText("File");

		Menu fileSubMenu = new Menu(shell, SWT.DROP_DOWN);
		fileMenu.setMenu(fileSubMenu);
		MenuItem clickMeMenu = new MenuItem(fileSubMenu, SWT.PUSH);
		clickMeMenu.setText("Click Me");
		MenuItem clickMeTooMenu = new MenuItem(fileSubMenu, SWT.CASCADE);
		clickMeTooMenu.setText("Click Me Too");

		Menu clickMeTooSubMenu = new Menu(clickMeTooMenu);
		clickMeTooMenu.setMenu(clickMeTooSubMenu);
		MenuItem leafMenu = new MenuItem(clickMeTooSubMenu, SWT.PUSH);
		leafMenu.setText("Leaf");
		clickMeMenu.addSelectionListener(new SelectionAdapter() {
			public void widgetSelected(SelectionEvent e) {
				super.widgetSelected(e);
				result.setText("Click Me Clicked");
			}
		});
	}

	private void createTree() {
		ped = new Tree(shell, SWT.None);
		ped.setBounds(new Rectangle(343, 122, 80, 80));
		TreeItem rootItem = new TreeItem(ped, SWT.None);
		rootItem.setText("Root");
		TreeItem mainItem = new TreeItem(ped, SWT.None);
		mainItem.setText("Main");

		TreeItem childItem = new TreeItem(rootItem, SWT.None);
		childItem.setText("Child");
		TreeItem grandChildItem = new TreeItem(childItem, SWT.None);
		grandChildItem.setText("Grand Child");
	}

	private void createKomboBox() {
		komboBox = new Combo(shell, SWT.None);
		komboBox.setBounds(new Rectangle(793, 19, 92, 21));
		komboBox.add("Arundhati Roy");
		komboBox.add("Noam Chomsky");
		komboBox.add("1");
		komboBox.add("2");
		komboBox.add("3");
		komboBox.add("4");
		komboBox.add("5");
		komboBox.add("6");
		komboBox.add("7");
		komboBox.add("ReallyReallyLongTextHere");
	}

	private void createComboBoxLaunchingModalWindow() {
		comboBoxLaunchingModalWindow = new Combo(shell, SWT.None);
		comboBoxLaunchingModalWindow.setBounds(new Rectangle(212, 64, 92, 21));
		comboBoxLaunchingModalWindow.add("Arundhati Roy");
		comboBoxLaunchingModalWindow
				.addSelectionListener(new SelectionAdapter() {
					public void widgetSelected(SelectionEvent e) {
						super.widgetSelected(e);
						ModalWindow.Show(display);
					}
				});
	}

	private void createSeasons() {
		seasons = new TabFolder(shell, SWT.None);
		seasons.setBounds(new Rectangle(89, 223, 189, 77));
		TabItem tabItem = new TabItem(seasons, SWT.None);
		tabItem.setText("Spring");
		tabItem = new TabItem(seasons, SWT.None);
		tabItem.setText("Autumn");
		tabItem = new TabItem(seasons, SWT.None);
		tabItem.setText("Winter");

		Composite composite = new Composite(seasons, SWT.None);

		Label duplicateBoxLabel1 = new Label(composite, SWT.None);
		duplicateBoxLabel1.setBounds(0, 0, 50, 20);
		duplicateBoxLabel1.setText("duplicateBox");
		Text duplicateBox1 = new Text(composite, SWT.None);
		duplicateBox1.setBounds(60, 0, 120, 20);

		Label duplicateBoxLabel2 = new Label(composite, SWT.None);
		duplicateBoxLabel2.setBounds(0, 30, 50, 50);
		duplicateBoxLabel2.setText("duplicateBox");
		Text duplicateBox2 = new Text(composite, SWT.None);
		duplicateBox2.setBounds(60, 30, 120, 50);

		tabItem.setControl(composite);
	}

	public static void main(final String[] args) {
		Program program = new Program();
		display = new Display();
		program.createSShell();

		program.hookEvents();

		program.shell.open();
		program.shell.addShellListener(new ShellAdapter() {
			public void shellClosed(ShellEvent e) {
				if (args.length == 1 && args[0].equals("ModalAtClose")) ModalWindow.Show(display);
				super.shellClosed(e);
			}
		});

		while (!program.shell.isDisposed()) {
			if (!display.readAndDispatch())
				display.sleep();
		}

		display.dispose();
	}

	private void hookEvents() {
		button.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				result.setText("Button Clicked");
			}
		});

		checkBoxLaunchedModalWindow.addMouseListener(new MouseAdapter() {
			public void mouseDown(MouseEvent e) {
				super.mouseDown(e);
				ModalWindow.Show(display);
			}
		});
	}
}
