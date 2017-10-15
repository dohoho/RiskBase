using RBI.BUS.BUSXML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using RBI.Object;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS;

namespace RBI.PRE.subForm
{
    public partial class newComponent : Form
    {
        public newComponent()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void load()
        {
            ReadXML read = new ReadXML();
            // load existName
            List<String> listExist = read.getListComponet();
            for(int i =0; i< listExist.Count; i++)
            {
                comboBox1.Items.Add(listExist[i]);
            }
            // load MOC
            List<String> listMOC = read.getListMOC();
            for(int i =0; i< listMOC.Count; i++)
            {
                cbbMOC.Items.Add(listMOC[i]);
            }
            //load LMOC
            List<String> listLMOC = read.getListLMOC();
            for(int i=0; i<listLMOC.Count; i++)
            {
                cbbLMOC.Items.Add(listLMOC[i]);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Object.Component com = new Object.Component();
            com.Name = comboBox1.Text;
            com.MOC = cbbMOC.Text;
            com.LinerMOC = cbbLMOC.Text;
            com.HeightLength = txtHeigh.Text;
            com.Diameter = txtDiameter.Text;
            com.NorminalThickness = txtThick.Text;
            com.CA = txtCA.Text;
            com.DesignPressure = txtPressure.Text;
            com.DesignTemp = txtTemp.Text;
            com.Description = txtDescription.Text;
            BusComponents bus = new BusComponents();
            if (bus.checkExist(com))
            {
               // bus.edit(com, com.Name);
            }
            else
            {
                bus.add(com);
            }    
            this.Close();
        }
    }
}
