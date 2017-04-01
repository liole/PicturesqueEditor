using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturesque.Editor.Layers
{
	public class MaskedLayer: ImageLayer
	{
		public Bitmap Mask { get { return Image; } }

		public MaskedLayer(Bitmap mask):
			base(mask)
		{
			ColorMatrix.Matrix33 = 0.5f;
		}

		public MaskedLayer(int width, int height):
			base(width, height, Color.White)
		{
		}

		public override void Draw(Bitmap canvas)
		{
			throw new NotImplementedException();
		}

		public override void ShowProperties()
		{
			throw new NotImplementedException();
		}
	}
}
