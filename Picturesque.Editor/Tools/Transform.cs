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
	public class Transform: Tool
	{
		public static float SizeCE = 6;

		public PointF Translate { get; set; }
		public PointF Scale { get; set; }
		public float Rotate { get; set; }
		public PointF RotateCenter { get; set; }

		protected ControlElement controlElement;
		protected Bitmap img;
		protected Selection prevSelection;

		public Transform(Project project) :
			base(project)
		{
			Panel = new TransformToolProperties(this);
		}

		public override void Init()
		{
			base.Init();
			if (Project.SelectedLayer is IEditable)
			{
				if (Project.Selection == null)
				{
					Project.SelectAll();
				}
				img = Project.GetSelection();
				var editableLayer = Project.SelectedLayer as IEditable;
				editableLayer.StartEditing();
				Project.DeleteArea();
				Translate = Project.GetSelectionBounds().Location;
				Scale = new PointF(1, 1);
				Rotate = 0; // degrees
				RotateCenter = new PointF(0.5f, 0.5f);
				prevSelection = Project.Selection;
				Project.ClearSelection();
			}
		}
		public override void Exit()
		{
			base.Exit();
			if (img != null)
			{
				Apply();
				img = null;
			}
		}

		public RectangleF GetRect()
		{
			var pos = Translate;
			var size = new SizeF(
				Math.Abs(img.Width * Scale.X), 
				Math.Abs(img.Height * Scale.Y)
			);
			if (Scale.X < 0)
			{
				pos = pos.Shift(size.Width, 0);
			}
			if (Scale.Y < 0)
			{
				pos = pos.Shift(0, size.Height);
			}
			return new RectangleF(pos, size);
		}

		public override void Paint(Graphics g)
		{
			var rect = GetRect();
			var rotTransf = RotateCenter.UnRelative(rect.Size);
			base.Paint(g);
			g.TranslateTransform(Translate.X, Translate.Y);
			g.TranslateTransform(rotTransf.X, rotTransf.Y);
			g.RotateTransform(Rotate);
			g.TranslateTransform(-rotTransf.X, -rotTransf.Y);
			g.ScaleTransform(Scale.X, Scale.Y);
			g.DrawImage(img, 0, 0);
			g.ScaleTransform(1/Scale.X, 1/Scale.Y);
			g.TranslateTransform(rotTransf.X, rotTransf.Y);
			g.RotateTransform(-Rotate);
			g.TranslateTransform(-rotTransf.X, -rotTransf.Y);
			g.TranslateTransform(-Translate.X, -Translate.Y);
			if (!toLayer)
			{
				PaintCEs(g);
			}
		}

		public void PaintCEs(Graphics g)
		{
			var rect = GetRect();
			var scale = g.Transform.Elements[0];
			using (var pen = new Pen(Color.Black, 1f / scale))
			{
				var brush = Brushes.White;
				var size = SizeCE / scale;
				var path = new GraphicsPath();
				path.AddRectangle(rect);
				Selection.PaintPath(g, path);
				for (var ce = ControlElement.SizeTopLeft; ce <= ControlElement.SizeLeft; ce++)
				{
					g.DrawFillSquare(pen, brush, PosCE(ce), size);
				}
				g.DrawFillCircle(pen, brush, PosCE(ControlElement.Center), size);
			}
		}

		private bool toLayer = false;
		protected virtual void paintToLayer()
		{
			if (Project.SelectedLayer is ImageLayer)
			{
				var imageLayer = Project.SelectedLayer as ImageLayer;
				using (var g = Graphics.FromImage(imageLayer.Image))
				{
					var pos = imageLayer.Position;
					toLayer = true;
					g.TranslateTransform(-pos.X, -pos.Y);
					Paint(g);
					g.TranslateTransform(pos.X, pos.Y);
					toLayer = false;
				}
			}
		}

		public PointF PosCE(ControlElement ce)
		{
			var rect = GetRect();
			switch (ce)
			{
				case ControlElement.Inside:
					return rect.Location;
				case ControlElement.Outside:
					return new PointF(0, 0);
				case ControlElement.Center:
					return rect.Location.Move(RotateCenter.UnRelative(rect.Size));
				case ControlElement.SizeTopLeft:
					return rect.Location;
				case ControlElement.SizeTopRight:
					return rect.Location.Move(rect.Size.Width, 0);
				case ControlElement.SizeBottomRight:
					return rect.Location.Move(rect.Size.Width, rect.Size.Height);
				case ControlElement.SizeBottomLeft:
					return rect.Location.Move(0, rect.Size.Height);
				case ControlElement.SizeTop:
					return rect.Location.Move(rect.Size.Width / 2, 0);
				case ControlElement.SizeRight:
					return rect.Location.Move(rect.Size.Width, rect.Size.Height / 2);
				case ControlElement.SizeBottom:
					return rect.Location.Move(rect.Size.Width / 2, rect.Size.Height);
				case ControlElement.SizeLeft:
					return rect.Location.Move(0, rect.Size.Height / 2);
				default:
					throw new ArgumentException();
			}
		}

		public ControlElement GetCE(PointF location)
		{
			for (var ce = ControlElement.Center; ce <= ControlElement.SizeLeft; ce++)
			{
				if (location.Capturing(PosCE(ce), SizeCE))
				{
					return ce;
				}
			}
			if (location.Capturing(GetRect()))
			{
				return ControlElement.Inside;
			}
			return ControlElement.Outside;
		}

		public void ActionCE(ControlElement ce, PointF from, PointF to)
		{
			var rect = GetRect();
			switch (ce)
			{
				case ControlElement.Inside:
					Translate = Translate.Move(to.Shift(from));
					break;
				case ControlElement.Outside:
					var c = PosCE(ControlElement.Center);
					var a = from.Shift(c);
					var b = to.Shift(c);
					var nA = a.Norm();
					var nB = b.Norm();
					var d = from.DistanceTo(to);
					var cos = (nA * nA + nB * nB - d * d) / (2 * nA * nB); // law of cosines
					var ang = Math.Acos(cos) * Math.Sign(a.Cross(b));
					Rotate += ang.ToDegrees();
					Rotate %= 360;
					break;
				case ControlElement.Center:
					RotateCenter = RotateCenter.Move(to.Shift(from).Relative(img.Size));
					break;
				case ControlElement.SizeTopLeft:
					Scale = Scale.Move(to.Shift(from).Factors(-1, -1).Relative(img.Size));
					Translate = Translate.Move(to.Shift(from).Factors(1, 1));
					break;
				case ControlElement.SizeTopRight:
					Scale = Scale.Move(to.Shift(from).Factors(1, -1).Relative(img.Size));
					Translate = Translate.Move(to.Shift(from).Factors(0, 1));
					break;
				case ControlElement.SizeBottomRight:
					Scale = Scale.Move(to.Shift(from).Relative(img.Size));
					break;
				case ControlElement.SizeBottomLeft:
					Scale = Scale.Move(to.Shift(from).Factors(-1, 1).Relative(img.Size));
					Translate = Translate.Move(to.Shift(from).Factors(1, 0));
					break;
				case ControlElement.SizeTop:
					Scale = Scale.Move(to.Shift(from).Factors(0, -1).Relative(img.Size));
					Translate = Translate.Move(to.Shift(from).Factors(0, 1));
					break;
				case ControlElement.SizeRight:
					Scale = Scale.Move(to.Shift(from).Factors(1, 0).Relative(img.Size));
					break;
				case ControlElement.SizeBottom:
					Scale = Scale.Move(to.Shift(from).Factors(0, 1).Relative(img.Size));
					break;
				case ControlElement.SizeLeft:
					Scale = Scale.Move(to.Shift(from).Factors(-1, 0).Relative(img.Size));
					Translate = Translate.Move(to.Shift(from).Factors(1, 0));
					break;
				default:
					break;
			}
			if (Math.Abs(Scale.X) < 0.0001)
			{
				Scale = new PointF(0.0001f, Scale.Y);
			}
			if (Math.Abs(Scale.Y) < 0.0001)
			{
				Scale = new PointF(Scale.X, 0.0001f);
			}
		}

		public override void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			controlElement = GetCE(location);
		}

		public override void OnMouseMove(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseMove(location, keys, buttons);
			if (mouseDown)
			{
				ActionCE(controlElement, mouseInit, location);
				mouseInit = location;
				Invalidate();
			}
			else
			{
				setCursor(GetCE(location));
			}
		}

		public override void OnMouseUp(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseUp(location, keys, buttons);
		}

		public override void OnKeyPress(Keys keys, MouseButtons buttons)
		{
			base.OnKeyPress(keys, buttons);
			if (keys.HasFlag(Keys.Up) || keys.HasFlag(Keys.Down) ||
				keys.HasFlag(Keys.Left) || keys.HasFlag(Keys.Right))
			{
				var dx = Translate.X;
				var dy = Translate.Y;
				switch (keys)
				{
					case Keys.Up:
						dy -= 1;
						break;
					case Keys.Down:
						dy += 1;
						break;
					case Keys.Left:
						dx -= 1;
						break;
					case Keys.Right:
						dx += 1;
						break;
				}
				Translate = new PointF(dx, dy);
				Invalidate();
			}
		}

		public override void Discard()
		{
			base.Discard();
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				editableLayer.DiscardChanges();
				Project.Selection = prevSelection;
				Init();
			}
		}

		public void Apply()
		{
			if (Project.SelectedLayer is IEditable)
			{
				var editableLayer = Project.SelectedLayer as IEditable;
				paintToLayer();
				editableLayer.ApplyChanges();
			}
		}

		private void setCursor(ControlElement ce)
		{
			changeCursor(getCursor(ce));
		}

		private Cursor getCursor(ControlElement ce)
		{
			switch (ce)
			{
				case ControlElement.Inside:
					return Cursors.SizeAll;
				case ControlElement.Outside:
					return Cursors.Default;
				case ControlElement.Center:
					return Cursors.NoMove2D;
				case ControlElement.SizeTopLeft:
					return Cursors.SizeNWSE;
				case ControlElement.SizeTopRight:
					return Cursors.SizeNESW;
				case ControlElement.SizeBottomRight:
					return Cursors.SizeNWSE;
				case ControlElement.SizeBottomLeft:
					return Cursors.SizeNESW;
				case ControlElement.SizeTop:
					return Cursors.SizeNS;
				case ControlElement.SizeRight:
					return Cursors.SizeWE;
				case ControlElement.SizeBottom:
					return Cursors.SizeNS;
				case ControlElement.SizeLeft:
					return Cursors.SizeWE;
				default:
					throw new ArgumentException();
			}
		}



		public enum ControlElement
		{
			Inside, Outside, Center,
			SizeTopLeft, SizeTopRight, SizeBottomRight, SizeBottomLeft,
			SizeTop, SizeRight, SizeBottom, SizeLeft
		}
	}
}
