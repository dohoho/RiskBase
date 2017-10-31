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
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCComponentProperties : UserControl
    {
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        //string[] itemsInsulationCondition = { "Above average", "Average", "Below average" };
        string[] itemsProtrusionComplexity = { "Above average", "Average", "Below average" };
        string[] itemsCyclicLoading = { "None", "PRV chatter", "Reciprocating machinery", "Valve with high pressure drop" };
        string[] itemsBranchDiameter = {"Any branch less than or equal to 2\" Nominal OD", "All branches greater than 2\" Nominal OD"};
        string[] itemsBranchJointType = {"None","Piping tee weldolets", "Saddle in fittings", "Sweepolets", "Threaded, socket welded, or saddle on"};
        string[] itemsNumberPipeFittings = {"More than 10", "6 to 10", "Up to 5"};
        string[] itemsPipeCondition = { "Broken gussets or gussets welded directly to pipe", "Good condition","Missing or damage supports, improper support"};
        string[] itemsPreviousFailure = {"Greater than one", "None", "One"};
        string[] itemsAmountShaking = { "Minor", "Moderate", "Severe" };
        string[] itemsAccumulatedTimeShaking = {"13 to 52 weeks", "2 to 13 weeks", "Less than 2 weeks"};
        string[] itemsCorrectiveAction = { "Engineering Analysis", "Experience", "None" };
        

        public UCComponentProperties()
        {
            InitializeComponent();
            additemsBrinnellHardness();
            additemsProtrusionComplexity();
            additemsCyclicLoading();
            additemsBranchDiameter();
            additemsBranchJointType();
            additemsNumberPipeFittings();
            additemsPipeCondition();
            additemsPreviousFailure();
            additemsAmountShaking();
            additemsAccumulatedTimeShaking();
            additemsCorrectiveAction();
        }
        private void additemsBrinnellHardness()
        {
            cbMaxBrillnessHardness.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsBrinnellHardness.Length; i++)
            {
                cbMaxBrillnessHardness.Properties.Items.Add(itemsBrinnellHardness[i], i, i);
            }
        }
        private void additemsProtrusionComplexity()
        {
            cbComplexityProtrusion.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsProtrusionComplexity.Length; i++)
            {
                cbComplexityProtrusion.Properties.Items.Add(itemsProtrusionComplexity[i], i, i);
            }
        }
        private void additemsCyclicLoading()
        {
            cbCyclicLoading.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsCyclicLoading.Length; i++)
            {
                cbCyclicLoading.Properties.Items.Add(itemsCyclicLoading[i], i, i);
            }
        }
        private void additemsBranchDiameter()
        {
            cbBranchDiameter.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsBranchDiameter.Length; i++)
            {
                cbBranchDiameter.Properties.Items.Add(itemsBranchDiameter[i], i, i);
            }
        }

        private void additemsBranchJointType()
        {
            cbJointTypeBranch.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsBranchJointType.Length; i++)
            {
                cbJointTypeBranch.Properties.Items.Add(itemsBranchJointType[i], i, i);
            }
        }
        private void additemsNumberPipeFittings()
        {
            cbNumberFittingPipe.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsNumberPipeFittings.Length; i++)
            {
                cbNumberFittingPipe.Properties.Items.Add(itemsNumberPipeFittings[i], i, i);
            }
        }
        private void additemsPipeCondition()
        {
            cbPipeCondition.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsPipeCondition.Length; i++)
            {
                cbPipeCondition.Properties.Items.Add(itemsPipeCondition[i], i, i);
            }
        }
        private void additemsPreviousFailure()
        {
            cbPreviousFailures.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsPreviousFailure.Length; i++)
            {
                cbPreviousFailures.Properties.Items.Add(itemsPreviousFailure[i], i, i);
            }
        }
        private void additemsAmountShaking()
        {
            cbAmountShakingPipe.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsAmountShaking.Length; i++)
            {
                cbAmountShakingPipe.Properties.Items.Add(itemsAmountShaking[i], i, i);
            }
        }

        private void additemsAccumulatedTimeShaking()
        {
            cbAccumalatedTimeShakingPipe.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsAccumulatedTimeShaking.Length; i++)
            {
                cbAccumalatedTimeShakingPipe.Properties.Items.Add(itemsAccumulatedTimeShaking[i], i, i);
            }
        }
        private void additemsCorrectiveAction()
        {
            cbCorrectiveAction.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsCorrectiveAction.Length; i++)
            {
                cbCorrectiveAction.Properties.Items.Add(itemsCorrectiveAction[i], i, i);
            }
        }

        public RW_COMPONENT getData()
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.ID = 1;
            comp.NominalDiameter = txtNominalDiameter.Text != "" ? float.Parse(txtNominalDiameter.Text) : 0;
            comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
            comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
            comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
            comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? float.Parse(txtCurrentCorrosionRate.Text) : 0;
            comp.BranchDiameter = cbBranchDiameter.Text;
            comp.BranchJointType = cbJointTypeBranch.Text;
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;
            comp.ComplexityProtrusion = cbComplexityProtrusion.Text;
            comp.ChemicalInjection = chkPresenceInjectionMixPoint.Checked ? 1 : 0;
            comp.HighlyInjectionInsp = chkHighlyEffectiveMixPoint.Checked ? 1 : 0;
            comp.CorrectiveAction = cbCorrectiveAction.Text;
            comp.CyclicLoadingWitin15_25m = cbCyclicLoading.Text;
            comp.DamageFoundInspection = chkDamageFoundDuringInspection.Checked ? 1 : 0;
            comp.DeltaFATT = txtDeltaFATT.Text != "" ? float.Parse(txtDeltaFATT.Text) : 0;
            comp.NumberPipeFittings = cbNumberFittingPipe.Text;
            comp.PipeCondition = cbPipeCondition.Text;
            comp.PreviousFailures = cbPreviousFailures.Text;
            comp.ShakingAmount = cbAmountShakingPipe.Text;
            comp.ShakingDetected = chkVisibleAudible.Checked ? 1 : 0;
            comp.ShakingTime = cbAccumalatedTimeShakingPipe.Text;
            comp.TrampElements = chkTrampElements.Checked ? 1 : 0;
            //comp.ShellHeight cua shell
            //comp.ReleasePreventionBarrier =  cua tank
            //comp.ConcreteFoundation = cua tank bottom
            //comp.SeverityOfVibration cua tank
            return comp;
        }
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }
        private void txtNominalDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalDiameter, e);
        }

        private void txtCurrentThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentThickness, e);
        }

        private void txtCurrentCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentCorrosionRate, e);
        }

        private void txtNominalThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalThickness, e);
        }

        private void txtMinRequiredThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinRequiredThickness, e);
        }

        private void txtDeltaFATT_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDeltaFATT, e);
        }
        
    }
}
