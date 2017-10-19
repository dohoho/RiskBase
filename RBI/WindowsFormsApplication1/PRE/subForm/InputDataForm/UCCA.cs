using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCCA : UserControl
    {
        string[] itemsFluid = {"Acid","AlCl3","C1-C2","C13-C16","C17-C25","C25+","C3-C4","C5", "C6-C8","C9-C12","CO","DEE","EE","EEA","EG","EO","H2","H2S","HCl","HF","Methanol","Nitric Acid","NO2","Phosgene","PO","Pyrophoric","Steam","Styrene","TDI","Water"};
        string[] itemsFluidPhase = { "Liquid", "Vapor", "Two-phase" };
        string[] itemsDetectionType = { "A", "B", "C" };
        string[] itemsMittigationSystem = {"Fire water deluge system and monitors", "Fire water monitors only", "Foam spray system","Inventory blowdown, couple with isolation system classification B or higher"};
        public UCCA()
        {
            InitializeComponent();
            additemsFluid();
            additemsFluidPhase();
            additemsDetectionType();
            additemsMittigationSystem();
        }
        private void additemsFluid()
        {
            cbFluid.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluid.Length; i++)
            {
                cbFluid.Properties.Items.Add(itemsFluid[i], i, i);
            }
        }
        private void additemsFluidPhase()
        {
            cbFluidPhase.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluidPhase.Length; i++)
            {
                cbFluidPhase.Properties.Items.Add(itemsFluidPhase[i], i, i);
            }
        }
        private void additemsDetectionType()
        {
            cbDetectionType.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsDetectionType.Length; i++)
            {
                cbDetectionType.Properties.Items.Add(itemsDetectionType[i], i, i);
            }
        }
        private void additemsMittigationSystem()
        {
            cbMittigationSystem.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsMittigationSystem.Length; i++)
            {
                cbMittigationSystem.Properties.Items.Add(itemsMittigationSystem[i], i, i);
            }
        }
        //du lieu cho Release Duration anh Vu viet
        
    }
}
