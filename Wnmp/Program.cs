﻿/*
Copyright (c) Kurt Cancemi 2012-2014

This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Forms;
namespace Wnmp
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
            OSVersionCheck();
            Application.Run(formInstance = new Main());
        }
        public static Main formInstance;

        /// <summary>
        /// Checks if the OS is Vista+
        /// </summary>
        private static void OSVersionCheck()
        {
            if (Environment.OSVersion.Version.Major < 6) {
                MessageBox.Show("Windows Vista+ is required to run Wnmp");
                Process process = Process.GetCurrentProcess();
                process.Kill();
            }
        }
    }
}
