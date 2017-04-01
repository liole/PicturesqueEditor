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
	public partial class BrightnessContrastProperties : Form
	{
		public event EventHandler ValuesChanged;

		public BrightnessContrastProperties()
		{
			InitializeComponent();
		}

		public string Name
		{
			get { return nameTb.Text; }
			set { nameTb.Text = value; }
		}

		bool changing = false;

		public int Brightness
		{
			get { return (int)brightnessValue.Value; }
			set
			{
				if (changing) return;
				changing = true;
				brightnessValue.Value = value;
				brightnessTrackBar.Value = value;
				brightnessWarning.Visible = value > 128 || value < -128;
				changing = false;
			}
		}

		public int Contrast
		{
			get { return (int)contrastValue.Value; }
			set
			{
				if (changing) return;
				changing = true;
				contrastValue.Value = value;
				contrastTrackBar.Value = value;
				contrastWarning.Visible = value > 128 || value < -128;
				changing = false;
			}
		}

		private void brightnessValue_ValueChanged(object sender, EventArgs e)
		{
			Brightness = (int)brightnessValue.Value;
			if (ValuesChanged != null)
			{
				ValuesChanged(this, new EventArgs());
			}
		}

		private void brightnessTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Brightness = (int)brightnessTrackBar.Value;
			if (ValuesChanged != null)
			{
				ValuesChanged(this, new EventArgs());
			}
		}

		private void contrastValue_ValueChanged(object sender, EventArgs e)
		{
			Contrast = (int)contrastValue.Value;
			if (ValuesChanged != null)
			{
				ValuesChanged(this, new EventArgs());
			}
		}

		private void contrastTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Contrast = (int)contrastTrackBar.Value;
			if (ValuesChanged != null)
			{
				ValuesChanged(this, new EventArgs());
			}
		}
	}
}
