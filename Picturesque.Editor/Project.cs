using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers;

namespace Picturesque.Editor
{
	public class Project
	{
		public Selection Selection { get; set; }
		public List<ILayer> Layers { get; private set; }
		public Bitmap Image { get; private set; }
		private ILayer selectedLayer;
		public ILayer SelectedLayer {
			get { return selectedLayer; }
			set
			{
				selectedLayer = value;
				if (SelectedLayerChanged != null)
				{
					SelectedLayerChanged(this, new EventArgs());
				}
			}
		}

		public event EventHandler Invalidated;
		public event EventHandler SelectedLayerChanged;
		public event EventHandler LayersListChanged;

		public Project(int width, int height, Color? background = null)
		{
			Image = new Bitmap(width, height);
			Layers = new List<ILayer>();
			SelectedLayer = AddLayer(background);
			SelectedLayer.Name = "Background";
		}

		public ILayer AddLayer(Color? background = null)
		{
			var layer = new ImageLayer(Image.Width, Image.Height, background);
			layer.Invalidated += layer_Invalidated;
			Layers.Add(layer);
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
			return layer;
		}

		public ILayer AddLayer(ILayer layer)
		{
			layer.Invalidated += layer_Invalidated;
			Layers.Add(layer);
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
			return layer;
		}

		public ILayer RemoveLayer(ILayer layer = null)
		{
			if (Layers.Count <= 1)
			{
				throw new InvalidOperationException();
			}
			var toRemove = layer;
			if (layer == null)
			{
				toRemove = SelectedLayer;
			}
			Layers.Remove(toRemove);
			if (toRemove == SelectedLayer)
			{
				SelectedLayer = Layers.Last();
			}
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
			return SelectedLayer;
		}

		public void MoveUp()
		{
			if (SelectedLayer == Layers.Last())
			{
				return;
			}
			var i = Layers.IndexOf(SelectedLayer);
			Layers[i] = Layers[i + 1];
			Layers[i + 1] = SelectedLayer;
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
		}

		public void MoveDown()
		{
			if (SelectedLayer == Layers.First())
			{
				return;
			}
			var i = Layers.IndexOf(SelectedLayer);
			Layers[i] = Layers[i - 1];
			Layers[i - 1] = SelectedLayer;
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
		}

		public void Flaten()
		{
			var layer = new ImageLayer(new Bitmap(Image));
			layer.Name = "Merged layer";
			layer.Invalidated += layer_Invalidated;
			Layers.Clear();
			Layers.Add(layer);
			SelectedLayer = layer;
			if (LayersListChanged != null)
			{
				LayersListChanged(this, new EventArgs());
			}
			Invalidate();
		}

		public void CreateSelection(GraphicsPath path = null)
		{
			Selection = new Selection(path);
			Selection.Invalidated += selection_Invalidated;
		}

		public void ClearSelection()
		{
			Selection = null;
			Invalidate();
		}

		public Bitmap GetMask()
		{
			var mask = new Bitmap(Image.Size.Width, Image.Size.Height);
			using (var g = Graphics.FromImage(mask))
			{
				if (Selection == null)
				{
					g.Clear(Color.White);
				}
				else
				{
					g.Clear(Color.Black);
					g.FillPath(Brushes.White, Selection.Path);
					Selection = null;
				}
			}
			return mask;
		}

		void selection_Invalidated(object sender, EventArgs e)
		{
			if (Invalidated != null)
			{
				Invalidated(sender, e);
			}
		}

		void layer_Invalidated(object sender, EventArgs e)
		{
			Invalidate();
		}

		public void Invalidate()
		{
			Redraw();
			if (Invalidated != null)
			{
				Invalidated(this, new EventArgs());
			}
		}

		public void Redraw()
		{
			using (var g = Graphics.FromImage(Image))
			{
				g.Clear(Color.Transparent);
			}
			foreach (var layer in Layers)
			{
				if (layer.Visible)
				{
					layer.Draw(Image);
				}
			}
		}
	}
}
