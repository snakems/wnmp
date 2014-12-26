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
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Forms;
using Wnmp.Helpers;
using Wnmp.Internals;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to Nginx
    /// </summary>
    class Nginx
    {
        public static Process ps; // Avoid GC
        public static ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public static ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        private static readonly ToolTip toolTip = new ToolTip(); // ToolTip

        private static readonly string NginxExe = Main.StartupPath.Replace(@"\", "/") + "/nginx.exe";

        /// <summary>
        /// Starts an executable file
        /// </summary>
        public static void startprocess(string p, string args)
        {
            ps = new Process(); // Create process
            ps.StartInfo.FileName = p; // p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; // Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true; // Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true; // Excute with no window
            ps.Start(); // Start the process
        }

        public static void ngx_start_Click(object sender, EventArgs e)
        {
                startprocess(NginxExe, "");
                Log.wnmp_log_notice("Attempting to start Nginx", Log.LogSection.WNMP_NGINX);
                Common.ToStartedLabel(Program.formInstance.nginxrunning);
        }

        public static void ngx_stop_Click(object sender, EventArgs e)
        {
                startprocess(NginxExe, "-s stop");
                Log.wnmp_log_notice("Attempting to stop Nginx", Log.LogSection.WNMP_NGINX);
                Common.ToStoppedLabel(Program.formInstance.nginxrunning);
        }

        public static void ngx_reload_Click(object sender, EventArgs e)
        {
                startprocess(NginxExe, "-s reload");
                Log.wnmp_log_notice("Attempting to reload Nginx", Log.LogSection.WNMP_NGINX);
        }

        public static void ngx_stop_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Stop Nginx", Program.formInstance.ngx_stop);
        }

        public static void ngx_start_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Start Nginx", Program.formInstance.ngx_start);
        }

        public static void ngx_reload_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Reloads Nginx configuration without restart", Program.formInstance.ngx_reload);
        }

        public static void ngx_cfg_Click(object sender, EventArgs e)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cms.Show(ptLowerLeft);
            cms.ItemClicked -= cms_ItemClicked;
            cms.ItemClicked += cms_ItemClicked;
        }

        static void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/conf/" + e.ClickedItem.Text);
        }

        public static void ngx_log_Click(object sender, EventArgs e)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
            lms.ItemClicked -= lms_ItemClicked;
            lms.ItemClicked += lms_ItemClicked;
        }

        static void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/logs/" + e.ClickedItem.Text);
        }
    }
}
