using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers.Properties;

namespace Picturesque.Editor.Layers
{
	public class ImageLayer: ILayer, IMovable, IEditable
	{
		public string Name { get; set; }
		public bool Visible { get; set; }
		public ColorMatrix ColorMatrix { get; set; }
		public Bitmap Image { get; private set; }
		private Bitmap temp { get; set; }
		private PointF position;
		public PointF Position {
			get { return position; }
			set { position = value; Invalidate(); }
		}
		
		public event EventHandler<EventArgs> Invalidated;

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
			temp = new Bitmap(Image);
			return temp;
		}

		public virtual void ApplyChanges()
		{
			Image.Dispose();
			Image = temp;
			temp = null;
			Invalidate();
		}

		public virtual void DiscardChanges()
		{
			temp.Dispose();
			temp = null;
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
			var source = temp == null ? Image : temp;
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
	}
}
