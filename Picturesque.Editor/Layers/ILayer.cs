using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Picturesque.Editor.Layers
{
	public interface ILayer: ICloneable, IDisposable
	{
		event EventHandler<EventArgs> Invalidated;

		string Name { get; set; }
		bool Visible { get; set; }

		void Draw(Bitmap canvas);
		void Paint(Graphics g);
		Bitmap GetPreview(Size size);
		void Invalidate();
		void ShowProperties();

		void Save(string directory, string name);
	}

	public interface IMovable: ILayer
	{
		PointF Position { get; set; }
		void Move(float offsetX, float offsetY);
		void MoveTo(PointF position);
	}

	public interface IEditable: ILayer
	{
		Bitmap StartEditing();
		void ApplyChanges();
		void DiscardChanges();
	}

	public static class Layers
	{
		public static ILayer Open(string directory, string name)
		{
			var xml = new XmlSerializer(typeof(ImageLayer), new[] { 
				typeof(HueLayer), 
				typeof(BrightnessContrastLayer)
			});
			ImageLayer layer;
			using (var txt = new StreamReader(Path.Combine(directory, String.Format("{0}.xml", name))))
			{
				layer = xml.Deserialize(txt) as ImageLayer;
			}
			var image = new Bitmap(Path.Combine(directory, String.Format("{0}.png", name)));
			var dpi = Program.GetDPI();
			image.SetResolution(dpi, dpi);
			image.MakeTransparent();
			layer.Image = image;
			return layer;
		}
	}
}
