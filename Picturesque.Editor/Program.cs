using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picturesque.Editor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static int GetDPI()
		{
			int currentDPI = 96;
			using (Graphics g = Application.OpenForms[0].CreateGraphics())
			{
				currentDPI = (int)g.DpiX;
			}
			return currentDPI;
		}
	}
}
