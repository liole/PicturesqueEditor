using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Tools;
using System.Drawing.Imaging;
using Picturesque.Editor.Layers;
using System.Drawing.Drawing2D;
using System.IO;

namespace Picturesque.Editor
{
	public partial class MainForm : Form
	{
		public int ASMargin = 25;
		public float MaxScale = 7.5f;
		public float MinScale = 1f / 7.5f;
		private float scale = 1.0f;
		public Project Project { get; set; }
		public Tool Tool { get; set; }
		public string File { get; set; }
		private bool changed = false;

		private NewProjectDialog newProjectDialog;

		public MainForm()
		{
			InitializeComponent();
			newProjectDialog = new NewProjectDialog();
			canvas.MouseWheel += canvas_MouseWheel;
			canvasContainer.MouseWheel += canvas_MouseWheel;
			setTrasparentBackground();

			//newToolStripMenuItem.PerformClick();
			SetProject(new Project(512, 512));
			updatePixelInfo(new PointF(-1, -1));
			canvasContainer.AutoScrollMargin = new Size(ASMargin, ASMargin);

			propertiesPanel.AutoSize = true;

			File = null;
			saveProjectDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openProjectDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveImageDialog.InitialDirectory = Directory.GetCurrentDirectory();

			zoomValue.Maximum = (int)(MaxScale * 100);
			zoomValue.Minimum = (int)(MinScale * 100);
			zoomBar.Minimum = (int)(Math.Log(MinScale, 10) * 10 - 1);
			zoomBar.Maximum = (int)(Math.Log(MaxScale, 10) * 10 + 1);

		}

#region user32.dll
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		private const int WM_HSCROLL = 276;
		private const int SB_LINELEFT = 0;
		private const int SB_LINERIGHT = 1;
		private const int WM_SETREDRAW = 11;

		public static void SuspendDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
		}

		public static void ResumeDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
			parent.Refresh();
		}

