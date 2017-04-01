using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturesque.Editor.Layers
{
	public interface ILayer
	{
		event EventHandler<EventArgs> Invalidated;

		string Name { get; set; }
		bool Visible { get; set; }

		void Draw(Bitmap canvas);
		void Paint(Graphics g);
		Bitmap GetPreview(Size size);
		void Invalidate();
		void ShowProperties();
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
}
