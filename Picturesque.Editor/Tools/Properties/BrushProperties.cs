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
	public partial class BrushProperties : UserControl
	{
		public FuzzyBrush Tool { get; set; }
		public BrushProperties(FuzzyBrush tool)
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
			fValue.Value = (decimal)Tool.Fuzziness;
			fTrackBar.Value = (int)(Tool.Fuzziness * 100);
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

		private void fValue_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			fTrackBar.Value = (int)(fValue.Value * 100);
			Tool.Fuzziness = (float)fValue.Value;
			changing = false;
		}

		private void fTrackBar_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			fValue.Value = (decimal)fTrackBar.Value/100;
			Tool.Fuzziness = (float)fTrackBar.Value/100;
			changing = false;
		}
	}
}
