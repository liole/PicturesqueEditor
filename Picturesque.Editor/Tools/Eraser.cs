using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers;

namespace Picturesque.Editor.Tools
{
	public class Eraser: Pencil
	{
		public Eraser(Project project, float widthP):
			base(project, Color.Transparent, widthP)
		{
		}

		protected override Pen getPen(Graphics gp)
		{
			var scale = gp.Transform.Elements[0];
			if (mouseDown)
			{
				var grid = new Bitmap(20, 20);
				var g = Graphics.FromImage(grid);
				g.FillRectangle(Brushes.LightGray, 0, 0, 10, 10);
				g.FillRectangle(Brushes.LightGray, 10, 10, 10, 10);
				g.FillRectangle(Brushes.White, 0, 10, 10, 10);
				g.FillRectangle(Brushes.White, 10, 00, 10, 10);
				var brush = new TextureBrush(grid);
				brush.ScaleTransform(1 / scale, 1 / scale);
				return new Pen(brush, Width);
			}
			else
			{
				return new Pen(Color.Transparent, Width);
			}
		}

		protected override void paintToLayer()
		{
			using (var g = Graphics.FromImage(img))
			{
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					var pos = movableLayer.Position;
					g.TranslateTransform(-pos.X, -pos.Y);
				}
				g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
				Paint(g);
				g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			}
		}
	}
}
