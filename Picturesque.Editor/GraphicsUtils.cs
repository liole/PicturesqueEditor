using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor
{
	public static class GraphicsUtils
	{
		public static void DrawFuzzyLine(this Graphics g, Pen pen, float fuzziness, PointF point1, PointF point2)
		{
			var width = pen.Width;
			var opaqueWidth = width * (1 - fuzziness);
			var numSteps = width - opaqueWidth + 1;

			float delta = (float)pen.Color.A / numSteps / numSteps;

			float alpha = delta;

			for (var thickness = width; thickness >= opaqueWidth; thickness--)
			{
				Color color = Color.FromArgb(
					(int)alpha,
					pen.Color.R,
					pen.Color.G,
					pen.Color.B);
				using (Pen stepPen = new Pen(color, thickness))
				{
					stepPen.EndCap = LineCap.Round;
					stepPen.StartCap = LineCap.Round;
					g.DrawLine(stepPen, point1, point2);
				}
				alpha += delta;
			}
		}

		public static void DrawRectangle(this Graphics g, Pen pen, RectangleF rect)
		{
			g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static void DrawFillSquare(this Graphics g, Pen pen, Brush brush, PointF pos, float size)
		{
			var rect = new RectangleF(
				new PointF(pos.X - size/2, pos.Y - size/2),
				new SizeF(size, size)
			);
			g.FillRectangle(brush, rect);
			g.DrawRectangle(pen, rect);
		}

		public static void DrawFillCircle(this Graphics g, Pen pen, Brush brush, PointF pos, float size)
		{
			var rect = new RectangleF(
				new PointF(pos.X - size / 2, pos.Y - size / 2),
				new SizeF(size, size)
			);
			g.FillEllipse(brush, rect);
			g.DrawEllipse(pen, rect);
		}

		public static PointF Unscale(this Point source, float scale)
		{
			return new PointF(
				(float)source.X / scale,
				(float)source.Y / scale
			);
		}

		public static PointF Relative (this PointF source, SizeF size)
		{
			return new PointF(
				(float)source.X / size.Width,
				(float)source.Y / size.Height
			);
		}

		public static PointF UnRelative(this PointF source, SizeF size)
		{
			return new PointF(
				(float)source.X * size.Width,
				(float)source.Y * size.Height
			);
		}

		public static PointF Factors(this PointF source, float fx, float fy)
		{
			return new PointF(
				(float)source.X * fx,
				(float)source.Y * fy
			);
		}

		public static float DistanceTo(this PointF source, PointF center)
		{
			var s = source.Shift(center);
			return (float)Math.Sqrt(s.X * s.X + s.Y * s.Y);
		}

		public static float Norm(this PointF source)
		{
			return (float)Math.Sqrt(source.X * source.X + source.Y * source.Y);
		}

		public static float Dot(this PointF a, PointF b)
		{
			return a.X * b.X + a.Y * b.Y;
		}
		public static float Cross(this PointF a, PointF b)
		{
			return a.X * b.Y - a.Y * b.X;
		}

		public static PointF Shift(this PointF source, PointF offset)
		{
			return new PointF(
				source.X - offset.X,
				source.Y - offset.Y
			);
		}

		public static PointF Shift(this PointF source, float offsetX, float offsetY)
		{
			return new PointF(
				source.X - offsetX,
				source.Y - offsetY
			);
		}

		public static PointF Move(this PointF source, PointF offset)
		{
			return new PointF(
				source.X + offset.X,
				source.Y + offset.Y
			);
		}

		public static PointF Move(this PointF source, float offsetX, float offsetY)
		{
			return new PointF(
				source.X + offsetX,
				source.Y + offsetY
			);
		}

		public static bool Capturing(this PointF location, PointF pos, float size)
		{
			return
				location.X >= pos.X - size / 2 &&
				location.X <= pos.X + size / 2 &&
				location.Y >= pos.Y - size / 2 &&
				location.Y <= pos.Y + size / 2;
		}

		public static bool Capturing(this PointF location, RectangleF rect)
		{
			return
				location.X >= rect.Left &&
				location.X <= rect.Right &&
				location.Y >= rect.Top &&
				location.Y <= rect.Bottom;
		}

		public static Point ToPoint(this PointF pt)
		{
			return new Point((int)pt.X, (int)pt.Y);
		}

		public static float ToDegrees(this double ang)
		{
			return (float)(ang / Math.PI * 180);
		}

		public static float ToRadians(this double ang)
		{
			return (float)(ang / 180 * Math.PI);
		}

		public static byte Truncate(int c)
		{
			if (c > 255)
			{
				return 255;
			}
			if (c < 0)
			{
				return 0;
			}
			return (byte)c;
		}

		public static Int32 ApplyColorMatrix(Int32 c, float[][] m)
		{
			var v = new float[] { 
				(byte)(c >> 16) / 255f,
				(byte)(c >> 8) / 255f,
				(byte)(c) / 255f,
				(byte)(c >> 24) / 255f,
				1
			};
			var res = new float[5];
			for (var i = 0; i < 5; ++i)
			{
				res[i] = 0;
				for (var j = 0; j < 5; ++j)
				{
					res[i] += v[j] * m[j][i];
				}
			}
			for (var i = 0; i < 4; ++i)
			{
				res[i] /= res[4];
			}
			var w = res.Select(f => Truncate((int)(f * 255))).Take(4).ToArray();
			return w[2] | (w[1] << 8) | (w[0] << 16) | (w[3] << 24);
		}

		public static Bitmap ApplyColorMatrix(this Bitmap source, float[][] m)
		{
			var bmp = new Bitmap(source);
			var data = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height), 
				System.Drawing.Imaging.ImageLockMode.ReadWrite, 
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);
			Parallel.For(0, bmp.Width * bmp.Height, i =>
			{
				var c = Marshal.ReadInt32(data.Scan0, i * 4);
				Marshal.WriteInt32(data.Scan0, i * 4, ApplyColorMatrix(c, m));
			});
			bmp.UnlockBits(data);
			return bmp;
		}

		public static Bitmap ApplyPartialColorMatrix(this Bitmap source, float[][] m)
		{
			var bmp = new Bitmap(source);
			var data = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height),
				System.Drawing.Imaging.ImageLockMode.ReadWrite,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);
			Parallel.For(0, bmp.Width * bmp.Height, k =>
			{
				var c = Marshal.ReadInt32(data.Scan0, k * 4);
				var b = (byte)c;
				var g = (byte)(c >> 8);
				var r = (byte)(c >> 16);
				var a = (byte)(c >> 24);
				byte b2, g2, r2, a2;
				if (m[4][0] == 1) r2 = 255;
				else r2 = Truncate((int)(m[0][0] * r + m[1][0] * g + m[2][0] * b));
				if (m[4][1] == 1) g2 = 255;
				else g2 = Truncate((int)(m[0][1] * r + m[1][1] * g + m[2][1] * b));
				if (m[4][2] == 1) b2 = 255;
				else b2 = Truncate((int)(m[0][2] * r + m[1][2] * g + m[2][2] * b));
				a2 = Truncate((int)(m[3][3] * a + m[4][3]));
				Marshal.WriteInt32(data.Scan0, k * 4, b2 | (g2 << 8) | (r2 << 16) | (a2 << 24));
			});
			bmp.UnlockBits(data);
			return bmp;
		}

		private static int clip(int val, int max = 255, int min = 0)
		{
			if (val > max)
			{
				return max;
			}
			if (val < min)
			{
				return min;
			}
			return val;
		}
		public static Color AdjustHSL (this Color c, int h, int s, int l, bool colorize = false)
		{
			var cc = (ColorRGB)c;
			float hh = cc.H*360, ss = cc.S*100, ll = cc.L*100;
			if (colorize) hh = h;
			else hh += h;
			ss += s;
			ll += l;
			var hhh = clip((int)hh, 360, 0);
			var sss = clip((int)ss, 100, 0);
			var lll = clip((int)ll, 100, 0);
			var rgb = ColorRGB.FromHSLA(hhh / 360.0, sss / 100.0, lll / 100.0, c.A);
			return rgb;
		}

		public static Image GetImageFromClipboard()
		{
			using (MemoryStream ms = Clipboard.GetData("PNG") as MemoryStream)
			{
				if (ms != null)
				{
					try { return Image.FromStream(ms); }
					catch { }
				}
			}
			StringCollection paths = Clipboard.GetFileDropList();
			if (paths != null && paths.Count > 0)
			{
				foreach (string file in paths)
				{
					try { return Image.FromFile(file); }
					catch { }
				}
			}
			byte[] data;
			using (MemoryStream ms = Clipboard.GetData(DataFormats.Dib) as MemoryStream)
			{
				if (ms == null)
				{
					return Clipboard.GetImage();
				}
				data = ms.ToArray();
			}
			int width = BitConverter.ToInt32(data, 4);
			int stride = width * 4;
			int height = BitConverter.ToInt32(data, 8);
			int bpp = BitConverter.ToInt16(data, 14);
			if (bpp != 32)
				return Clipboard.GetImage();
			GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			try
			{
				IntPtr ptr = new IntPtr((long)handle.AddrOfPinnedObject() + 40);
				return new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppArgb, ptr);
			}
			catch
			{
				return Clipboard.GetImage();
			}
			finally
			{
				handle.Free();
			}
		}
	}
}
