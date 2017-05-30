using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers.Properties;
using System.IO;
using System.Xml.Serialization;

namespace Picturesque.Editor.Layers
{
	[Serializable]
	public class ImageLayer: ILayer, IMovable, IEditable
	{
		public string Name { get; set; }
		public bool Visible { get; set; }
		public ColorMatrix ColorMatrix { get; set; }
		[XmlIgnore]
		public Bitmap Image { get; internal set; }
		private Bitmap prev { get; set; }
		private PointF position;
		public PointF Position {
			get { return position; }
			set { position = value; Invalidate(); }
		}
		
		public event EventHandler<EventArgs> Invalidated;

		public ImageLayer()
		{
		}

		public ImageLayer(Bitmap bmp)
		{
			Name = "New layer";
			Visible = true;
			Image = bmp;
			Position = new Point(0, 0);
			ColorMatrix = new ColorMatrix(new float[][]{ 
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 1, 0}, 
				new float[] {0, 0, 0, 0, 1}
			});
		}

		public ImageLayer(int width, int height, Color? background = null):
			this(new Bitmap(width, height))
		{
			if (background != null)
			{
				using (var g = Graphics.FromImage(Image))
				{
					g.Clear((Color)background);
				}
			}
			//using (var g = Graphics.FromImage(Image))
			//{
			//	using(var b = new LinearGradientBrush(
			//		new Point(30,0),
			//		new Point(0,30),
			//		Color.FromArgb(0,Color.Black),
			//		Color.Black
			//	))
			//	{
			//		//b.SetBlendTriangularShape(0.5f);
			//		b.SetSigmaBellShape(0.5f);
			//		using (var p = new Pen(b, 46)
			//		{
			//			StartCap = LineCap.Round,
			//			EndCap = LineCap.Round,
			//		})
			//		{
			//			g.DrawLine(p, 0, 0, 200, 200);
			//		}

			//	}
			//}
		}

		public float Opacity
		{
			get { return ColorMatrix.Matrix33; }
			set { ColorMatrix.Matrix33 = value; }
		}

		public virtual Bitmap StartEditing()
		{
			prev = new Bitmap(Image);
			return Image;
		}

		public virtual void ApplyChanges()
		{
			prev.Dispose();
			prev = null;
			Invalidate();
		}

		public virtual void DiscardChanges()
		{
			if (prev == null) return;
			Image.Dispose();
			Image = prev;
			prev = null;
			Invalidate();
		}

		public virtual void Draw(Bitmap canvas)
		{
			using (var g = Graphics.FromImage(canvas))
			{
				Paint(g);
			}
		}

		public virtual void Paint(Graphics g)
		{
			var source = Image;
			var imageAtt = new ImageAttributes();
			imageAtt.SetColorMatrix(
			   ColorMatrix,
			   ColorMatrixFlag.Default,
			   ColorAdjustType.Bitmap
			);
			var rect = new Rectangle(Position.ToPoint(), source.Size);
			g.DrawImage(source, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, imageAtt);
		}

		public virtual Bitmap GetPreview(Size size)
		{
			return new Bitmap(Image, size);
		}

		public void Move(float offsetX, float offsetY)
		{
			Position = new PointF(
				Position.X + offsetX,
				Position.Y + offsetY
			);
		}

		public void MoveTo(PointF position)
		{
			Position = position;
		}

		public void Invalidate()
		{
			if (Invalidated != null)
			{
				Invalidated(this, new EventArgs());
			}
		}

		public virtual void ShowProperties()
		{
			var layerProps = new ImageLayerProperties();
			layerProps.Name = Name;
			layerProps.ColorMatrix = ColorMatrix;
			ColorMatrix prev = ColorMatrix;
			layerProps.ColorMatrixChanged += layerProps_ColorMatrixChanged;
			if (layerProps.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Name = layerProps.Name;
				ColorMatrix = layerProps.ColorMatrix;
			}
			else
			{
				ColorMatrix = prev;
			}
			Invalidate();
		}

		void layerProps_ColorMatrixChanged(object sender, EventArgs e)
		{
			var lp = sender as ImageLayerProperties;
			ColorMatrix = lp.ColorMatrix;
			Invalidate();
		}

		public void DeleteArea(Region area)
		{
			using (var g = Graphics.FromImage(Image))
			{
				g.TranslateTransform(-Position.X, -Position.Y);
				g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
				g.FillRegion(Brushes.Transparent, area);
				Invalidate();
			}
		}

		public void Extend(Size size)
		{
			var newSize = size;
			var pos = new PointF(0, 0);
			var drawPos = Position;
			if (size.Width < Position.X + Image.Size.Width)
			{
				newSize.Width = (int)Position.X + Image.Size.Width;
			}
			if (size.Height < Position.Y + Image.Size.Height)
			{
				newSize.Height = (int)Position.Y + Image.Size.Height;
			}
			if (Position.X < 0)
			{
				newSize.Width -= (int)Position.X;
				pos.X = Position.X;
				drawPos.X = 0;
			}
			if (Position.Y < 0)
			{
				newSize.Height -= (int)Position.Y;
				pos.Y = Position.Y;
				drawPos.Y = 0;
			}
			var bmp = new Bitmap(newSize.Width, newSize.Height);
			using (var g = Graphics.FromImage(bmp))
			{
				g.DrawImage(Image, drawPos);
			}
			Position = pos;
			Image = bmp;
			Invalidate();
		}

		public void Clip(Size size)
		{
			var newSize = Image.Size;
			var pos = Position;
			var drawPos = new PointF(0, 0);
			if (size.Width < Position.X + Image.Size.Width)
			{
				newSize.Width = size.Width - (int)Position.X;
			}
			if (size.Height < Position.Y + Image.Size.Height)
			{
				newSize.Height = size.Height - (int)Position.Y;
			}
			if (Position.X < 0)
			{
				newSize.Width += (int)Position.X;
				pos.X = 0;
				drawPos.X = Position.X;
			}
			if (Position.Y < 0)
			{
				newSize.Height += (int)Position.Y;
				pos.Y = 0;
				drawPos.Y = Position.Y;
			}
			var bmp = new Bitmap(newSize.Width, newSize.Height);
			using (var g = Graphics.FromImage(bmp))
			{
				g.DrawImage(Image, drawPos);
			}
			Position = pos;
			Image = bmp;
			Invalidate();
		}

		public void Save(string directory, string name)
		{
			var xml = new XmlSerializer(typeof(ImageLayer), new[] { this.GetType() });
			using (var txt = new StreamWriter(Path.Combine(directory, String.Format("{0}.xml", name))))
			{
				xml.Serialize(txt, this);
			}
			Image.Save(Path.Combine(directory, String.Format("{0}.png", name)), ImageFormat.Png);
		}

		public object Clone()
		{
			var copy = this.MemberwiseClone() as ImageLayer;
			copy.Image = Image.Clone() as Bitmap;
			//copy.ColorMatrix = ColorMatrix.Clone(); // no clone?
			return copy;
		}

		public void Dispose()
		{
			Image.Dispose();
			if (prev != null)
			{
				prev.Dispose();
			}
		}
	}
}
