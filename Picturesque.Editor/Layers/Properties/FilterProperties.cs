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
	public partial class FilterProperties : Form
	{
		public event EventHandler ValuesChanged;

		public FilterProperties()
		{
			InitializeComponent();
		}

		public string Name
		{
			get { return nameTb.Text; }
			set { nameTb.Text = value; }
		}

		bool changing = false;
		public FilterLayer.FilterType FilterType
		{
			get { return (FilterLayer.FilterType)filterType.SelectedIndex; }
			set
			{
				if (changing) return;
				changing = true;
				filterType.SelectedIndex = (int)value;
				changing = false;
			}
		}

		private void filterType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ValuesChanged != null)
			{
				ValuesChanged(this, new EventArgs());
			}
		}
	}
}
