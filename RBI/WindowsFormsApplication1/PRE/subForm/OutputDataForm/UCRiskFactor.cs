using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCRiskFactor : UserControl
    {

        
        public UCRiskFactor()
        {
            InitializeComponent();
            
        }
        public UCRiskFactor(int ID)
        {
            InitializeComponent();
            riskPoF(ID);
            riskCA(ID);
        }
        public void riskPoF(int ID)
        {
            RW_FULL_POF_BUS bus = new RW_FULL_POF_BUS();
            RW_FULL_POF obj = bus.getData(ID);

            cbThinningType.Text = obj.ThinningType;
            textEdit1.Text = obj.GFFTotal.ToString();
            textEdit2.Text = obj.FMS.ToString();
            txt0Thinning.Text = obj.ThinningAP1.ToString();
            txt36Thinning.Text = obj.ThinningAP2.ToString();
            txt72Thinning.Text = obj.ThinningAP3.ToString();

            txt0StressCorrosion.Text = obj.SCCAP1.ToString();
            txt36StressCorrosion.Text = obj.SCCAP2.ToString();
            txt72StressCorrosion.Text = obj.SCCAP3.ToString();

            txt0External.Text = obj.ExternalAP1.ToString();
            txt36External.Text = obj.ExternalAP2.ToString();
            txt72External.Text = obj.ExternalAP3.ToString();

            txt0HighTemperature.Text = obj.HTHA_AP1.ToString();
            txt36HighTemperature.Text = obj.HTHA_AP2.ToString();
            txt72HighTemperature.Text = obj.HTHA_AP3.ToString();

            txt0BrittleFracture.Text = obj.BrittleAP1.ToString();
            txt36BrittleFracture.Text = obj.BrittleAP2.ToString();
            txt72BrittleFracture.Text = obj.BrittleAP3.ToString();

            txt0Piping.Text = obj.FatigueAP1.ToString();
            txt36Piping.Text = obj.FatigueAP2.ToString();
            txt72Piping.Text = obj.FatigueAP3.ToString();

            txt0Other.Text = obj.SemiAP1.ToString();
            txt32Other.Text = obj.SemiAP2.ToString();
            txt72Other.Text = obj.SemiAP3.ToString();

            txt0TotalGeneralThinning.Text = obj.ThinningGeneralAP1.ToString();
            txt36TotalGeneralThinning.Text = obj.ThinningGeneralAP2.ToString();
            txt72TotalGeneralThinning.Text = obj.ThinningGeneralAP3.ToString();

            txt0TotalLocalThinning.Text = obj.ThinningLocalAP1.ToString();
            txt36TotalLocalThinning.Text = obj.ThinningLocalAP2.ToString();
            txt72TotalLocalThinning.Text = obj.ThinningLocalAP3.ToString();

            txt0FinalTotalDamage.Text = obj.TotalDFAP1.ToString();
            txt36FinalTotalDamage.Text = obj.TotalDFAP2.ToString();
            txt72FinalTotalDamage.Text = obj.TotalDFAP3.ToString();

            txt0PoF.Text = obj.PoFAP1.ToString();
            txt36PoF.Text = obj.PoFAP2.ToString();
            txt72PoF.Text = obj.PoFAP3.ToString();

            txt0PoFCategory.Text = obj.PoFAP1Category;
            txt36PoFCategory.Text = obj.PoFAP2Category;
            txt72PoFCategory.Text = obj.PoFAP3Category;
        }
        public void riskCA(int ID)
        {
            RW_FULL_FCOF_BUS fullPoFBus = new RW_FULL_FCOF_BUS();
            RW_FULL_FCOF fullPoF = fullPoFBus.getData(ID);
            txtProductionCost.Text = fullPoF.prodcost.ToString();
            txtEquipmentCost.Text = fullPoF.equipcost.ToString();
            txtPopdens.Text = fullPoF.popdens.ToString();
            txtInjureCost.Text = fullPoF.injcost.ToString();
            txtEnvironmentCost.Text = fullPoF.envcost.ToString();
            txtFC.Text = fullPoF.FCoFValue.ToString();
            txtCA.Text = fullPoF.FCoFCategory;
        }
        public void ShowDataTank(int ID)
        {
            groupBox4.Hide();
            RW_CA_TANK_BUS busTank = new RW_CA_TANK_BUS();
            RW_CA_TANK ca = busTank.getData(ID);
            txtFC.Text = (ca.FC_Environ + ca.FC_Environ_Leak + ca.FC_Environ_Rupture).ToString();
            txtCA.Text = ca.ConsequenceCategory;
        }
    }
}
