using System;
using System.Windows.Forms;

namespace Connect4
{
    static class Program
    {
        /// <summary>
        /// Start of the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
