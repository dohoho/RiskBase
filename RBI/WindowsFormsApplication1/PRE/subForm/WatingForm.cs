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
    public partial class WatingForm : Form
    {
        public WatingForm()
        {
            InitializeComponent();
            
        }
        public Boolean process { set; get; }
        int progess = 0;
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progess += 1;
            
            // if (progess >= 100)
            // {
            // timer1.Enabled = false;
            // timer1.Stop();
            // }
            if(progess == 90)
            {
                //label1.Text = "Done!";
            }
           if(progess == 100)
            {
                progess = 0;
                i += 1;
            }
            if(i == 1)
            {
                this.Close();
            }
            //while (!process)
            //{
            //    this.Close();
            //}
            circularProgress1.Value = progess;
        }

        private void WatingForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 15;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
