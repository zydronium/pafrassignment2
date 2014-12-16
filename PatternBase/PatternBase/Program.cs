using PatternBase.Model;
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
        public static FrmNewPurpose frmNewPurpose;
        public static FrmNewScope frmNewScope;
        public static FrmNewPattern frmNewPattern;
        public static Database database;

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
            frmNewPurpose = new FrmNewPurpose(frmEditor);
            frmNewScope = new FrmNewScope(frmEditor);
            frmNewPattern = new FrmNewPattern(frmEditor);

            Application.Run(frmStart);
        }
    }
}
