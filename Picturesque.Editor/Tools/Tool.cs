using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor.Tools
{
	public class Tool
	{
		public Project Project { get; set; }
		public event EventHandler CursorChanged;
		public event EventHandler Invalidated;

		public Control Panel { get; protected set; }

		protected bool mouseDown = false;
		protected PointF mouseInit;

		public Tool(Project project)
		{
			Project = project;
			changeCursor(Cursors.Default);
		}

		public virtual void Paint(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		}

		public virtual void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			mouseDown = true;
			mouseInit = location;
		}
		public virtual void OnMouseUp(PointF location, Keys keys, MouseButtons buttons)
		{
			mouseDown = false;
		}
		public virtual void OnMouseMove(PointF location, Keys keys, MouseButtons buttons)
		{

		}
		public virtual void OnKeyPress(Keys keys, MouseButtons buttons)
		{
			if (keys == Keys.Escape)
			{
				Discard();
			}
		}

		public virtual void Discard()
		{
			mouseDown = false;
		}

		public void Invalidate()
		{
			if (Invalidated != null)
			{
				Invalidated(this, new EventArgs());
			}
		}

		private Cursor cursor = Cursors.Default;
		protected void changeCursor(Cursor newCursor = null)
		{
			cursor = newCursor;
			if (CursorChanged != null)
			{
				CursorChanged(this, new EventArgs());
			}
		}

		public virtual Cursor GetCursor(float scale)
		{
			return cursor;
		}

		public virtual void Init()
		{
		}
		public virtual void Exit()
		{
		}
	}

	public interface IColorTool
	{
		Color Color { get; set; }
	}
	public interface IDoubleColorTool
	{
		Color ForeColor { get; set; }
		Color BackColor { get; set; }
	}
}
