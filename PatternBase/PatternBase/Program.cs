using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    static class Program
    {
        public static FrmStart frmStart;
        public static FrmEditor frmEditor;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmStart = new FrmStart();
            frmEditor = new FrmEditor();


            Application.Run(frmStart);
        }
    }
}
