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
	public partial class TransformToolProperties : UserControl
	{
		public Transform Tool { get; set; }
		public TransformToolProperties(Transform tool)
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
			var pos = Tool.Translate;
			xValue.Value = (decimal)pos.X;
			yValue.Value = (decimal)pos.Y;
			var scale = Tool.Scale;
			scaleXValue.Value = (decimal)scale.X;
			scaleYValue.Value = (decimal)scale.Y;
			var rot = Tool.Rotate;
			rotateValue.Value = (decimal)rot;
			changing = false;
		}

		private void value_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Translate = new PointF((float)xValue.Value, (float)yValue.Value);
			Tool.Scale = new PointF((float)scaleXValue.Value, (float)scaleYValue.Value);
			Tool.Rotate = (float)rotateValue.Value;
			Tool.Invalidate();
			changing = false;
		}

		private void revertBtn_Click(object sender, EventArgs e)
		{
			Tool.Discard();
		}
	}
}
