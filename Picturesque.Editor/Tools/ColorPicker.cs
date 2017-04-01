using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor.Tools
{
	public class ColorPicker: Tool, IDoubleColorTool
	{
		public static Color CursorBorder = Color.DarkGray;

		public event EventHandler ColorChanged;

		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }

		private bool main;

		public ColorPicker(Project project, Color foreColor, Color backColor) :
			base(project)
		{
			ForeColor = foreColor;
			BackColor = backColor;
			changeCursor();
		}

		private Color getSolidColor(PointF location)
		{
			var bmp = Project.Image;
			var loc = new Point((int)location.X, (int)location.Y);
			var color = bmp.GetPixel(loc.X, loc.Y);
			return Color.FromArgb(255, color);
		}

		public override void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			main = buttons != MouseButtons.Right;
			changeCursor();
		}

		public override void OnMouseMove(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseMove(location, keys, buttons);
			var bmp = Project.Image;
			if (location.X >= 0 && location.Y >= 0 &&
				location.X < bmp.Width && location.Y < bmp.Height)
			{
				mouseInit = location;
			}
			changeCursor();
		}

		public override void OnMouseUp(PointF location, Keys keys, MouseButtons buttons)
		{
			if (mouseDown)
			{
				if (main)
				{
					ForeColor = getSolidColor(location);
				}
				else
				{
					BackColor = getSolidColor(location);
				}
				if (ColorChanged != null)
				{
					ColorChanged(this, new EventArgs());
				}
			}
			base.OnMouseUp(location, keys, buttons);
		}

		public override void Discard()
		{
			base.Discard();
			changeCursor();
		}

		public override Cursor GetCursor(float scale)
		{
			if (!mouseDown)
			{
				return Cursors.Cross;
			}
			var size = 100;
			var width = 10;
			var cur = new Bitmap(size, size);
			var gc = Graphics.FromImage(cur);
			gc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			using (var pen = new Pen(CursorBorder, width*2))
			{
				gc.DrawEllipse(pen, width*2, width*2, size - width * 4, size - width * 4);
			}
			var color = main ? ForeColor : BackColor;
			using (var pen = new Pen(color, width))
			{
				gc.DrawArc(pen, width * 2, width * 2, size - width * 4, size - width * 4, 0, 180);
			}
			using (var pen = new Pen(getSolidColor(mouseInit), width))
			{
				gc.DrawArc(pen, width * 2, width * 2, size - width * 4, size - width * 4, 160, 220);
			}
			using (var pen = new Pen(Color.Black, 1))
			{
				var d = 6;
				gc.DrawEllipse(pen, size / 2 - d / 2, size / 2 - d / 2, d, d);
				gc.DrawLine(pen, size / 2 - d * 3 / 2, size / 2, size / 2 - d / 2, size / 2);
				gc.DrawLine(pen, size / 2 + d * 3 / 2, size / 2, size / 2 + d / 2, size / 2);
				gc.DrawLine(pen, size / 2, size / 2 - d * 3 / 2, size / 2, size / 2 - d / 2);
				gc.DrawLine(pen, size / 2, size / 2 + d * 3 / 2, size / 2, size / 2 + d / 2);
			}
			return new Cursor(cur.GetHicon());
		}
	}
}
