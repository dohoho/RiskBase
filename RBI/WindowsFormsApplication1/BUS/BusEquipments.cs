using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusEquipments
    {
        Equipment eq = new Equipment();
        EquipmentConnUtils eqUtils = new EquipmentConnUtils();
        public String unitcode(String itemNo)
        {
            return eqUtils.getUnitcode(itemNo);
        }
        public String getdes(String itemNo)
        {
            return eqUtils.getDes(itemNo);
        }
        public String gettype(String itemNo)
        {
            return eqUtils.getType(itemNo);
        }
        public void add(Equipment eq)
        {
            eqUtils.add(eq.ItemNo, eq.Name, eq.Qty, eq.Semi_Quanty, eq.Quanlitative, eq.ProcessStream, eq.Pressure, eq.PHA, eq.Business, eq.ProcessStreamFluid, eq.OperatingPressure, eq.PHARating, eq.BusinessLossValue, eq.UnitCode);
        }
        public void edit(Equipment eq, String olderItemNo)
        {
            eqUtils.edit(eq.ItemNo, eq.Name, eq.Qty, eq.Semi_Quanty, eq.Quanlitative, eq.ProcessStream, eq.Pressure, eq.PHA, eq.Business, eq.ProcessStreamFluid, eq.OperatingPressure, eq.PHARating, eq.BusinessLossValue, eq.UnitCode, olderItemNo);
        }
        public void edit(String itemNo, String type, String des)
        {
            eqUtils.edit(itemNo, type, des);
        }
        public void delete( Equipment eq)
        {
            eqUtils.delete(eq.ItemNo);
        }
        public List<Equipment> loads(String data)
        {
            return eqUtils.loads(data);
        }
        public List<Equipment> loads()
        {
            return eqUtils.loads();
        }
        public Equipment getEquipment(String itemNo)
        {
            return eqUtils.getEquipment(itemNo);
        }
        public bool checkExist(Equipment eq)
        {
            return eqUtils.checkExist(eq.ItemNo);
        }
        public int getQty(String unit)
        {
            return eqUtils.getTotalQty(unit);
        }
        public int getSemi(String unit)
        {
            return eqUtils.getTotalSemi(unit);
        }
        
    }
}
