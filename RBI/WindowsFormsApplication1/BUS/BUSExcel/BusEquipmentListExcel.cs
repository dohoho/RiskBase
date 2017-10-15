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
    class BusEquipmentListExcel
    {
        Equipment eq;
        ExcelConnect exCon = new ExcelConnect();
        BusEquipmentForRBIExcel exEqCon = new BusEquipmentForRBIExcel();
        public OleDbConnection getConnect(String path)
        {
            return exCon.connectionExcel(path);
        }
        
        public List<Equipment> getListAllEquipment( String path)
        {
            List<Equipment> list = new List<Equipment>();
            List<String> listUnitCode = exEqCon.getListUnitCode(path);
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();                
                for( int i = 0; i < listUnitCode.Count; i++)
                {
                    List<Equipment> listBuff = new List<Equipment>();
                    String cmd = "select * from [" + listUnitCode[i] + "$]";
                    OleDbCommand command = new OleDbCommand(cmd, conn);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String data = reader[1].ToString();
                        if (data != "")
                        {
                            eq = new Equipment();
                            eq.ItemNo = data;
                            eq.Name = reader[2].ToString();

                            //qty
                            String qty = reader[3].ToString();
                            if(qty.Equals(""))
                            {
                                qty = "0";
                            }
                            eq.Qty = qty;
                            
                            //semi-qty
                            String semi_qty = reader[4].ToString();
                            if (semi_qty.Equals(""))
                            {
                                semi_qty = "0";
                            }
                            eq.Semi_Quanty = semi_qty;
                            
                            // quantitative
                            String quantitative = reader[11].ToString();
                            if (quantitative.Equals(""))
                            {
                                quantitative = "N";
                            }
                            eq.Quanlitative = quantitative;

                            // processStream
                            String processStream = reader[7].ToString();
                            if (processStream.Equals(""))
                            {
                                processStream = "N";
                            }
                            eq.ProcessStream = processStream;

                            //pressure
                            String pressure = reader[8].ToString();
                            if (pressure.Equals(""))
                            {
                                pressure = "N";
                            }
                            eq.Pressure = pressure;

                            //pha
                            String pha = reader[9].ToString();
                            if (pha.Equals(""))
                            {
                                pha = "N";
                            }
                            eq.PHA = pha;

                            //business
                            String business = reader[10].ToString();
                            if (business.Equals(""))
                            {
                                business = "N";
                            }
                            eq.Business = business;

                            //processStreamFluid
                            String processStreamFluid = reader[12].ToString();
                            eq.ProcessStreamFluid = processStreamFluid;

                            //operatingPressure
                            String operatingPressure = reader[13].ToString();
                            eq.OperatingPressure = operatingPressure;

                            //phaRating
                            String phaRating = reader[14].ToString();
                            eq.PHARating = phaRating;

                            //businessLossValue
                            String businessLossValue = reader[15].ToString();
                            eq.BusinessLossValue = businessLossValue;

                            //group, type
                            //eq.Group = "";
                            //eq.Type = "";

                            //unitcode
                            eq.UnitCode = listUnitCode[i];

                            listBuff.Add(eq);
                        }
                    }
                    for(int j = 1; j< listBuff.Count; j++)
                    {
                        list.Add(listBuff[j]);
                    }                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat" + ex.ToString(), "Error eqlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
