﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

		public static PointF Unscale(this Point source, float scale)
		{
			return new PointF(
				(float)source.X / scale,
				(float)source.Y / scale
			);
		}

		public static PointF Shift(this PointF source, PointF offset)
		{
			return new PointF(
				source.X - offset.X,
				source.Y - offset.Y
			);
		}

		public static PointF Move(this PointF source, PointF offset)
		{
			return new PointF(
				source.X + offset.X,
				source.Y + offset.Y
			);
		}

		public static Point ToPoint(this PointF pt)
		{
			return new Point((int)pt.X, (int)pt.Y);
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
	}
}
