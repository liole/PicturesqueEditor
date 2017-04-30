using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers;
using System.Windows.Forms;
using Picturesque.Editor.Tools.Properties;

namespace Picturesque.Editor.Tools
{
	public class CloneStamp: Pencil
	{
		public static Color PickCursorBorder = Color.Blue;
		public static Keys PickKey = Keys.Control;

		public PointF Shift { get; set; }
		private bool picking = false;
		private bool locating = false;

		public CloneStamp(Project project, float widthP = 25):
			base(project, Color.Transparent, widthP)
		{
			Shift = new PointF(0, 0);
			Panel = new CloneStampProperties(this);
		}

		protected override Pen getPen(Graphics gp)
		{
			if (img != null)
			{
				var brush = new TextureBrush(img);
				brush.TranslateTransform(Shift.X, Shift.Y);
				brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
				return new Pen(brush, Width);
			}
			else
			{
				return new Pen(Color, Width);
			}
		}

		public override void OnMouseDown(PointF location, System.Windows.Forms.Keys keys, System.Windows.Forms.MouseButtons buttons)
		{
			if (!picking)
			{
				if (locating)
				{
					Shift = location.Shift(Shift);
					locating = false;
				}
				base.OnMouseDown(location, keys, buttons);
			}
		}

		public override void OnMouseUp(PointF location, System.Windows.Forms.Keys keys, System.Windows.Forms.MouseButtons buttons)
		{
			if (picking)
			{
				Shift = location;
				picking = false;
				locating = true;
				setCursor();
			}
			else
			{
				base.OnMouseUp(location, keys, buttons);
			}
		}

		public override void OnKeyPress(Keys keys, MouseButtons buttons)
		{
			base.OnKeyPress(keys, buttons);
			picking = keys.HasFlag(PickKey);
			setCursor();
		}

		public override System.Windows.Forms.Cursor GetCursor(float scale)
		{
			if (picking)
			{
				var cb = CursorBorder;
				CursorBorder = PickCursorBorder;
				var cursor = base.GetCursor(scale);
				CursorBorder = cb;
				return cursor;
			}
			else
			{
				return base.GetCursor(scale);
			}
		}
	}
}
