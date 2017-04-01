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
	public class BrightnessContrastLayer: MaskedLayer
	{
		public int Brightness { get; set; }
		public int Contrast { get; set; }

		public BrightnessContrastLayer(Bitmap mask):
			base(mask)
		{
			Name = "Brightness/Contrast";
		}

		public BrightnessContrastLayer(int width, int height) :
			base(width, height)
		{
			Name = "Brightness/Contrast";
		}

		private int clip(int value)
		{
			if (value > 255)
			{
				return 255;
			}
			if (value < -255)
			{
				return -255;
			}
			return value;
		}

		public override void Draw(Bitmap canvas)
		{
			var br = clip(Brightness);
			var ct = clip(Contrast);
			var fc = 259f * (ct + 255f) / 255f / (259f - ct);
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
				var b = (byte)c;
				var g = (byte)(c >> 8);
				var r = (byte)(c >> 16);
				var a = (byte)(c >> 24);
				var b2 = fc * (b - 128) + 128 + br;
				var g2 = fc * (g - 128) + 128 + br;
				var r2 = fc * (r - 128) + 128 + br;
				if (b2 < 0) b = 0; else if (b2 > 255) b = 255; else b = (byte)b2;
				if (g2 < 0) g = 0; else if (g2 > 255) g = 255; else g = (byte)g2;
				if (r2 < 0) r = 0; else if (r2 > 255) r = 255; else r = (byte)r2;
				Marshal.WriteInt32(data.Scan0, i * 4, b | (g << 8) | (r << 16) | (a << 24));
			});
			canvas.UnlockBits(data);
			Mask.UnlockBits(mask);
		}

		public override void ShowProperties()
		{
			var layerProps = new BrightnessContrastProperties();
			layerProps.Name = Name;
			layerProps.Brightness = Brightness;
			layerProps.Contrast = Contrast;
			var prevB = Brightness;
			var prevC = Contrast;
			layerProps.ValuesChanged +=layerProps_ValuesChanged;
			if (layerProps.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Name = layerProps.Name;
				Brightness = layerProps.Brightness;
				Contrast = layerProps.Contrast;
			}
			else
			{
				Brightness = prevB;
				Contrast = prevC;
			}
			Invalidate();
		}

		void layerProps_ValuesChanged(object sender, EventArgs e)
		{
 			var lp = sender as BrightnessContrastProperties;
			Brightness = lp.Brightness;
			Contrast = lp.Contrast;
			Invalidate();
		}
	}
}
