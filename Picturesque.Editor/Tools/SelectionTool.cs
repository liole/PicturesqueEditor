using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Tools.Properties;
using System.Windows.Forms;

namespace Picturesque.Editor.Tools
{
	public class SelectionTool: Tool
	{
		public SelectionType Type { get; set; }
		private GraphicsPath path;

		public SelectionTool(Project project):
			base(project)
		{
			Type = SelectionType.Rectangle;
			Panel = new SelectionProperties(this);
		}

		public override void Paint(Graphics g)
		{
			base.Paint(g);
			if (mouseDown)
			{
				Selection.PaintPath(g, path);
			}
		}

		public override void OnMouseDown(PointF location, System.Windows.Forms.Keys keys, System.Windows.Forms.MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			path = new GraphicsPath();
			Project.ClearSelection();
		}

		public override void OnMouseMove(PointF location, System.Windows.Forms.Keys keys, System.Windows.Forms.MouseButtons buttons)
		{
			base.OnMouseMove(location, keys, buttons);
			if (mouseDown)
			{
				if (Type == SelectionType.FreeForm)
				{
					path.AddLine(mouseInit, location);
					mouseInit = location;
				}
				else
				{
					path.Dispose();
					path = new GraphicsPath();
					var pos = new PointF(
						Math.Min(mouseInit.X, location.X),
						Math.Min(mouseInit.Y, location.Y)
					);
					var size = new SizeF(
						Math.Abs(mouseInit.X - location.X),
						Math.Abs(mouseInit.Y - location.Y)
					);
					if (keys.HasFlag(Keys.Shift))
					{
						var min = Math.Min(size.Width, size.Height);
						if (location.X < mouseInit.X && size.Width > min)
						{
							pos.X += size.Width - min;
						}
						if (location.Y < mouseInit.Y && size.Height > min)
						{
							pos.Y += size.Height - min;
						}
						size = new SizeF(min, min);
					}
					switch (Type)
					{
						case SelectionType.Rectangle:
							path.AddRectangle(new RectangleF(pos, size));
							break;
						case SelectionType.Ellipse:
							path.AddEllipse(new RectangleF(pos, size));
							break;
					}
				}
				Invalidate();
			}
		}

		public override void OnMouseUp(PointF location, System.Windows.Forms.Keys keys, System.Windows.Forms.MouseButtons buttons)
		{
			if (mouseDown)
			{
				if (path.PointCount > 0)
				{
					path.CloseFigure();
					Project.CreateSelection(path);
				}
				else
				{
					Project.ClearSelection();
				}
			}
			base.OnMouseUp(location, keys, buttons);
		}
	}

	public enum SelectionType
	{
		Rectangle, Ellipse, FreeForm
	}
}
