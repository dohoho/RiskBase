using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS;
using RBI.Object;

namespace RBI.PRE.subForm
{
    public partial class UCDevexpress : UserControl
    {
        public UCDevexpress()
        {
            InitializeComponent();
            FormatGid();
            loadData();
        }
        private void FormatGid()
        {
            String[] fields = { "ItemNo", "EqDesc", "EqType", "ComName", "RepresentFluid", "FluidPhase", "CotcatFlammable", "CurrentRisk", "CotcatPeople", "CotcatAsset", "CotcatEnv", "CotcatReputation", "CotcatCombinled", "ComponentMaterialGrade", "InitThinningCategory", "InitEnvCracking", "InitOtherCategory", "InitCategory", "ExtThinningCategory", "ExtEnvCracking", "ExtOtherCategory", "ExtCategory", "POFCategory", "CurrentRiskCal", "FutureRisk" };
            String[] caption = { "Equipment", "Equipment Description", "Equipment Type", "Components", "Represent .fluid", "Fluid Phase", "Cotcat.flammable", "Current Risk", "Cotcat.people", "Cot.cat.asset", "Cot.cat.Env", "Cot.cat.Reputation", "Cot.cat.Combined", "Component Material grade", "InitThinningCategory", "InitEnvCracking", "InitOtherCategory", "InitCategory", "ExtThinningCategory", "ExtEnvCracking", "ExtOtherCategory", "ExtCategory", "POFCategory", "Current Risk", "Future Risk" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
                gridView1.Columns[i].Width = 100;
            }
            gridView1.BestFitColumns();
        }
        private void loadData()
        {
            BusRiskDemo bus = new BusRiskDemo();
            List<RiskSummary> list = bus.loads();
            gridControl1.DataSource = list;
        }
    }
}
