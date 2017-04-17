﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BiUpdateHelper
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			BiUpdateHelperSettings settings = new BiUpdateHelperSettings();
			settings.Load();
			settings.SaveDefaultIfNoExist();

			if (Environment.UserInteractive)
			{
				System.Windows.Forms.Application.Run(new ServiceManager());
			}
			else
			{
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[]
				{
				new MainSvc()
				};
				ServiceBase.Run(ServicesToRun);
			}
		}
	}
}
