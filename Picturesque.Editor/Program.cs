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
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var mainForm = new MainForm();
			mainForm.Show();
			if (args.Length > 0)
			{
				mainForm.open(args[0]);
			}
			Application.Run(mainForm);
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
