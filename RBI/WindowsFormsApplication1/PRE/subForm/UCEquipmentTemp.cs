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
    public partial class UCEquipmentTemp : UserControl
    {
        public UCEquipmentTemp()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            BusEquipments eq = new BusEquipments();
            BusComponents buscom = new BusComponents();
            BusEquipmentTemp busEq = new BusEquipmentTemp();
            List<EquipmentTemp> list;
            list = busEq.loads();
            DataGridViewRow row;
            for (int i = 0; i < list.Count; i++)
            {
                //int x, y;
                row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = list[i].Plant;
                row.Cells[1].Value = eq.unitcode(list[i].ItemNo);
                row.Cells[2].Value = list[i].ItemNo;
                row.Cells[3].Value = eq.getdes(list[i].ItemNo);
                row.Cells[4].Value = eq.gettype(list[i].ItemNo);

                row.Cells[5].Value = list[i].ComName;
                //row.Cells[6].Value = buscom.getcom(list[i].ComName).Description;
                //row.Cells[7].Value = buscom.getcom(list[i].ComName).MOC;
                //row.Cells[8].Value = buscom.getcom(list[i].ComName).LinerMOC;
                //row.Cells[9].Value = buscom.getcom(list[i].ComName).HeightLength;
                //row.Cells[10].Value = buscom.getcom(list[i].ComName).Diameter;
                //row.Cells[11].Value = buscom.getcom(list[i].ComName).NorminalThickness;
                //row.Cells[12].Value = buscom.getcom(list[i].ComName).CA;
                //row.Cells[13].Value = buscom.getcom(list[i].ComName).DesignPressure;
                //row.Cells[14].Value = buscom.getcom(list[i].ComName).DesignTemp;

                row.Cells[15].Value = list[i].OperingPressInlet;
                row.Cells[16].Value = list[i].OperTempInlet;
                row.Cells[17].Value = list[i].OperingPressOutlet;
                row.Cells[18].Value = list[i].OperTempOutlet;
                row.Cells[19].Value = list[i].TestPress;
                row.Cells[20].Value = list[i].MDMT;
                row.Cells[21].Value = list[i].InService;
                row.Cells[22].Value = list[i].ServiceDate;
                row.Cells[23].Value = list[i].LastInternalInspectionDate;
                row.Cells[24].Value = list[i].LDTBXHCovered;

                row.Cells[25].Value = list[i].Insulated;
                row.Cells[26].Value = list[i].PWHT;
                row.Cells[27].Value = list[i].InsulatedType;
                row.Cells[28].Value = list[i].OperatingState;
                row.Cells[29].Value = list[i].InventoryLiquip;
                row.Cells[30].Value = list[i].InventoryVapor;
                row.Cells[31].Value = list[i].InventoryTotal;
                row.Cells[32].Value = list[i].ConfidentInStreamAnalysis;
                row.Cells[33].Value = list[i].VaporDensityAir;
                row.Cells[34].Value = list[i].CorrosionInhibitor;

                row.Cells[35].Value = list[i].FrequentFeedChanged;
                row.Cells[36].Value = list[i].MajorChemicals;
                row.Cells[37].Value = list[i].Contaminants;
                row.Cells[38].Value = list[i].OnLineMonitoring;
                row.Cells[39].Value = list[i].CathodicProtection;
                row.Cells[40].Value = list[i].OHCalibUptodate;
                row.Cells[41].Value = list[i].DistFromFacility;
                row.Cells[42].Value = list[i].EquipCount;
                row.Cells[43].Value = list[i].HAZOPRating;
                row.Cells[44].Value = list[i].PersonalDensity;

                row.Cells[45].Value = list[i].MitigationEquip;
                row.Cells[46].Value = list[i].EnvRating;
                row.Cells[47].Value = list[i].InspTechUsed;
                row.Cells[48].Value = list[i].EquipModification;
                row.Cells[49].Value = list[i].InspectionFinding;
                row.Cells[50].Value = list[i].VaporDensity;
                row.Cells[51].Value = list[i].LiquipDensity;
                row.Cells[52].Value = list[i].Vapor;
                row.Cells[53].Value = list[i].Liquip;
                row.Cells[54].Value = list[i].HMBPFDNum;

                row.Cells[55].Value = list[i].PIDNum;
                row.Cells[56].Value = list[i].Service;
                row.Cells[57].Value = list[i].HMBStream;
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
