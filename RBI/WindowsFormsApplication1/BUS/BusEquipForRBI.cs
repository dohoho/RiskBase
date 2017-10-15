using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusEquipForRBI
    {
        EquipmentForRbi eq = new EquipmentForRbi();
        EquipmentForRBIConnUtils eqUtils = new EquipmentForRBIConnUtils();
        public void add(EquipmentForRbi eq)
        {
            eqUtils.add(eq.UnitCode, eq.UnitName, eq.ProcessSystem);
        }
        public void edit(EquipmentForRbi eq, String olderUnitCode)
        {
            eqUtils.edit(eq.UnitCode, eq.UnitName, eq.ProcessSystem, olderUnitCode);
        }
        public void delete(String unitcode)
        {
            eqUtils.delete(unitcode);
        }
        public List<EquipmentForRbi> load()
        {
            return eqUtils.loads();
        }
        public bool checkExist(EquipmentForRbi eq)
        {
            return eqUtils.checkExist(eq.UnitCode);
        }
        public List<String> getUnitCode()
        {
            return eqUtils.getUnitCode();
        }
    }
}
