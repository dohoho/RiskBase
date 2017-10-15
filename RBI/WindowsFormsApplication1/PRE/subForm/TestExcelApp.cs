using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class TestExcelApp : Form
    {
        public TestExcelApp()
        {
            InitializeComponent();
        }
        String path = null;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                path = op.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path);
            this.Close();
        }
    }
}
