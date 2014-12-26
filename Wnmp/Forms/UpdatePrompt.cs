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
using System.Diagnostics;
using System.Windows.Forms;

using Wnmp.Internals;
namespace Wnmp.Forms
{
    /// <summary>
    /// Form for viewing the changelog and asking if the user would like to update
    /// </summary>
    public partial class UpdatePrompt : Form
    {
        public UpdatePrompt()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Common.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void viewchange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.getwnmp.org/WhatsNew");
        }
    }
}
