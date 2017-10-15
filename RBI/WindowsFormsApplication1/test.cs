using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RBI.PRE.subForm.TabImportExcel;
namespace RBI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            if(textBox1.Text != "")
            MessageBox.Show(float.Parse(textBox1.Text).ToString());
        }
    }
}
