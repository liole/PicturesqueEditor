using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturesque.Editor
{
	public class History
	{
		private int limit = 10;
		private List<Project> history;
		private int index = 0;
		public Project Current { get; private set; }

		public bool CanUndo { get { return index > 0; } }
		public bool CanRedo { get { return index < history.Count - 1; } }

		private bool preserveState = true;

		public int Limit
		{
			get { return limit; }
			set
			{
				limit = value;
				clearToLimit();
			}
		}

		public History(Project proj)
		{
			history = new List<Project>();
			history.Add(proj.Clone() as Project);
			Current = proj;
		}

		public void SaveState()
		{
			if (preserveState)
			{
				preserveState = false;
				return;
			}
			if (index < history.Count - 1)
			{
				removeRange(index + 1, history.Count - index - 1);
			}
			history.Add(Current.Clone() as Project);
			index++;
			clearToLimit();
		}

		private void removeRange(int start, int count)
		{
			foreach(var i in Enumerable.Range(start, count))
			{
				history[i].Dispose();
			}
			history.RemoveRange(start, count);
		}

		public Project Undo()
		{
			if (CanUndo)
			{
				index--;
				setCurrent();
				return Current;
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public Project Redo()
		{
			if (CanRedo)
			{
				index++;
				setCurrent();
				return Current;
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		private void setCurrent()
		{
			// need this not disposed for consistency
			// current does not take effect immediately
			// may cause small memory leack
			//Current.Dispose();
			Current = history[index].Clone() as Project;
			preserveState = true;
		}

		private void clearToLimit()
		{
			if (history.Count > limit)
			{
				var count = history.Count - limit;
				removeRange(0, count);
				index -= count;
			}
		}
	}
}
