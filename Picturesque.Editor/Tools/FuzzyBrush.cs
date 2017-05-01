using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers;
using Picturesque.Editor.Tools.Properties;

namespace Picturesque.Editor.Tools
{
	public class FuzzyBrush: Pencil
	{
		public float Fuzziness { get; set; }

		public FuzzyBrush(Project project, float fuzziness = 0.5f, float widthP = 50):
			base(project, Color.Transparent, widthP)
		{
			Fuzziness = fuzziness;
			Panel = new BrushProperties(this);
		}

		protected override void drawLines(Graphics g, Pen pen)
		{
			if (points.Count > 1)
			{
				g.DrawFuzzyLines(pen, Fuzziness, points.ToArray());
			}
			else if (points.Count == 1)
			{
				var c = points.First();
				g.FillFuzzyCircle(pen.Brush, Fuzziness, c.X, c.Y, Width);
			}
		}
	}
}
