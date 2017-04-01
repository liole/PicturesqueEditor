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
	public partial class ImageLayerProperties : Form
	{
		public event EventHandler ColorMatrixChanged;

		public ImageLayerProperties()
		{
			InitializeComponent();
		}

		public string Name
		{
			get { return nameTb.Text; }
			set { nameTb.Text = value; }
		}

		public ColorMatrix ColorMatrix
		{
			get
			{
				var m = new float[][]{ 
					new float[] {ch(rr), ch(gr), ch(br), 0, 0},
					new float[] {ch(rg), ch(gg), ch(bg), 0, 0},
					new float[] {ch(rb), ch(gb), ch(bb), 0, 0},
					new float[] {     0,      0,      0, 0, 0}, 
					new float[] {ch(rw), ch(gw), ch(bw), 0, 1}
				};
				average(m, 0, ra);
				average(m, 1, ga);
				average(m, 2, ba);
				var cm = new ColorMatrix(m);
				if (clipOpacity.Checked)
				{
					cm.Matrix43 = Opacity;
				}
				else
				{
					cm.Matrix33 = Opacity;
				}
				return cm;
			}
			set
			{
				if (value.Matrix33 == 0)
				{
					Opacity = value.Matrix43;
					clipOpacity.Checked = true;
				}
				else
				{
					Opacity = value.Matrix33;
					clipOpacity.Checked = false;
				}
				rr.Checked = value.Matrix00 != 0;
				rg.Checked = value.Matrix10 != 0;
				rb.Checked = value.Matrix20 != 0;
				rw.Checked = value.Matrix40 != 0;
				ra.Checked = value.Matrix00 + value.Matrix10 + value.Matrix20 + value.Matrix40 < 1.1;

				gr.Checked = value.Matrix01 != 0;
				gg.Checked = value.Matrix11 != 0;
				gb.Checked = value.Matrix21 != 0;
				gw.Checked = value.Matrix41 != 0;
				ga.Checked = value.Matrix01 + value.Matrix11 + value.Matrix21 + value.Matrix41 < 1.1;

				br.Checked = value.Matrix02 != 0;
				bg.Checked = value.Matrix12 != 0;
				bb.Checked = value.Matrix22 != 0;
				bw.Checked = value.Matrix42 != 0;
				ba.Checked = value.Matrix02 + value.Matrix12 + value.Matrix22 + value.Matrix42 < 1.1;
			}
		}

		private bool fromTb = false;
		private bool fromUd = false;
		public float Opacity
		{
			get { return (float)opacityTrackBar.Value / 100; }
			set
			{
				var val = (int)(value * 100);
				if (!fromTb)
				{
					opacityTrackBar.Value = val;
				}
				if (!fromUd)
				{
					opacityValue.Value = val;
				}
			}
		}

		private float ch(CheckBox cb)
		{
			return cb.Checked ? 1 : 0;
		}
		private void average(float[][] m, int j, CheckBox ch)
		{
			if (ch.Checked)
			{
				var count = 0;
				for (var i = 0; i < 5; ++i)
				{
					count += (int)m[i][j];
				}
				if (count == 0)
				{
					return;
				}
				for (var i = 0; i < 5; ++i)
				{
					m[i][j] /= count;
				}
			}
		}

		private void opacityTrackBar_ValueChanged(object sender, EventArgs e)
		{
			if (fromTb || fromUd) return;
			fromTb = true;
			opacityValue.Value = opacityTrackBar.Value;
			fromTb = false;
			callMatrixChanged();
		}

		private void opacityValue_ValueChanged(object sender, EventArgs e)
		{
			if (fromTb || fromUd) return;
			fromUd = true;
			opacityTrackBar.Value = (int)opacityValue.Value;
			fromUd = false;
			callMatrixChanged();
		}

		private void callMatrixChanged()
		{
			if (ColorMatrixChanged != null)
			{
				ColorMatrixChanged(this, new EventArgs());
			}
		}

		private void checkbox_CheckedChanged(object sender, EventArgs e)
		{
			callMatrixChanged();
		}
	}
}
