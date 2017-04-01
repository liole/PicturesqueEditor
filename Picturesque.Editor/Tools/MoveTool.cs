using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturesque.Editor.Layers;
using Picturesque.Editor.Tools.Properties;

namespace Picturesque.Editor.Tools
{
	public class MoveTool : Tool
	{
		private PointF initPosition;
		private PointF position;

		public MoveTool(Project project) :
			base(project)
		{
			Project.SelectedLayerChanged += Project_SelectedLayerChanged;
			setCursor();
			Panel = new MoveToolProperties(this);
		}

		public override void Paint(Graphics g)
		{
			base.Paint(g);
			if (mouseDown)
			{
				g.TranslateTransform(position.X, position.Y);
				Project.SelectedLayer.Paint(g);
				g.TranslateTransform(-position.X, -position.Y);
			}
		}

		void Project_SelectedLayerChanged(object sender, EventArgs e)
		{
			setCursor();
			Invalidate();
		}

		public override void OnMouseDown(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseDown(location, keys, buttons);
			if (Project.SelectedLayer is IMovable)
			{
				var movableLayer = Project.SelectedLayer as IMovable;
				initPosition = movableLayer.Position;
				position = new PointF(0, 0);
				movableLayer.Visible = false;
				movableLayer.Invalidate();
				changeCursor(Cursors.SizeAll);
			}
		}

		public override void OnMouseMove(PointF location, Keys keys, MouseButtons buttons)
		{
			base.OnMouseMove(location, keys, buttons);
			if (mouseDown)
			{
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					position = new PointF(
						location.X - mouseInit.X,
						location.Y - mouseInit.Y
					);
					Invalidate();
				}
			}
		}

		public override void OnMouseUp(PointF location, Keys keys, MouseButtons buttons)
		{
			if (mouseDown)
			{
				base.OnMouseUp(location, keys, buttons);
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					movableLayer.Visible = true;
					movableLayer.MoveTo(new PointF(
						initPosition.X + location.X - mouseInit.X,
						initPosition.Y + location.Y - mouseInit.Y
					));
				}
				setCursor();
			}
			else
			{
				base.OnMouseUp(location, keys, buttons);
			}
		}
		public override void OnKeyPress(Keys keys, MouseButtons buttons)
		{
			base.OnKeyPress(keys, buttons);
			if (keys.HasFlag(Keys.Up) || keys.HasFlag(Keys.Down) ||
				keys.HasFlag(Keys.Left) || keys.HasFlag(Keys.Right))
			{
				if (Project.SelectedLayer is IMovable)
				{
					var movableLayer = Project.SelectedLayer as IMovable;
					var dx = 0;
					var dy = 0;
					switch (keys)
					{
						case Keys.Up:
							dy -= 1;
							break;
						case Keys.Down:
							dy += 1;
							break;
						case Keys.Left:
							dx -= 1;
							break;
						case Keys.Right:
							dx += 1;
							break;
					}
					movableLayer.Move(dx, dy);
					Invalidate();
				}
			}
		}
		
		public PointF GetCurrentPosition()
		{
			if (Project.SelectedLayer is IMovable)
			{
				var movableLayer = Project.SelectedLayer as IMovable;
				var pos = movableLayer.Position;
				if (mouseDown)
				{
					pos = pos.Move(position);
				}
				return pos;
			}
			return initPosition;
		}

		public override void Discard()
		{
			base.Discard();
			if (Project.SelectedLayer is IMovable)
			{
				Project.SelectedLayer.Visible = true;
				Project.SelectedLayer.Invalidate();
				setCursor();
			}
		}

		private void setCursor()
		{
			if (Project.SelectedLayer is IMovable)
			{
				changeCursor(Cursors.Default);
			}
			else
			{
				changeCursor(Cursors.No);
			}
		}
	}
}
