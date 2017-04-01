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

namespace Picturesque.Editor
{
	public partial class LayerListItem : UserControl
	{
		public static Color SelectedColor = Color.Gray;
		private ILayer model;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ILayer Model
		{
			get { return model; }
			set
			{
				if (model != null)
				{
					model.Invalidated -= model_Invalidated;
				}
				model = value;
				model.Invalidated += model_Invalidated;
				model_Invalidated(this, null);
			}
		}
		private bool selected;
		public bool Selected 
		{
			get { return selected; }
			set
			{
				selected = value;
				BackColor = selected ? SelectedColor : Color.Transparent;
			}
		}

		void model_Invalidated(object sender, EventArgs e)
		{
			layerTitle.Text = model.Name;
			visibleBtn.Checked = !model.Visible;
			visibleBtn.TextImageRelation = model.Visible
				? TextImageRelation.Overlay
				: TextImageRelation.TextAboveImage;
			preview.Image = model.GetPreview(preview.Size);
			maskIcon.Visible = model is MaskedLayer;
		}

		public LayerListItem()
		{
			InitializeComponent();
			setTrasparentBackground();
		}

		private void setTrasparentBackground()
		{
			var grid = new Bitmap(10, 10);
			var g = Graphics.FromImage(grid);
			g.FillRectangle(Brushes.LightGray, 0, 0, 5, 5);
			g.FillRectangle(Brushes.LightGray, 5, 5, 5, 5);
			preview.BackgroundImage = grid;
		}

		private void layerTitle_Click(object sender, EventArgs e)
		{
			OnClick(e);
		}

		private void visibleBtn_Click(object sender, EventArgs e)
		{
			model.Visible = !model.Visible;
			model.Invalidate();
		}

		private void preview_Paint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			g.DrawRectangle(Pens.DimGray, 0, 0, 42, 42);
			if (model is MaskedLayer)
			{
				g.DrawImage(maskIcon.Image, 24, 26);
			}
		}
	}
}
