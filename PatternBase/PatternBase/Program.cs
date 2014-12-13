using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    static class Program
    {
        public static FrmStart frmStart = new FrmStart();
        public static FrmEditor frmEditor = new FrmEditor();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(frmStart);
        }
    }
}
