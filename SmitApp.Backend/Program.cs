﻿using System.ServiceProcess;

namespace SmitApp.Backend
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SmitService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}