#endregion

		private bool changingScale = false;
		public new float Scale
		{
			get { return scale; }
			set
			{
				if (changingScale) return;
				changingScale = true;
				scale = value;
				if (scale > MaxScale)
				{
					scale = MaxScale;
				}
				if (scale < MinScale)
				{
					scale = MinScale;
				}
				repositionCanvas();
				if (Tool != null)
				{
					canvas.Cursor = Tool.GetCursor(Scale);
				}
				zoomValue.Value = (int)(scale * 100);
				zoomBar.Value = (int)(Math.Log(scale, 10) * 10);
				changingScale = false;
			}
		}

		public Color MyForeColor
		{
			get { return Color.FromArgb(alphaTrackBar.Value, foreColor.BackColor); }
		}
		public Color MyBackColor
		{
			get { return backColor.BackColor; }
		}

		private void canvas_Paint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			g.ScaleTransform(Scale, Scale);
			if (Tool != null)
			{
				Tool.Paint(g);
			}
			if (Project.Selection != null)
			{
				g.Clip = new Region();
				Project.Selection.Paint(g);
			}
			g.ScaleTransform(1/Scale, 1/Scale);
		}

		private void setTrasparentBackground()
		{
			var grid = new Bitmap(20, 20);
			var g = Graphics.FromImage(grid);
			g.FillRectangle(Brushes.LightGray, 0, 0, 10, 10);
			g.FillRectangle(Brushes.LightGray, 10, 10, 10, 10);
			canvas.BackgroundImage = grid;
		}

		void repositionCanvas()
		{
			canvas.Size = new Size(
				(int)(canvas.Image.Width * Scale),
				(int)(canvas.Image.Height * Scale)
			);

			if (canvas.Width < canvasContainer.ClientSize.Width)
			{
				canvasContainer.HorizontalScroll.Value = 0;
			}
			if (canvas.Height < canvasContainer.ClientSize.Height)
			{
				canvasContainer.VerticalScroll.Value = 0;
			}
			canvas.Location = new Point(
				canvasContainer.ClientSize.Width > canvas.Width ?
				(canvasContainer.ClientSize.Width - canvas.Width) / 2 : ASMargin,
				canvasContainer.ClientSize.Height > canvas.Height ?
				(canvasContainer.ClientSize.Height - canvas.Height) / 2 : ASMargin
			);
			canvas.Invalidate();
		}

		private void canvasContainer_Resize(object sender, EventArgs e)
		{
			repositionCanvas();
		}

		void canvas_MouseWheel(object sender, MouseEventArgs e)
		{
			HandledMouseEventArgs ee = (HandledMouseEventArgs)e;
			if (ModifierKeys == Keys.Control)
			{
				Scale += (float)e.Delta / SystemInformation.MouseWheelScrollDelta / 10;

				ee.Handled = true;
			}
			if (ModifierKeys == Keys.Shift)
			{
				var direction = e.Delta > 0 ? SB_LINELEFT : SB_LINERIGHT;
				SendMessage(canvasContainer.Handle, WM_HSCROLL, (IntPtr)direction, IntPtr.Zero);

				ee.Handled = true;
			}
		}

		public void SetProject(Project proj)
		{
			if (Project != null)
			{
				Project.Invalidated -= Project_Invalidated;
				Project.LayersListChanged -= Project_LayersListChanged;
				Project.SelectedLayerChanged -= Project_SelectedLayerChanged;
				Project.SelectionChanged -= Project_SelectionChanged;
			}
			Project = proj;
			Project.Invalidated += Project_Invalidated;
			Project.LayersListChanged += Project_LayersListChanged;
			Project.SelectedLayerChanged += Project_SelectedLayerChanged;
			Project.SelectionChanged += Project_SelectionChanged;
			Project.Invalidate();
			canvas.Image = Project.Image;
			Project_LayersListChanged(this, null);
			repositionCanvas();
			changed = false;
			UpdateTitle();
			tools = new Dictionary<string, Tools.Tool>();
			moveBtn.PerformClick();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TryExit())
			{
				if (newProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					var proj = new Project(
						newProjectDialog.WidthValue,
						newProjectDialog.HeightValue
					);
					if (newProjectDialog.UseBackground)
					{
						var bg = proj.AddLayer(newProjectDialog.BackgrounColor);
						bg.Name = "Background";
					}
					proj.MoveUp();
					SetProject(proj);
				}
			}
			//SetProject(new Project(512, 512));
			//Project = new Project(512, 512);
			//Project.Invalidated += Project_Invalidated;
			//Project.LayersListChanged += Project_LayersListChanged;
			//Project.SelectedLayerChanged += Project_SelectedLayerChanged;
			//var newLayer = Project.AddLayer() as ImageLayer;
			//var img = newLayer.Image;
			//using (var g = Graphics.FromImage(img))
			//{
			//	g.DrawImage(new Bitmap(@"C:\Users\Oleg\Desktop\parrot200.jpg"), 0, 0);
			//}
			//Project.SelectedLayer = newLayer;
			//Project.Invalidate();
			//canvas.Image = Project.Image;
			//Project_LayersListChanged(this, null);
			//repositionCanvas();
		}

		void Project_SelectedLayerChanged(object sender, EventArgs e)
		{
			foreach(LayerListItem layer in layersList.Controls)
			{
				layer.Selected = layer.Model == Project.SelectedLayer;
			}
			upLayerBtn.Enabled = Project.SelectedLayer != Project.Layers.Last();
			moveUpToolStripMenuItem.Enabled = upLayerBtn.Enabled;
			moveUpToolStripMenuItem1.Enabled = upLayerBtn.Enabled;
			downLayerBtn.Enabled = Project.SelectedLayer != Project.Layers.First();
			moveDownToolStripMenuItem.Enabled = downLayerBtn.Enabled;
			moveDownToolStripMenuItem1.Enabled = downLayerBtn.Enabled;
		}

		void Project_SelectionChanged(object sender, EventArgs e)
		{
			copyToolStripMenuItem.Enabled = Project.Selection != null;
			copyBitmapToolStripMenuItem.Enabled = Project.Selection != null;
			cutToolStripMenuItem.Enabled = Project.Selection != null;
		}

		void Project_LayersListChanged(object sender, EventArgs e)
		{
			layersList.SuspendLayout();
			SuspendDrawing(layersList);
			layersList.Controls.Clear();
			foreach(ILayer layer in Project.Layers.AsEnumerable().Reverse())
			{
				var layerListItem = new LayerListItem()
				{
					Model = layer,
					Selected = Project.SelectedLayer == layer
				};
				layerListItem.Click += layerListItem_Click;
				layersList.Controls.Add(layerListItem);
			}
			layersList_Resize(layersList, new EventArgs());
			ResumeDrawing(layersList);
			layersList.ResumeLayout();
			deleteLayerBtn.Enabled = Project.Layers.Count > 1;
			removeToolStripMenuItem.Enabled = deleteLayerBtn.Enabled;
			removeToolStripMenuItem1.Enabled = deleteLayerBtn.Enabled;
			upLayerBtn.Enabled = Project.SelectedLayer != Project.Layers.Last();
			moveUpToolStripMenuItem.Enabled = upLayerBtn.Enabled;
			moveUpToolStripMenuItem1.Enabled = upLayerBtn.Enabled;
			downLayerBtn.Enabled = Project.SelectedLayer != Project.Layers.First();
			moveDownToolStripMenuItem.Enabled = downLayerBtn.Enabled;
			moveDownToolStripMenuItem1.Enabled = downLayerBtn.Enabled;
		}

		void layerListItem_Click(object sender, EventArgs e)
		{
			var item = sender as LayerListItem;
			Project.SelectedLayer = item.Model;
		}

		void Project_Invalidated(object sender, EventArgs e)
		{
			changed = true;
			UpdateTitle();
			canvas.Invalidate();
		}

		private void canvas_MouseDown(object sender, MouseEventArgs e)
		{
			canvas.Focus();
			var loc = e.Location.Unscale(Scale);
			if (Tool != null)
			{
				Tool.OnMouseDown(loc, ModifierKeys, MouseButtons);
			}
		}

		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			var loc = e.Location.Unscale(Scale);
			if (Tool != null)
			{
				Tool.OnMouseMove(loc, ModifierKeys, MouseButtons);
			}
			updatePixelInfo(loc);
		}

		private void canvas_MouseUp(object sender, MouseEventArgs e)
		{
			var loc = e.Location.Unscale(Scale);
			if (Tool != null)
			{
				Tool.OnMouseUp(loc, ModifierKeys, MouseButtons);
			}
		}

		private void canvas_MouseLeave(object sender, EventArgs e)
		{
			updatePixelInfo(new PointF(-1, -1));
		}

		private const Keys ARROW_KEYS = Keys.Up | Keys.Down | Keys.Left | Keys.Right;
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (Tool != null)
			{
				Tool.OnKeyPress(keyData, MouseButtons);
			}
			switch (keyData)
			{
				case Keys.Up:
				case Keys.Left:
				case Keys.Down:
				case Keys.Right:
					return true;
				default:
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		private void updatePixelInfo(PointF location)
		{
			var loc = new Point((int)location.X, (int)location.Y);
			var bmp = canvas.Image as Bitmap;
			if (loc.X >= 0 && loc.Y >= 0 &&
				loc.X < bmp.Width && loc.Y < bmp.Height)
			{
				var cl = bmp.GetPixel(loc.X, loc.Y);
				posXLbl.Text	= String.Format("X: {0}", loc.X);
				posYLbl.Text	= String.Format("Y: {0}", loc.Y);
				clRedLbl.Text	= String.Format("R: {0}", cl.R);
				clGreenLbl.Text = String.Format("G: {0}", cl.G);
				clBlueLbl.Text	= String.Format("B: {0}", cl.B);
				clAlphaLbl.Text = String.Format("A: {0}", cl.A);
			}
			else
			{
				posXLbl.Text	= "X:";
				posYLbl.Text	= "Y:";
				clRedLbl.Text	= "R:";
				clGreenLbl.Text = "G:";
				clBlueLbl.Text	= "B:";
				clAlphaLbl.Text = "A:";
			}
		}

		private Dictionary<string, Tool> tools = new Dictionary<string,Tool>();
		private void setTool(string name)
		{
			if (Tool != null)
			{
				Tool.Exit();
			}
			if (tools.ContainsKey(name))
			{
				Tool = tools[name];
			}
			else
			{
				switch (name)
				{
					case "move":
						Tool = new MoveTool(Project);
						break;
					case "pencil":
						Tool = new Pencil(Project, MyForeColor, 1);
						break;
					case "eraser":
						Tool = new Eraser(Project, 10);
						break;
					case "picker":
						Tool = new ColorPicker(Project, MyForeColor, MyBackColor);
						(Tool as ColorPicker).ColorChanged += colorPicker_ColorChanged;
						break;
					case "selection":
						Tool = new SelectionTool(Project);
						break;
					case "transform":
						Tool = new Transform(Project);
						break;
					case "shape":
						Tool = new Shape(Project, MyForeColor, MyBackColor, 2);
						break;
					default:
						throw new ArgumentException();
				}
				Tool.Invalidated += Tool_Invalidated;
				Tool.CursorChanged += Tool_CursorChanged;
				tools[name] = Tool;
			}
			Tool.Init();
			updateToolColor();
			Tool_CursorChanged(this, null);
			setToolPanel();
		}

		void setToolPanel()
		{
			propertiesPanel.SuspendLayout();
			propertiesPanel.Controls.Clear();
			if (Tool != null && Tool.Panel != null)
			{
				propertiesPanel.Controls.Add(Tool.Panel);
				Tool.Invalidate();
			}
			propertiesPanel.ResumeLayout();
		}

		void Tool_CursorChanged(object sender, EventArgs e)
		{
			canvas.Cursor = Tool.GetCursor(Scale);
		}

		void Tool_Invalidated(object sender, EventArgs e)
		{
			canvas.Invalidate();
		}

		void colorPicker_ColorChanged(object sender, EventArgs e)
		{
			var cp = Tool as ColorPicker;
			foreColor.BackColor = cp.ForeColor;
			backColor.BackColor = cp.BackColor;
		}

		private void toolBtn_Clicked(object sender, EventArgs e)
		{
			var ctrl = sender as dynamic;
			setTool(ctrl.Tag as string);
			if (!(sender is RadioButton))
			{
				toolbarLayout.Controls.OfType<RadioButton>().Where(c => c.Tag == ctrl.Tag).First().Checked = true;
			}
			mapToolMenu();
		}

		private void mapToolMenu()
		{
			for (int i = 0; i < toolbarLayout.Controls.Count; ++i)
			{
				(toolsToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked =
					(toolbarLayout.Controls[i] as RadioButton).Checked;
			}
		}

		private void toolbarSizeBtn_Click(object sender, EventArgs e)
		{
			var more = toolbar.Width < 48;
			toolbar.Width = more ? 64 : 32;
			toolbarSizeBtn.Text = more ? "<<" : ">>";
			wideToolboxToolStripMenuItem.Checked = more;
		}

		private void layersList_Resize(object sender, EventArgs e)
		{
			foreach(LayerListItem item in layersList.Controls)
			{
				item.Width = layersList.ClientSize.Width;
			}
		}

		private void colorPanel_Paint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			using (var pen = new Pen(Color.White, 3))
			{
				g.DrawRectangle(pen, 1, 1, 47, 47);
			}
			using (var pen = new Pen(Color.Black, 1))
			{
				g.DrawRectangle(pen, 1, 1, 47, 47);
			}
		}

		private void updateToolColor()
		{
			if (Tool is IColorTool)
			{
				var ct = Tool as IColorTool;
				ct.Color = MyForeColor;
			}
			if (Tool is IDoubleColorTool)
			{
				var dct = Tool as IDoubleColorTool;
				dct.ForeColor = MyForeColor;
				dct.BackColor = MyBackColor;
			}
		}

		private void colorPanel_Click(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			var cd = new ColorDialog()
			{
				Color = panel.BackColor,
				FullOpen = true
			};
			if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				panel.BackColor = cd.Color;
			}
			updateToolColor();
		}

		private void switchBtn_Click(object sender, EventArgs e)
		{
			var bc = MyBackColor;
			backColor.BackColor = MyForeColor;
			foreColor.BackColor = bc;
			updateToolColor();
		}

		private void alphaTrackBar_ValueChanged(object sender, EventArgs e)
		{
			foreAlphaLbl.Text = alphaTrackBar.Value.ToString();
			updateToolColor();
		}

		private void createLayerBtn_Click(object sender, EventArgs e)
		{
			Project.SelectedLayer = Project.AddLayer();
		}

		private void deleteLayerBtn_Click(object sender, EventArgs e)
		{
			Project.RemoveLayer();
		}

		private void upLayerBtn_Click(object sender, EventArgs e)
		{
			Project.MoveUp();
		}

		private void downLayerBtn_Click(object sender, EventArgs e)
		{
			Project.MoveDown();
		}

		private void layerPropertiesBtn_Click(object sender, EventArgs e)
		{
			Project.SelectedLayer.ShowProperties();
		}

		private void mergeLayersBtn_Click(object sender, EventArgs e)
		{
			Project.Flaten();
		}

		private void adjustmentBtn_Click(object sender, EventArgs e)
		{
			adjustmentMenu.Show(adjustmentBtn, 0, adjustmentBtn.Height);
		}

		private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project.SelectedLayer = Project.AddLayer(
				new BrightnessContrastLayer(Project.GetMask()));
			Project.SelectedLayer.ShowProperties();
		}

		private void hueSaturationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project.SelectedLayer = Project.AddLayer(
				new HueLayer(Project.GetMask()));
			Project.SelectedLayer.ShowProperties();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var bmp = Project.GetSelection();
			MemoryStream ms = new MemoryStream();
			bmp.Save(ms, ImageFormat.Png);
			IDataObject dataObject = new DataObject();
			dataObject.SetData("PNG", false, ms);
			Clipboard.SetDataObject(dataObject, true);
			pasteToolStripMenuItem.Enabled = true;
		}

		private void copyBitmapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var bmp = Project.GetSelection();
			Clipboard.SetImage(bmp);
			pasteToolStripMenuItem.Enabled = true;
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var bmp = GraphicsUtils.GetImageFromClipboard() as Bitmap;
			if (bmp != null)
			{
				Project.SelectedLayer = Project.AddLayer(
					new ImageLayer(bmp)
				);
				Project.SelectedLayer.Name = "Layer from clipboard";
				Project.ClearSelection();
			}
		}

		private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project.ClearSelection();
		}

		private void deleteAreaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project.DeleteArea();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			copyToolStripMenuItem_Click(sender, e);
			deleteAreaToolStripMenuItem_Click(sender, e);
		}

		private void extendBtn_Click(object sender, EventArgs e)
		{
			Project.ExtendLayer();
		}

		private void clipBtn_Click(object sender, EventArgs e)
		{
			Project.ClipLayer();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Project.SelectAll();
		}

		private void save()
		{
			if (System.IO.File.Exists(File))
			{
				System.IO.File.Delete(File);
			}
			Project.Save(File);
			changed = false;
			UpdateTitle();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (File == null)
			{
				saveAsToolStripMenuItem_Click(sender, e);
			}
			else
			{
				save();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				File = saveProjectDialog.FileName;
				save();
			}
		}

		public void open(string filename)
		{
			if (System.IO.Path.GetExtension(filename) == ".pep")
			{
				File = filename;
				SetProject(Project.Open(File));
			}
			else
			{
				File = null;
				var image = new Bitmap(filename);
				var dpi = Program.GetDPI();
				image.SetResolution(dpi, dpi);
				SetProject(new Project(image));
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TryExit())
			{
				if (openProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					open(openProjectDialog.FileName);
				}
			}
		}

		public void UpdateTitle()
		{
			var name = "New Project";
			if (File != null)
			{
				name = File;
			}
			if (changed)
			{
				name += "*";
			}
			Text = String.Format("{0} - Picturesque Editor", name);
		}

		public bool TryExit()
		{
			if (!changed)
			{
				return true;
			}
			else
			{
				var res = MessageBox.Show(
					"Do you want to save changes to your project?",
					"Confirm operation",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Question
				);
				if (res == System.Windows.Forms.DialogResult.Yes)
				{
					saveToolStripMenuItem_Click(this, null);
					if (File == null)
					{
						return false;
					}
				}
				if (res == System.Windows.Forms.DialogResult.Cancel)
				{
					return false;
				}
				return true;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				switch(saveImageDialog.FilterIndex)
				{
					case 1:
						Project.Image.Save(saveImageDialog.FileName, ImageFormat.Png);
						break;
					case 2:
						Project.Image.Save(saveImageDialog.FileName, ImageFormat.Jpeg);
						break;
					case 3:
						Project.Image.Save(saveImageDialog.FileName, ImageFormat.Bmp);
						break;
					case 4:
						Project.Image.Save(saveImageDialog.FileName, ImageFormat.Gif);
						break;
				}
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!TryExit())
			{
				e.Cancel = true;
			}
		}

		private bool drag = false;
		private void canvasContainer_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				drag = true;
				canvasContainer.Invalidate();
			}
		}

		private void canvasContainer_DragLeave(object sender, EventArgs e)
		{
			drag = false;
			canvasContainer.Invalidate();
		}

		private void canvasContainer_Paint(object sender, PaintEventArgs e)
		{
			if (drag)
			{
				var g = e.Graphics;
				using (var pen = new Pen(Color.White, 20)
				{
					DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
				})
				{
					g.DrawRectangle(pen, canvasContainer.ClientRectangle);
				}
			}
		}

		private void canvasContainer_DragDrop(object sender, DragEventArgs e)
		{
			drag = false;
			canvasContainer.Invalidate();
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			string file = files.First();
			if (TryExit())
			{
				open(file);
			}
		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			copyToolStripMenuItem.Enabled = Project.Selection != null;
			copyBitmapToolStripMenuItem.Enabled = Project.Selection != null;
			cutToolStripMenuItem.Enabled = Project.Selection != null;
			pasteToolStripMenuItem.Enabled = GraphicsUtils.GetImageFromClipboard() is Bitmap;
		}

		private void layersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			layersPanel.Visible = layersToolStripMenuItem.Checked;
			layersSplitter.Visible = layersToolStripMenuItem.Checked;
		}

		private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolbar.Visible = toolboxToolStripMenuItem.Checked;
			toolbarSplitter.Visible = toolboxToolStripMenuItem.Checked;
		}

		private void sidePanelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			sidebar.Visible = sidePanelToolStripMenuItem.Checked;
			sidebarSplitter.Visible = sidePanelToolStripMenuItem.Checked;
		}

		private void toolpropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			propertiesPanel.Visible = toolpropertiesToolStripMenuItem.Checked;
			propertiesSplitter.Visible = toolpropertiesToolStripMenuItem.Checked;
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Scale = 0.5f;
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Scale = 1;
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Scale = 2;
		}

		private void fitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Scale = Math.Min(
				(float)(canvasContainer.Width - 2 * ASMargin) / Project.Image.Width,
				(float)(canvasContainer.Height - 2 * ASMargin) / Project.Image.Height
			);
		}

		private void zoomValue_ValueChanged(object sender, EventArgs e)
		{
			Scale = (float)zoomValue.Value / 100;
		}

		private void zoomBar_ValueChanged(object sender, EventArgs e)
		{
			Scale = (float)Math.Pow(10, (float)zoomBar.Value / 10);
		}

		private void layerMenu_Opening(object sender, CancelEventArgs e)
		{
			var screen = new Point(
				layerMenu.Left,
				layerMenu.Top
			);
			var point = layersList.PointToClient(screen);
			var child = layersList.GetChildAtPoint(point);
			layerListItem_Click(child, e);
		}

	}
}
