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
	public partial class CloneStampProperties : UserControl
	{
		public CloneStamp Tool { get; set; }
		public CloneStampProperties(CloneStamp tool)
		{
			InitializeComponent();
			Tool = tool;
			Tool.Invalidated += Tool_Invalidated;
			Tool.CursorChanged += Tool_Invalidated;
			Tool_Invalidated(Tool, null);
		}

		bool changing = false;
		void Tool_Invalidated(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			wValue.Value = (int)Tool.Width;
			wTrackBar.Value = (int)Tool.Width;
			xValue.Value = (decimal)Tool.Shift.X;
			yValue.Value = (decimal)Tool.Shift.Y;
			changing = false;
		}

		private void wWalue_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			wTrackBar.Value = (int)wValue.Value;
			Tool.Width = (int)wValue.Value;
			changing = false;
		}

		private void wTrackBar_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			wValue.Value = wTrackBar.Value;
			Tool.Width = wTrackBar.Value;
			changing = false;
		}

		private void xValue_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Shift = new PointF((float)xValue.Value, Tool.Shift.Y);
			changing = false;
		}

		private void yValue_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Shift = new PointF(Tool.Shift.X, (float)yValue.Value);
			changing = false;
		}
	}
}
