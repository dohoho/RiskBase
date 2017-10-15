using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm
{
    public partial class UCInspHistory : UserControl
    {
        public UCInspHistory()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
    }
}
