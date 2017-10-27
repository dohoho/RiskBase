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
using RBI.DAL.MSSQL_CAL;
namespace RBI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MSSQL_RBI_CAL_ConnUtils ms = new MSSQL_RBI_CAL_ConnUtils();
            MessageBox.Show( ms.GET_TBL_511(0.06f, 0, "E").ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = textBox1.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if(a.Contains('.')&&e.KeyChar=='.')
            {
                e.Handled = true;
            }
        }
    }
}
