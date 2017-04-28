using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor
{
	public partial class NewProjectDialog : Form
	{
		public int WidthValue
		{
			get { return (int)widthValue.Value; }
			set { widthValue.Value = value; }
		}

		public int HeightValue
		{
			get { return (int)heightValue.Value; }
			set { heightValue.Value = value; }
		}

		public bool UseBackground
		{
			get { return backgrundChb.Checked; }
			set { backgrundChb.Checked = value; }
		}

		public Color BackgrounColor
		{
			get { return colorBox.BackColor; }
			set { colorBox.BackColor = value; }
		}

		public NewProjectDialog()
		{
			InitializeComponent();
		}

		private void colorBtn_Click(object sender, EventArgs e)
		{
			var colorDialog = new ColorDialog()
			{
				Color = colorBox.BackColor
			};
			if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				colorBox.BackColor = colorDialog.Color;
			}
		}

		private void backgrundChb_CheckedChanged(object sender, EventArgs e)
		{
			colorBtn.Enabled = backgrundChb.Checked;
		}
	}
}
