using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Picturesque.Editor
{
	public class Selection: IDisposable
	{
		public GraphicsPath Path { get; private set; }
		public event EventHandler Invalidated;

		public static float Size = 5;
		public static float Speed = 5;
		private float offset = 0;
		private int interval = 100;
		private Timer timer;

		public Selection(GraphicsPath path = null)
		{
			Path = path;
			if (path == null)
			{
				Path = new GraphicsPath();
			}
			timer = new Timer(tick, null, 0, interval);
		}

		private void tick(object state)
		{
			var delta = Speed * interval / 1000;
			offset -= delta;
			offset %= Size * 2;
			Invalidate();
		}

		public static void PaintPath(Graphics g, GraphicsPath path, float offset = 0)
		{
			var scale = g.Transform.Elements[0];
			using (var pen = new Pen(Color.Black, 1f / scale))
			{
				g.DrawPath(pen, path);
			}
			using (var pen = new Pen(Color.White, 1f / scale)
			{
				DashStyle = DashStyle.Custom,
				DashPattern = new[] { Size, Size },
				DashOffset = offset,
			})
			{
				g.DrawPath(pen, path);
			}
		}

		public void Paint(Graphics g)
		{
			PaintPath(g, Path, offset);
		}

		public void Invalidate()
		{
			if (Invalidated != null)
			{
				Invalidated(this, new EventArgs());
			}
		}

		public void Dispose()
		{
			timer.Dispose();
		}
	}
}
