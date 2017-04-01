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
	public partial class SelectionProperties : UserControl
	{
		public SelectionTool Tool { get; set; }
		public SelectionProperties(SelectionTool tool)
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
			typeBox.SelectedIndex = (int)Tool.Type;
			changing = false;
		}

		private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Type = (SelectionType)typeBox.SelectedIndex;
			changing = false;
		}
	}
}
