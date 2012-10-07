﻿/*  RPI helpdesk PSTAT
 *  Dan Berkowitz October 2012
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PSTAT
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
            Application.Run(new Main_Form());
        }
    }
}
