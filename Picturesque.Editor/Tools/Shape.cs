using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Layers;
using Picturesque.Editor.Tools.Properties;
using System.Drawing.Drawing2D;

namespace Picturesque.Editor.Tools
{
	public class Shape: Tool, IDoubleColorTool
	{
		public ShapeType Type { get; set; }

		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }
		public float Width { get; set; }
		public bool Fill { get; set; }
		public bool Stroke { get; set; }
		public DashStyle StrokeType { get; set; }
		public /*HatchStyle*/ int FillType { get; set; }

		protected Bitmap img;
		private GraphicsPath path;
		private GraphicsPath workingPath;
		private PointF currMouse;

		public Shape(Project project, Color foreColor, Color backColor, float widthP = 2) :
			base(project)
		{
			ForeColor = foreColor;
			BackColor = backColor;
			Width = widthP;
			Fill = false;
			Stroke = true;
			StrokeType = DashStyle.Solid;
			Type = ShapeType.Rectangle;
			changeCursor(Cursors.Cross);
			Panel = new ShapeProperties(this);
		}

		public override void Paint(Graphics g)
		{
			base.Paint(g);
			if (path == null)
			{
				return;
			}
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
			if (Fill)
			{
				using (var brush = getBrush(g))
				{
					g.FillPath(brush, path);
				}
			}
			if (Stroke)
			{
				using (var pen = getPen(g))
				{
					pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
					pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
					if (Type == ShapeType.FreeForm)
					{
						pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
					}
					g.DrawPath(pen, path);
				}
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
			return new Pen(ForeColor, Width)
			{ 
				DashStyle = StrokeType
			};
		}
		protected virtual Brush getBrush(Graphics g)
		{
			if (FillType == 0)
			{
				return new SolidBrush(BackColor);
			}
			else
			{
				return new HatchBrush((HatchStyle)(FillType - 1), BackColor, Color.Transparent);
			}
		}

		public override void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				img = editableLayer.StartEditing();
				path = new GraphicsPath();
				workingPath = path.Clone() as GraphicsPath;
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
					if (Type == ShapeType.FreeForm)
					{
						workingPath.AddLine(mouseInit, location);
						path.Dispose();
						path = workingPath.Clone() as GraphicsPath;
						path.CloseFigure();
						mouseInit = location;
					}
					else if (Type == ShapeType.Polygon)
					{
						path.Dispose();
						path = workingPath.Clone() as GraphicsPath;
						path.AddLine(mouseInit, location);
						path.CloseFigure();
						currMouse = location;
					}
					else
					{
						path.Dispose();
						path = new GraphicsPath();
						if (Type == ShapeType.Line)
						{
							path.AddLine(mouseInit, location);
						}
						else
						{
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
								case ShapeType.Rectangle:
									path.AddRectangle(new RectangleF(pos, size));
									break;
								case ShapeType.Ellipse:
									path.AddEllipse(new RectangleF(pos, size));
									break;
							}
						}
					}
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
					path.CloseFigure();
					paintToLayer();
					path = null;
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
			else if (keys == Keys.Space && Type == ShapeType.Polygon)
			{
				workingPath.AddLine(mouseInit, currMouse);
				mouseInit = currMouse;
			}
			else
			{
				return;
			}
		}

		public override void Discard()
		{
			base.Discard();
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				path = null;
				editableLayer.DiscardChanges();
			}
		}
	}

	public enum ShapeType
	{
		Rectangle, Ellipse, Line, Polygon, FreeForm
	}
}
