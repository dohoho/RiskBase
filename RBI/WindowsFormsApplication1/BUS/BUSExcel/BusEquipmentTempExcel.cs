using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.DAL;
namespace RBI.BUS.BUSExcel
{
    class BusEquipmentTempExcel
    {
        EquipmentTemp eq;
        //Component com;
        Equipment eqment;
        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect(String path)
        {
            return exConn.connectionExcel(path);
        }

        public List<EquipmentTemp> getListEQTemp(String path)
        {
            List<EquipmentTemp> list = new List<EquipmentTemp>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Data$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader[2].ToString().Equals(""))
                    {
                        eq = new EquipmentTemp();
                        eq.Plant = reader[0].ToString();
                        eq.OperingPressInlet = reader[15].ToString();
                        eq.OperTempInlet = reader[16].ToString();
                        eq.OperingPressOutlet = reader[17].ToString();
                        eq.OperTempOutlet = reader[18].ToString();
                        eq.TestPress = reader[19].ToString();
                        eq.MDMT = reader[20].ToString();
                        eq.InService = reader[21].ToString();
                        eq.ServiceDate = reader[22].ToString();
                        eq.LastInternalInspectionDate = reader[23].ToString();
                        eq.LDTBXHCovered = reader[24].ToString();
                        eq.Insulated = reader[25].ToString();
                        eq.PWHT = reader[26].ToString();
                        eq.InsulatedType = reader[27].ToString();
                        eq.OperatingState = reader[28].ToString();
                        eq.InventoryLiquip = reader[29].ToString();
                        eq.InventoryVapor = reader[30].ToString();
                        eq.InventoryTotal = reader[31].ToString();
                        eq.ConfidentInStreamAnalysis = reader[32].ToString();
                        eq.VaporDensityAir = reader[33].ToString();
                        eq.CorrosionInhibitor = reader[34].ToString();
                        eq.FrequentFeedChanged = reader[35].ToString();
                        eq.MajorChemicals = reader[36].ToString();
                        eq.Contaminants = reader[37].ToString();
                        eq.OnLineMonitoring = reader[38].ToString();
                        eq.CathodicProtection = reader[39].ToString();
                        eq.CorrosionMonitoring = reader[40].ToString();
                        eq.OHCalibUptodate = reader[41].ToString();
                        eq.DistFromFacility = reader[42].ToString();
                        eq.EquipCount = reader[43].ToString();
                        eq.HAZOPRating = reader[44].ToString();
                        eq.PersonalDensity = reader[45].ToString();
                        eq.MitigationEquip = reader[46].ToString();
                        eq.EnvRating = reader[47].ToString();
                        eq.InspTechUsed = reader[48].ToString();
                        eq.EquipModification = reader[49].ToString();
                        eq.InspectionFinding = reader[50].ToString();
                        eq.VaporDensity = reader[51].ToString();
                        eq.LiquipDensity = reader[52].ToString();
                        eq.Vapor = reader[53].ToString();
                        eq.Liquip = reader[54].ToString();
                        eq.HMBPFDNum = reader[55].ToString();
                        eq.PIDNum = reader[56].ToString();
                        eq.Service = reader[57].ToString();
                        eq.HMBStream = reader[58].ToString();
                        eq.ItemNo = reader[2].ToString();
                        eq.ComName = reader[5].ToString();

                        list.Add(eq);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat", "Error rbi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<Equipment> getListEquipment(String path)
        {
            List<Equipment> list = new List<Equipment>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Data$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader[2].ToString().Equals(""))
                    {
                        eqment = new Equipment();
                        eqment.ItemNo = reader[2].ToString();
                        //eqment.Type = reader[4].ToString();
                        //eqment.EquipmentDescription = reader[3].ToString();
                        list.Add(eqment);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat", "Error rbi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
    }
}
