using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Layers;
using System.Drawing.Drawing2D;

namespace Picturesque.Editor.Tools.Properties
{
	public partial class ShapeProperties : UserControl
	{
		public Shape Tool { get; set; }
		public ShapeProperties(Shape tool)
		{
			InitializeComponent();
			fillType.Items.AddRange(Enumerable.Repeat("", 54).ToArray());
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
			wValue.Value = (int)Tool.Width;
			strokeBox.Checked = Tool.Stroke;
			strokeType.SelectedIndex = (int)Tool.StrokeType;
			fillBox.Checked = Tool.Fill;
			fillType.SelectedIndex = Tool.FillType;
			changing = false;
		}

		private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Type = (ShapeType)typeBox.SelectedIndex;
			poygonInfo.Visible = Tool.Type == ShapeType.Polygon;
			changing = false;
		}

		private void wValue_ValueChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Width = (int)wValue.Value;
			changing = false;
		}

		private void fillBox_CheckedChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Fill = fillBox.Checked;
			fillType.Enabled = fillBox.Checked;
			changing = false;
		}

		private void strokeBox_CheckedChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.Stroke = strokeBox.Checked;
			strokeType.Enabled = strokeBox.Checked;
			wValue.Enabled = strokeBox.Checked;
			changing = false;
		}

		private void strokeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.StrokeType = (DashStyle)strokeType.SelectedIndex;
			changing = false;
		}

		private void fillType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (changing) return;
			changing = true;
			Tool.FillType = fillType.SelectedIndex;
			changing = false;
		}

		private void fillType_DrawItem(object sender, DrawItemEventArgs e)
		{
			var g = e.Graphics;
			var index = e.Index;
			var highlight = e.State.HasFlag(DrawItemState.Selected) && !e.State.HasFlag(DrawItemState.ComboBoxEdit);
			var backColor = highlight ? SystemColors.Highlight : SystemColors.Window;
			var color = highlight ? Color.White : Color.Black;
			e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
			if (index == -1) return;
			var brush = index == 0 
				? (Brush)new SolidBrush(color) 
				: (Brush)new HatchBrush((HatchStyle)(index - 1), color, Color.Transparent);
			g.FillRectangle(brush, e.Bounds);
		}
	}
}
