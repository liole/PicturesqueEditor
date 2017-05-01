using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Layers;
using Picturesque.Editor.Tools.Properties;

namespace Picturesque.Editor.Tools
{
	public class Pencil: Tool, IColorTool
	{
		public static Color CursorBorder = Color.Black;

		public Color Color { get; set; }
		private float width { get; set; }

		protected Bitmap img;
		protected List<PointF> points;

		public Pencil(Project project, Color color, float widthP = 1) :
			base(project)
		{
			Color = color;
			Width = widthP;
			Project.SelectedLayerChanged += Project_SelectedLayerChanged;
			setCursor();
			points = new List<PointF>();
			Panel = new PencilProperties(this);
		}

		public float Width
		{
			get { return width; }
			set
			{
				width = value;
				setCursor();
			}
		}

		public override void Paint(Graphics g)
		{
			base.Paint(g);
			if (Project.Selection != null)
			{
				g.Clip = new Region(Project.Selection.Path);
			}
			if (mouseDown)
			{
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					var rect = new RectangleF(movableLayer.Position, img.Size);
					var newClip = new Region(rect);
					newClip.Intersect(g.Clip);
					g.Clip = newClip;
				}
			}
			using (var pen = getPen(g))
			{
				pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
				pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
				pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
				drawLines(g, pen);
			}
		}

		protected virtual void drawLines(Graphics g, Pen pen)
		{
			if (points.Count > 1)
			{
				g.DrawLines(pen, points.ToArray());
			}
			else if (points.Count == 1)
			{
				var c = points.First();
				g.FillEllipse(pen.Brush, c.X - Width / 2, c.Y - Width / 2, Width, Width);
			}
		}

		protected virtual void paintToLayer()
		{
			using (var g = Graphics.FromImage(img))
			{
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					var pos = movableLayer.Position;
					g.TranslateTransform(-pos.X, -pos.Y);
				}
				Paint(g);
			}
		}

		protected virtual Pen getPen(Graphics g)
		{
			return new Pen(Color, Width);
		}

		void Project_SelectedLayerChanged(object sender, EventArgs e)
		{
			setCursor();
		}

		public override void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				img = editableLayer.StartEditing();
				points.Add(location);
				Invalidate();
			}
		}

		public override void OnMouseMove(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseMove(location, keys, buttons);
			if (mouseDown)
			{
				if (Project.SelectedLayer is IEditable)
				{
					points.Add(location);
					Invalidate();
				}
			}
		}

		public override void OnMouseUp(PointF location, Keys keys, MouseButtons buttons)
		{
			if (mouseDown)
			{
				if (Project.SelectedLayer is IEditable)
				{
					var editableLayer = Project.SelectedLayer as IEditable;

					base.OnMouseUp(location, keys, buttons);
					paintToLayer();
					points.Clear();
					editableLayer.ApplyChanges();
				}
			}
		}

		public override void OnKeyPress(Keys keys, MouseButtons buttons)
		{
			base.OnKeyPress(keys, buttons);
			if (keys == Keys.OemOpenBrackets && Width > 1)
			{
				Width -= 1;
			}
			else if (keys == Keys.OemCloseBrackets && Width < 200)
			{
				Width += 1;
			}
			else
			{
				return;
			}
			changeCursor();
		}

		public override void Discard()
		{
			base.Discard();
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				points.Clear();
				editableLayer.DiscardChanges();
				img = null;
			}
		}

		public override Cursor GetCursor(float scale)
		{
			var def = base.GetCursor(scale);
			if (def != null)
			{
				return def;
			}
			if (Width < 10)
			{
				return Cursors.Cross;
			}
			var size = (int)(Width * scale);
			var cur = new Bitmap(size + 2, size + 2);
			var gc = Graphics.FromImage(cur);
			gc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			using (var pen = new Pen(Color.White, 2))
			{
				gc.DrawEllipse(pen, 1, 1, size, size);
			}
			using (var pen = new Pen(CursorBorder, 1))
			{
				gc.DrawEllipse(pen, 1, 1, size, size);
			}
			return new Cursor(cur.GetHicon());
		}

		protected void setCursor()
		{
			if (Project.SelectedLayer is IEditable)
			{
				changeCursor();
			}
			else
			{
				changeCursor(Cursors.No);
			}
		}
	}
}
