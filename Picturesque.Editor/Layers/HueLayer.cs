using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Picturesque.Editor.Layers.Properties;

namespace Picturesque.Editor.Layers
{
	public class HueLayer: MaskedLayer
	{
		public int Hue { get; set; }
		public int Saturation { get; set; }
		public int Lightness { get; set; }
		public bool Colorize { get; set; }

		public HueLayer() :
			base()
		{
		}

		public HueLayer(Bitmap mask):
			base(mask)
		{
			Name = "Hue/Saturation";
		}

		public HueLayer(int width, int height) :
			base(width, height)
		{
			Name = "Hue/Saturation";
		}

		public override void Draw(Bitmap canvas)
		{
			var data = canvas.LockBits(
				new Rectangle(0, 0, canvas.Width, canvas.Height),
				System.Drawing.Imaging.ImageLockMode.ReadWrite,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);
			var mask = Mask.LockBits(
				new Rectangle(0, 0, Mask.Width, Mask.Height),
				System.Drawing.Imaging.ImageLockMode.ReadOnly,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);
			// cache
			var canvasWidth = canvas.Width;
			var canvasHeight = canvas.Height;
			var canvasLength = canvasWidth * canvasHeight;
			var maskWidth = Mask.Width;
			var maskHeight = Mask.Height;
			var maskLength = maskWidth * maskHeight;
			var pos = new Point((int)Position.X, (int)Position.Y);
			Parallel.For(0, canvasLength, i =>
			{
				var x = i % canvasWidth - pos.X;
				var y = i / canvasWidth - pos.Y;
				if (x >= maskWidth || x < 0 || y >= maskHeight || y < 0) return;
				var j = y * maskWidth + x;
				if (j >= maskLength) return;
				var m = Marshal.ReadInt32(mask.Scan0, j * 4);
				if (m << 8 == 0) return;
				var c = Marshal.ReadInt32(data.Scan0, i * 4);
				var cc = Color.FromArgb(c);
				var ccc = cc.AdjustHSL(Hue, Saturation, Lightness, Colorize);
				Marshal.WriteInt32(data.Scan0, i * 4, ccc.ToArgb());
			});
			canvas.UnlockBits(data);
			Mask.UnlockBits(mask);
		}

		public override void ShowProperties()
		{
			var layerProps = new HueProperties();
			layerProps.Name = Name;
			layerProps.Hue = Hue;
			layerProps.Saturation = Saturation;
			layerProps.Lightness = Lightness;
			layerProps.Colorize = Colorize;
			var prevH = Hue;
			var prevS = Saturation;
			var prevL = Lightness;
			var prevC = Colorize;
			layerProps.ValuesChanged += layerProps_ValuesChanged;
			if (layerProps.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Name = layerProps.Name;
				Hue = layerProps.Hue;
				Saturation = layerProps.Saturation;
				Lightness = layerProps.Lightness;
				Colorize = layerProps.Colorize;
			}
			else
			{
				Hue = prevH;
				Saturation = prevS;
				Lightness = prevL;
				Colorize = prevC;
			}
			Invalidate();
		}

		void layerProps_ValuesChanged(object sender, EventArgs e)
		{
			var lp = sender as HueProperties;
			Hue = lp.Hue;
			Saturation = lp.Saturation;
			Lightness = lp.Lightness;
			Colorize = lp.Colorize;
			Invalidate();
		}
	}
}
