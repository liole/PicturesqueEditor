using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor.Layers.Properties
{
	public partial class HueProperties : Form
	{
		public event EventHandler ValuesChanged;

		public HueProperties()
		{
			InitializeComponent();
		}

		public string Name
		{
			get { return nameTb.Text; }
			set { nameTb.Text = value; }
		}

		public bool Colorize
		{
			get { return colorizeChkBox.Checked; }
			set { colorizeChkBox.Checked = value; }
		}

		bool changing = false;

		public int Hue
		{
			get { return (int)hueValue.Value; }
			set
			{
				if (changing) return;
				changing = true;
				hueValue.Value = value;
				hueTrackBar.Value = value;
				changing = false;
			}
		}

		public int Saturation
		{
			get { return (int)saturationValue.Value; }
			set
			{
				if (changing) return;
				changing = true;
				saturationValue.Value = value;
				saturationTrackBar.Value = value;
				changing = false;
			}
		}

		public int Lightness
		{
			get { return (int)lightnessValue.Value; }
			set
			{
				if (changing) return;
				changing = true;
				lightnessValue.Value = value;
				lightnessTrackBar.Value = value;
				changing = false;
			}
		}

		private void hueValue_ValueChanged(object sender, EventArgs e)
		{
			Hue = (int)hueValue.Value;
			update();
		}

		private void hueTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Hue = (int)hueTrackBar.Value;
			update();
		}

		private void saturationValue_ValueChanged(object sender, EventArgs e)
		{
			Saturation = (int)saturationValue.Value;
			update();
		}

		private void saturationTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Saturation = (int)saturationTrackBar.Value;
			update();
		}

		private void lightnessValue_ValueChanged(object sender, EventArgs e)
		{
			Lightness = (int)lightnessValue.Value;
			update();
		}

		private void lightnessTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Lightness = (int)lightnessTrackBar.Value;
			update();
		}

		public void UpdateHueRange()
		{
			if (colorizeChkBox.Checked)
			{
				hueValue.Minimum = 0;
				hueValue.Maximum = 360;
				hueTrackBar.Minimum = 0;
				hueTrackBar.Maximum = 360;
			}
			else
			{
				hueValue.Minimum = -180;
				hueValue.Maximum = 180;
				hueTrackBar.Minimum = -180;
				hueTrackBar.Maximum = 180;
			}
		}

		private void colorizeChkBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateHueRange();
			update();
		}

		private void update()
		{
			if (autoUpdate.Checked)
			{
				if (ValuesChanged != null)
				{
					ValuesChanged(this, new EventArgs());
				}
			}
		}

		private void autoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			update();
		}
	}
}
