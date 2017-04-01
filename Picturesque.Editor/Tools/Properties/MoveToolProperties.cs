using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Layers;

namespace Picturesque.Editor.Tools.Properties
{
	public partial class MoveToolProperties : UserControl
	{
		public MoveTool Tool { get; set; }
		public MoveToolProperties(MoveTool tool)
		{
			InitializeComponent();
			Tool = tool;
			Tool.Invalidated += Tool_Invalidated;
			Tool_Invalidated(Tool, null);
		}

		bool changing = false;
		void Tool_Invalidated(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			var layer = Tool.Project.SelectedLayer as IMovable;
			if (layer == null)
			{
				xValue.Enabled = false;
				yValue.Enabled = false;
				xValue.Value = 0;
				yValue.Value = 0;
			}
			else
			{
				xValue.Enabled = true;
				yValue.Enabled = true;
				var pos = Tool.GetCurrentPosition();
				xValue.Value = (decimal)pos.X;
				yValue.Value = (decimal)pos.Y;
			}
			changing = false;
		}

		private void value_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			var layer = Tool.Project.SelectedLayer as IMovable;
			if (layer != null)
			{
				layer.MoveTo(new PointF((float)xValue.Value, (float)yValue.Value));
			}
			changing = false;
		}
	}
}
