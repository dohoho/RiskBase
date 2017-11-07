using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.PRE.subForm;
using RBI.PRE.subForm.InputDataForm;
namespace RBI
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
            //Application.Run(new Form1());
            Application.Run(new RibbonForm1());
            //Application.Run(new test());
            //Application.Run(new frmImportInspection());
            //Application.Run(new NewFluid());
            //Application.Run(new newComponent());
        }
    }
}
