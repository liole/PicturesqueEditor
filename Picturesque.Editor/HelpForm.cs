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
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
			projectCat_LinkClicked(this, null);
		}

		private void projectCat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			rtf.Rtf = Properties.Resources.Project;
		}

		private void toolsCat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			rtf.Rtf = Properties.Resources.Tools;
		}

		private void layersCat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			rtf.Rtf = Properties.Resources.Layers;
		}
	}
}
